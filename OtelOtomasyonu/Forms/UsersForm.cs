using System;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using OtelOtomasyonu.Data;
using OtelOtomasyonu.Data.Entities;
using OtelOtomasyonu.Services;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;

namespace OtelOtomasyonu.Forms
{
    public partial class UsersForm : XtraForm
    {
        private readonly StaffService _staffService;
        private readonly bool _isStaffMode; // Personel modu: sadece müşteri bilgileri göster

        public UsersForm(bool isStaffMode = false)
        {
            InitializeComponent();
            _staffService = new StaffService();
            _isStaffMode = isStaffMode;
            
            // Apply Global Theme
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.LookAndFeel.SkinName = "DevExpress Dark Style";
            
            CustomizeGrids();
            
            if (_isStaffMode)
            {
                // Personel modu: sadece müşteri bilgileri göster
                btnTabStaff.Visible = false;
                tabControl.TabPages.Remove(tabStaff);
                LoadCustomers();
                SetActiveTab(false); // Customer tab'ı göster
            }
            else
            {
                // Admin modu: hem personel hem müşteri bilgileri göster
                LoadStaff();
                LoadCustomers();
                SetActiveTab(true); // True = Staff, False = Customer
            }
        }

        private void CustomizeGrids()
        {
            // --- Helper to style a GridView ---
            void StyleGrid(DevExpress.XtraGrid.Views.Grid.GridView view)
            {
                view.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Black;
                view.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Gold;
                view.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
                
                view.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
                view.Appearance.Row.ForeColor = System.Drawing.Color.White;
                
                view.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
                view.OptionsView.EnableAppearanceEvenRow = true;
                
                view.Appearance.SelectedRow.BackColor = System.Drawing.Color.Gold;
                view.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;

                // Center Headers
                view.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }

            StyleGrid(gridViewStaff);
            StyleGrid(gridViewCustomers);
        }

        // =========================
        // TAB LOGIC
        // =========================
        private void btnTabStaff_Click(object sender, EventArgs e) => SetActiveTab(true);
        private void btnTabCustomers_Click(object sender, EventArgs e) => SetActiveTab(false);

        private void SetActiveTab(bool isStaff)
        {
            if (isStaff)
            {
                tabControl.SelectedTabPage = tabStaff;
                
                // Staff Button Active
                btnTabStaff.Appearance.BackColor = Color.Gold;
                btnTabStaff.Appearance.ForeColor = Color.Black;
                
                // Customer Button Inactive
                btnTabCustomers.Appearance.BackColor = Color.Transparent;
                btnTabCustomers.Appearance.ForeColor = Color.Gold;
            }
            else
            {
                tabControl.SelectedTabPage = tabCustomers;
                
                // Staff Button Inactive
                btnTabStaff.Appearance.BackColor = Color.Transparent;
                btnTabStaff.Appearance.ForeColor = Color.Gold;

                // Customer Button Active
                btnTabCustomers.Appearance.BackColor = Color.Gold;
                btnTabCustomers.Appearance.ForeColor = Color.Black;
            }
        }

