using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using OtelOtomasyonu.Services;
using System.Linq;

namespace OtelOtomasyonu.Forms
{
    public partial class StaffForm : XtraForm
    {
        private readonly StaffService _staffService;

        public StaffForm()
        {
            InitializeComponent();
            _staffService = new StaffService();
            
            // Fix Whiteness: Disable Default Skinning for this form's controls if needed
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.LookAndFeel.SkinName = "DevExpress Dark Style"; // Attempt dark skin or just manual style
            
            LoadStaff();
            ApplyTheme();
            AddDummyDataIfEmpty();
        }

        private void AddDummyDataIfEmpty()
        {
            using (var context = new OtelOtomasyonu.Data.HotelContext())
            {
                if (!context.Users.Any(u => u.Role == OtelOtomasyonu.Data.Entities.UserRole.Staff))
                {
                    // Add one dummy for each department
                    var depts = Enum.GetValues(typeof(OtelOtomasyonu.Data.Entities.Department));
                    foreach (OtelOtomasyonu.Data.Entities.Department d in depts)
                    {
                        context.Users.Add(new OtelOtomasyonu.Data.Entities.User
                        {
                            Name = "Örnek",
                            Surname = "Personel",
                            Username = $"user_{d}",
                            Password = "123",
                            Role = OtelOtomasyonu.Data.Entities.UserRole.Staff,
                            Department = d,
                            JobTitle = "Personel",
                            Salary = 17002,
                            WorkHours = "09:00 - 18:00",
                            Phone = "555-0000",
                            Email = "info@otel.com"
                        });
                    }
                    context.SaveChanges();
                    LoadStaff(); // Reload grid
                }
            }
        }

        private void ApplyTheme()
        {
            // Set Black Background
            this.Appearance.BackColor = System.Drawing.Color.Black;
            this.Appearance.Options.UseBackColor = true;
            
            // Grid Styling (FindPanel styling removed as it's not supported in this version/context)
            // gridView1.Appearance.FindPanel.BackColor = System.Drawing.Color.Black;
            // gridView1.Appearance.FindPanel.ForeColor = System.Drawing.Color.Gold;
            
            // Handle Custom Text for Enums
            gridView1.CustomColumnDisplayText += GridView1_CustomColumnDisplayText;
            
            // Interaction
            gridView1.DoubleClick += gridView1_DoubleClick;
        }

        private void GridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "Department" && e.Value != null)
            {
                string enumName = e.Value.ToString();
                switch (enumName)
                {
                    case "FrontOffice": e.DisplayText = "Ön Büro"; break;
                    case "Housekeeping": e.DisplayText = "Kat Hizmetleri"; break;
                    case "FoodAndBeverage": e.DisplayText = "Yiyecek ve İçecek"; break;
                    case "BackOffice": e.DisplayText = "Yönetim ve İdari"; break;
                    case "TechnicalAndSecurity": e.DisplayText = "Teknik Servis ve Güvenlik"; break;
                }
            }
        }

        private void LoadStaff()
        {
            try
            {
                // Force refresh by clearing source first
                gridControl1.DataSource = null;
                gridControl1.DataSource = _staffService.GetAllStaff();
                gridView1.RefreshData();
                
                // Configure GridView (Columns, Grouping)
                gridView1.PopulateColumns();
                
                // Hide unwanted
                if(gridView1.Columns["Password"] != null) gridView1.Columns["Password"].Visible = false;
                if(gridView1.Columns["ProfilePicturePath"] != null) gridView1.Columns["ProfilePicturePath"].Visible = false;
                if(gridView1.Columns["Role"] != null) gridView1.Columns["Role"].Visible = false;
                if(gridView1.Columns["Id"] != null) gridView1.Columns["Id"].Visible = false;
                if(gridView1.Columns["LastLoginDate"] != null) gridView1.Columns["LastLoginDate"].Visible = false;

                // Group by Department by default
                if(gridView1.Columns["Department"] != null)
                {
                    gridView1.Columns["Department"].GroupIndex = 0; 
                    gridView1.Columns["Department"].Caption = "Departman";
                }

                // Rename Columns
                if(gridView1.Columns["Username"] != null) gridView1.Columns["Username"].Caption = "Kullanıcı Adı";
                if(gridView1.Columns["Name"] != null) gridView1.Columns["Name"].Caption = "Ad";
                if(gridView1.Columns["Surname"] != null) gridView1.Columns["Surname"].Caption = "Soyad";
                if(gridView1.Columns["JobTitle"] != null) gridView1.Columns["JobTitle"].Caption = "Görev";
                if(gridView1.Columns["Salary"] != null) gridView1.Columns["Salary"].Caption = "Maaş";
                if(gridView1.Columns["WorkHours"] != null) gridView1.Columns["WorkHours"].Caption = "Çalışma Saati";
                if(gridView1.Columns["Email"] != null) gridView1.Columns["Email"].Caption = "E-Posta";
                if(gridView1.Columns["Phone"] != null) gridView1.Columns["Phone"].Caption = "Telefon";

                gridView1.ExpandAllGroups();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Personel listesi yüklenirken hata: " + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Open separate Add Form
            using (var addForm = new StaffAddForm())
            {
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    LoadStaff(); // Refresh grid
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var view = gridView1;
            if (view.FocusedRowHandle < 0) return;

            // Get ID safely (Column name might vary if EF changes, but usually "Id")
            object idVal = view.GetRowCellValue(view.FocusedRowHandle, "Id");
            if (idVal == null) return;
            
            int id = (int)idVal;
            string name = (string)view.GetRowCellValue(view.FocusedRowHandle, "Name") ?? "Personel";

            if (XtraMessageBox.Show($"{name} adlı personeli silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    _staffService.DeleteStaff(id);
                    LoadStaff();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            ShowSelectedProfile();
        }

        private void ShowSelectedProfile()
        {
            var view = gridView1;
            if (view.FocusedRowHandle < 0) return;

            object idVal = view.GetRowCellValue(view.FocusedRowHandle, "Id");
            if (idVal == null) return;
            
            // Open Profile Form for this user
            using (var profile = new ProfileForm((int)idVal))
            {
                profile.ShowDialog();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
             var view = gridView1;
             if (view.FocusedRowHandle < 0) return;

             object idVal = view.GetRowCellValue(view.FocusedRowHandle, "Id");
             if (idVal == null) return;

             // Open Edit Form
             using (var editForm = new StaffAddForm((int)idVal))
             {
                 if (editForm.ShowDialog() == DialogResult.OK)
                 {
                     LoadStaff(); // Refresh
                 }
             }
        }
    }
}