        // =========================
        // STAFF LOGIC
        // =========================
        private void LoadStaff()
        {
            try
            {
                gridControlStaff.DataSource = _staffService.GetAllStaff();
                gridViewStaff.PopulateColumns();

                // Hide sensitive or irrelevant columns
                string[] hideCols = { "Password", "ProfilePicturePath", "Id", "Role", "LastLoginDate", "SelectionToken", "LicensePlate" };
                foreach(var col in hideCols)
                {
                    if (gridViewStaff.Columns[col] != null) gridViewStaff.Columns[col].Visible = false;
                }

                // Captions
                if(gridViewStaff.Columns["Username"] != null) gridViewStaff.Columns["Username"].Caption = "Kullanıcı Adı";
                if(gridViewStaff.Columns["Name"] != null) gridViewStaff.Columns["Name"].Caption = "Ad";
                if(gridViewStaff.Columns["Surname"] != null) gridViewStaff.Columns["Surname"].Caption = "Soyad";
                if(gridViewStaff.Columns["Department"] != null) 
                {
                    gridViewStaff.Columns["Department"].Caption = "Departman";
                }
                if(gridViewStaff.Columns["JobTitle"] != null) gridViewStaff.Columns["JobTitle"].Caption = "Görev";
                if(gridViewStaff.Columns["Salary"] != null) 
                {
                    gridViewStaff.Columns["Salary"].Caption = "Maaş";
                    gridViewStaff.Columns["Salary"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    gridViewStaff.Columns["Salary"].DisplayFormat.FormatString = "N2";
                }
                if(gridViewStaff.Columns["WorkHours"] != null) gridViewStaff.Columns["WorkHours"].Caption = "Çalışma Saatleri";
                
                // Group by Department
                if(gridViewStaff.Columns["Department"] != null) gridViewStaff.Columns["Department"].GroupIndex = 0;
                
                // Department'ı Türkçe göstermek için CustomColumnDisplayText event'i
                gridViewStaff.CustomColumnDisplayText -= GridViewStaff_CustomColumnDisplayText;
                gridViewStaff.CustomColumnDisplayText += GridViewStaff_CustomColumnDisplayText;
                
                gridViewStaff.BestFitColumns();
                gridViewStaff.ExpandAllGroups();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        private void GridViewStaff_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "Department" && e.Value is Department dept)
            {
                switch (dept)
                {
                    case Department.FrontOffice: e.DisplayText = "Ön Büro"; break;
                    case Department.Housekeeping: e.DisplayText = "Kat Hizmetleri"; break;
                    case Department.FoodAndBeverage: e.DisplayText = "Yiyecek ve İçecek"; break;
                    case Department.BackOffice: e.DisplayText = "Yönetim ve İdari"; break;
                    case Department.TechnicalAndSecurity: e.DisplayText = "Teknik Servis ve Güvenlik"; break;
                    default: break;
                }
            }
        }

        private void btnAddStaff_Click(object sender, EventArgs e)
        {
            using (var form = new StaffAddForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                    LoadStaff();
            }
        }

        private void btnUpdateStaff_Click(object sender, EventArgs e)
        {
            var row = gridViewStaff.GetFocusedRow() as User;
            if (row == null) return;

            using (var form = new StaffAddForm(row.Id))
            {
                if (form.ShowDialog() == DialogResult.OK)
                    LoadStaff();
            }
        }

        private void btnDeleteStaff_Click(object sender, EventArgs e)
        {
            var row = gridViewStaff.GetFocusedRow() as User;
            if (row == null) return;

            if (XtraMessageBox.Show($"{row.Name} personelini silmek istiyor musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _staffService.DeleteStaff(row.Id);
                LoadStaff();
            }
        }

        // =========================
        // CUSTOMER LOGIC
        // =========================
        private void LoadCustomers()
        {
            using (var context = new HotelContext())
            {
                // Aynı kayıt ekranında kaydedilen müşterileri grupla (RegistrationGroupId'ye göre)
                var allCustomers = context.Users
                    .Where(u => u.Role == UserRole.Customer)
                    .ToList();

                // RegistrationGroupId'ye göre grupla (null olanlar tek başına)
                var customerGroups = allCustomers
                    .GroupBy(u => u.RegistrationGroupId ?? Guid.NewGuid()) // Null olanlar için unique grup
                    .ToList();

                var customers = new List<dynamic>();
                
                foreach (var group in customerGroups)
                {
                    // Ana müşteri (e-postası olan veya SelectionToken'ı olan)
                    var mainCustomer = group.FirstOrDefault(u => !string.IsNullOrEmpty(u.Email) || u.SelectionToken != null);
                    
                    // Eğer grupta e-postası veya token'ı olan müşteri yoksa, ilk müşteriyi ana müşteri olarak al
                    if (mainCustomer == null)
                        mainCustomer = group.First();

                    // Ana müşterinin rezervasyonu
                    var mainRes = context.Reservations
                        .Where(r => r.CustomerId == mainCustomer.Id)
                        .OrderByDescending(r => r.Id)
                        .FirstOrDefault();

                    // Gruptaki tüm müşterileri ekle
                    foreach (var customer in group.OrderBy(u => (u.Email == null && u.SelectionToken == null) ? 1 : 0)) // Önce ana müşteri, sonra ekstra kişiler
                    {
                        customers.Add(new
                        {
                            Id = customer.Id,
                            Username = customer.Username, // TC
                            Name = customer.Name,
                            Surname = customer.Surname,
                            Email = customer.Email,
                            Phone = customer.Phone,
                            LicensePlate = customer.LicensePlate,
                            SelectionToken = customer.SelectionToken,
                            // Room Info (ana müşterinin rezervasyonu kullan)
                            RoomNumber = mainRes != null ? mainRes.Room.RoomNumber : "Seçilmedi",
                            Floor = mainRes != null ? mainRes.Room.Floor.ToString() : "-",
                            // Kaç gün kalacakları bilgisi
                            StayDays = customer.StayDays.HasValue ? customer.StayDays.Value.ToString() + " Gün" : "-",
                            // Grup bilgisi
                            GroupId = group.Key,
                            IsMainCustomer = customer.Id == mainCustomer.Id,
                            GroupSize = group.Count()
                        });
                    }
                }

                gridControlCustomers.DataSource = customers;
                gridViewCustomers.PopulateColumns();

                // Hide sensitive or irrelevant columns for Customers
                string[] hideCols = { "Id", "SelectionToken", "GroupId", "IsMainCustomer", "GroupSize" };
                foreach (var col in hideCols)
                {
                    if (gridViewCustomers.Columns[col] != null) gridViewCustomers.Columns[col].Visible = false;
                }

                // Captions
                if(gridViewCustomers.Columns["Username"] != null) { 
                    gridViewCustomers.Columns["Username"].Caption = "T.C. Kimlik No"; 
                    gridViewCustomers.Columns["Username"].VisibleIndex = 0; 
                }
                if(gridViewCustomers.Columns["Name"] != null) gridViewCustomers.Columns["Name"].Caption = "Ad";
                if(gridViewCustomers.Columns["Surname"] != null) gridViewCustomers.Columns["Surname"].Caption = "Soyad";
                if(gridViewCustomers.Columns["Email"] != null) gridViewCustomers.Columns["Email"].Caption = "E-Posta";
                if(gridViewCustomers.Columns["Phone"] != null) gridViewCustomers.Columns["Phone"].Caption = "Telefon";
                if(gridViewCustomers.Columns["LicensePlate"] != null) gridViewCustomers.Columns["LicensePlate"].Caption = "Plaka";
                
                // New Columns
                if(gridViewCustomers.Columns["RoomNumber"] != null) {
                    gridViewCustomers.Columns["RoomNumber"].Caption = "Oda No";
                    gridViewCustomers.Columns["RoomNumber"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                }
                if(gridViewCustomers.Columns["Floor"] != null) {
                    gridViewCustomers.Columns["Floor"].Caption = "Kat";
                    gridViewCustomers.Columns["Floor"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                }
                if(gridViewCustomers.Columns["StayDays"] != null) {
                    gridViewCustomers.Columns["StayDays"].Caption = "Kaç Gün Kalacak";
                    gridViewCustomers.Columns["StayDays"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                }

                // RowStyle ve CustomDrawCell event'lerini ekle (gruplu müşterileri altın çerçeve ile göster)
                gridViewCustomers.RowStyle -= GridViewCustomers_RowStyle;
                gridViewCustomers.RowStyle += GridViewCustomers_RowStyle;
                gridViewCustomers.CustomDrawCell -= GridViewCustomers_CustomDrawCell;
                gridViewCustomers.CustomDrawCell += GridViewCustomers_CustomDrawCell;

                gridViewCustomers.BestFitColumns();
            }
        }

        private void GridViewCustomers_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            var view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            if (view == null || e.RowHandle < 0) return;

            var row = view.GetRow(e.RowHandle);
            if (row == null) return;

            // Reflection ile GroupSize al
            var groupSize = (int?)row.GetType().GetProperty("GroupSize")?.GetValue(row);

            // Eğer grup 1'den fazla kişi içeriyorsa, altın çerçeve göster
            if (groupSize.HasValue && groupSize.Value > 1)
            {
                // Altın kenarlık için Appearance ayarla
                e.Appearance.BorderColor = Color.Gold;
            }
        }

        private void GridViewCustomers_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            var view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            if (view == null || e.RowHandle < 0) return;

            var row = view.GetRow(e.RowHandle);
            if (row == null) return;

            // Reflection ile GroupSize ve GroupId al
            var groupSize = (int?)row.GetType().GetProperty("GroupSize")?.GetValue(row);
            var groupId = row.GetType().GetProperty("GroupId")?.GetValue(row);

            // Eğer grup 1'den fazla kişi içeriyorsa, altın kenarlık çiz
            if (groupSize.HasValue && groupSize.Value > 1 && groupId != null)
            {
                // İlk sütunda sol kenarlık, son sütunda sağ kenarlık çiz
                bool isFirstColumn = e.Column?.VisibleIndex == 0;
                bool isLastColumn = e.Column?.VisibleIndex == view.VisibleColumns.Count - 1;

                // Önceki ve sonraki satırların GroupId'sini kontrol et
                var prevRow = e.RowHandle > 0 ? view.GetRow(e.RowHandle - 1) : null;
                var nextRow = e.RowHandle < view.RowCount - 1 ? view.GetRow(e.RowHandle + 1) : null;
                
                var prevGroupId = prevRow != null ? prevRow.GetType().GetProperty("GroupId")?.GetValue(prevRow) : null;
                var nextGroupId = nextRow != null ? nextRow.GetType().GetProperty("GroupId")?.GetValue(nextRow) : null;

                using (var pen = new Pen(Color.Gold, 2))
                {
                    // Üst kenarlık (önceki satır farklı grup ise veya ilk satır ise)
                    if (e.RowHandle == 0 || prevGroupId == null || !prevGroupId.Equals(groupId))
                    {
                        e.Graphics.DrawLine(pen, e.Bounds.Left, e.Bounds.Top, e.Bounds.Right, e.Bounds.Top);
                    }

                    // Alt kenarlık (sonraki satır farklı grup ise veya son satır ise)
                    if (e.RowHandle == view.RowCount - 1 || nextGroupId == null || !nextGroupId.Equals(groupId))
                    {
                        e.Graphics.DrawLine(pen, e.Bounds.Left, e.Bounds.Bottom - 1, e.Bounds.Right, e.Bounds.Bottom - 1);
                    }

                    // Sol kenarlık (sadece ilk sütunda)
                    if (isFirstColumn)
                    {
                        e.Graphics.DrawLine(pen, e.Bounds.Left, e.Bounds.Top, e.Bounds.Left, e.Bounds.Bottom);
                    }

                    // Sağ kenarlık (sadece son sütunda)
                    if (isLastColumn)
                    {
                        e.Graphics.DrawLine(pen, e.Bounds.Right - 1, e.Bounds.Top, e.Bounds.Right - 1, e.Bounds.Bottom);
                    }
                }
            }
        }

        private void btnUpdateCustomer_Click(object sender, EventArgs e)
        {
            // Anonymous type binding handling
            // We need to get Id from the focused row
            var row = gridViewCustomers.GetFocusedRow();
            if (row == null) return;
            
            // Because it's an anonymous type, we use reflection or dynamic
            int id = 0;
            try { 
                id = (int)row.GetType().GetProperty("Id").GetValue(row, null);
            } catch { return; }

            using (var form = new CustomerRegistrationForm(id))
            {
                if (form.ShowDialog() == DialogResult.OK)
                    LoadCustomers();
            }
        }

        private void btnResendMail_Click(object sender, EventArgs e)
        {
             var row = gridViewCustomers.GetFocusedRow();
             if (row == null) return;

             string name = "";
             string surname = "";
             string email = "";
             string tokenStr = "";

             try {
                name = (string)row.GetType().GetProperty("Name").GetValue(row, null);
                surname = (string)row.GetType().GetProperty("Surname").GetValue(row, null);
                email = (string)row.GetType().GetProperty("Email").GetValue(row, null);
                var tokenObj = row.GetType().GetProperty("SelectionToken").GetValue(row, null);
                tokenStr = tokenObj != null ? tokenObj.ToString() : "";
             } catch { return; }

             if(string.IsNullOrEmpty(email))
             {
                 XtraMessageBox.Show("Müşterinin E-Posta adresi kayıtlı değil.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 return;
             }
             if(string.IsNullOrEmpty(tokenStr))
             {
                 XtraMessageBox.Show("Geçersiz Token. Lütfen müşteriyi düzenleyerek yeni bir işlem yapın.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 return;
             }

             if(XtraMessageBox.Show($"{name} {surname} kişisine oda seçim linki tekrar gönderilsin mi?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
             {
                 var mailService = new MailService();
                 var result = mailService.SendRoomSelectionEmail($"{name} {surname}", email, tokenStr);

                 if (result.success)
                     XtraMessageBox.Show("Mail başarıyla gönderildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 else
                     XtraMessageBox.Show($"Mail gönderilemedi. Hata: {result.errorMessage}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
        }
    }
}
