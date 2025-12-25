using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using OtelOtomasyonu.Data;
using OtelOtomasyonu.Data.Entities;
using System.Threading.Tasks;

namespace OtelOtomasyonu.Forms
{
    public partial class CustomerRegistrationForm : XtraForm
    {
        private int? _customerId = null;
        private List<GuestInfoPanel> _additionalGuestPanels = new List<GuestInfoPanel>();
        
        // Ekstra kişi bilgileri için panel sınıfı
        private class GuestInfoPanel
        {
            public System.Windows.Forms.Panel Panel { get; set; }
            public DevExpress.XtraEditors.LabelControl LblTitle { get; set; }
            public DevExpress.XtraEditors.TextEdit TxtName { get; set; }
            public DevExpress.XtraEditors.TextEdit TxtSurname { get; set; }
            public DevExpress.XtraEditors.TextEdit TxtTC { get; set; }
            public DevExpress.XtraEditors.TextEdit TxtPhone { get; set; }
        }

        // Default constructor for New Customer
        public CustomerRegistrationForm()
        {
            InitializeComponent();
            SetupAdditionalGuestsPanel();
            // Default değeri ayarla
            if (numStayDays != null)
            {
                numStayDays.EditValue = 1;
            }
        }

        // Constructor for Editing
        public CustomerRegistrationForm(int customerId)
        {
            InitializeComponent();
            _customerId = customerId;
            this.Text = "Müşteri Düzenle";
            btnRegister.Text = "Güncelle";
            // Edit modunda kişi sayısı değiştirilemez
            cmbGuestCount.Enabled = false;
            pnlAdditionalGuests.Visible = false;
            LoadCustomer(customerId);
        }

        private void LoadCustomer(int id)
        {
            try
            {
                using (var context = new HotelContext())
                {
                    var customer = context.Users.Find(id);
                    if (customer != null)
                    {
                        txtName.Text = customer.Name;
                        txtSurname.Text = customer.Surname;
                        txtTC.Text = customer.Username; // TC is Username
                        txtPhone.Text = customer.Phone;
                        txtEmail.Text = customer.Email;
                        txtPlate.Text = customer.LicensePlate;
                        
                        if (!string.IsNullOrEmpty(customer.LicensePlate))
                        {
                            chkHasVehicle.Checked = true;
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Müşteri bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Müşteri bilgileri yüklenirken hata: " + ex.Message);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string surname = txtSurname.Text.Trim();
            string tc = txtTC.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string email = txtEmail.Text.Trim();
            string plate = txtPlate.Text.Trim();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(surname) || string.IsNullOrEmpty(tc))
            {
                XtraMessageBox.Show("Lütfen Ad, Soyad ve T.C. alanlarını doldurunuz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tc.Length != 11 || !tc.All(char.IsDigit))
            {
                XtraMessageBox.Show("T.C. Kimlik Numarası 11 haneli ve sadece rakamlardan oluşmalıdır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!string.IsNullOrEmpty(phone) && (!phone.All(char.IsDigit) || phone.Length < 10))
            {
                XtraMessageBox.Show("Telefon numarası sadece rakamlardan oluşmalı ve geçerli uzunlukta olmalıdır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Generate Random Password or keep existing if editing
            string password = GenerateRandomPassword();

            try
            {
                using (var context = new HotelContext())
                {
                    // Check if TC exists (Standard Check)
                    var existingUser = context.Users.FirstOrDefault(u => u.Username == tc);

                    if (_customerId.HasValue)
                    {
                        // UPDATE LOGIC
                        if (existingUser != null && existingUser.Id != _customerId.Value)
                        {
                            XtraMessageBox.Show("Bu T.C. numarası ile zaten başka bir kayıt mevcut.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        var customerToUpdate = context.Users.Find(_customerId.Value);
                        if (customerToUpdate != null)
                        {
                            customerToUpdate.Username = tc;
                            customerToUpdate.Name = name;
                            customerToUpdate.Surname = surname;
                            customerToUpdate.Email = email;
                            customerToUpdate.Phone = phone;
                            customerToUpdate.LicensePlate = plate;
                            
                            context.SaveChanges();
                            XtraMessageBox.Show("Müşteri bilgileri güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }
                    else
                    {
                        // CREATE LOGIC
                        if (existingUser != null)
                        {
                            XtraMessageBox.Show("Bu T.C. numarası ile zaten bir kayıt mevcut.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Kişi sayısını al
                        int guestCount = 1;
                        if (cmbGuestCount.SelectedItem != null && int.TryParse(cmbGuestCount.SelectedItem.ToString(), out int count))
                        {
                            guestCount = count;
                        }

                        // Tüm TC'leri kontrol et (ana + ekstra kişiler)
                        var allTCs = new List<string> { tc };
                        foreach (var guestPanel in _additionalGuestPanels)
                        {
                            string guestTC = guestPanel.TxtTC.Text.Trim();
                            if (!string.IsNullOrEmpty(guestTC))
                            {
                                if (allTCs.Contains(guestTC))
                                {
                                    XtraMessageBox.Show("Aynı T.C. numarası birden fazla kişi için kullanılamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                allTCs.Add(guestTC);
                                
                                // TC format kontrolü
                                if (guestTC.Length != 11 || !guestTC.All(char.IsDigit))
                                {
                                    XtraMessageBox.Show($"{guestPanel.LblTitle.Text} için T.C. Kimlik Numarası 11 haneli ve sadece rakamlardan oluşmalıdır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }

                                // Mevcut TC kontrolü
                                var existingGuestTC = context.Users.FirstOrDefault(u => u.Username == guestTC);
                                if (existingGuestTC != null)
                                {
                                    XtraMessageBox.Show($"{guestPanel.LblTitle.Text} için bu T.C. numarası ile zaten bir kayıt mevcut.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                        }

                        var token = Guid.NewGuid();
                        var groupId = Guid.NewGuid(); // Aynı kayıt ekranında kaydedilen tüm müşteriler için ortak grup ID
                        var allCustomers = new List<User>();

                        // Kaç gün kalacakları bilgisini al
                        int stayDays = 1;
                        if (numStayDays != null)
                        {
                            var value = numStayDays.EditValue;
                            if (value != null)
                            {
                                if (int.TryParse(value.ToString(), out int days) && days > 0)
                                {
                                    stayDays = days;
                                }
                            }
                        }

                        // Ana müşteri
                        var newCustomer = new User
                        {
                            Username = tc,
                            Password = password,
                            Role = UserRole.Customer,
                            Name = name,
                            Surname = surname,
                            Email = email,
                            Phone = phone,
                            LicensePlate = plate,
                            SelectionToken = token, // Sadece ana müşteriye token ver
                            RegistrationGroupId = groupId, // Grup ID'si
                            StayDays = stayDays // Kaç gün kalacakları
                        };
                        allCustomers.Add(newCustomer);
                        context.Users.Add(newCustomer);

                        // Ekstra kişiler
                        foreach (var guestPanel in _additionalGuestPanels)
                        {
                            string guestName = guestPanel.TxtName.Text.Trim();
                            string guestSurname = guestPanel.TxtSurname.Text.Trim();
                            string guestTC = guestPanel.TxtTC.Text.Trim();
                            string guestPhone = guestPanel.TxtPhone.Text.Trim();

                            // Zorunlu alan kontrolü
                            if (string.IsNullOrEmpty(guestName) || string.IsNullOrEmpty(guestSurname) || string.IsNullOrEmpty(guestTC))
                            {
                                XtraMessageBox.Show($"{guestPanel.LblTitle.Text} için Ad, Soyad ve T.C. alanları zorunludur.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            // Telefon format kontrolü
                            if (!string.IsNullOrEmpty(guestPhone) && (!guestPhone.All(char.IsDigit) || guestPhone.Length < 10))
                            {
                                XtraMessageBox.Show($"{guestPanel.LblTitle.Text} için telefon numarası sadece rakamlardan oluşmalı ve geçerli uzunlukta olmalıdır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            var additionalGuest = new User
                            {
                                Username = guestTC,
                                Password = GenerateRandomPassword(), // Her kişiye ayrı şifre
                                Role = UserRole.Customer,
                                Name = guestName,
                                Surname = guestSurname,
                                Email = null, // Ekstra kişilerin maili yok
                                Phone = guestPhone,
                                LicensePlate = null, // Sadece ana müşterinin plakası
                                SelectionToken = null, // Sadece ana müşteriye token
                                RegistrationGroupId = groupId, // Aynı grup ID'si
                                StayDays = stayDays // Aynı gün sayısı
                            };
                            allCustomers.Add(additionalGuest);
                            context.Users.Add(additionalGuest);
                        }

                        context.SaveChanges();

                        // Send Notifications (Graceful Handling)
                        try
                        {
                            using (var notificationService = new Services.NotificationService())
                            {
                                string message = $"Sayın {name} {surname}, Otelimize hoşgeldiniz. Giriş şifreniz: {password}";
                                
                                // 1. Send Room Selection Email (Priority)
                                if (!string.IsNullOrEmpty(email))
                                {
                                    var mailService = new Services.MailService();
                                    var result = mailService.SendRoomSelectionEmail($"{name} {surname}", email, token.ToString());
                                    
                                    if (!result.success)
                                        XtraMessageBox.Show($"Mail gönderilemedi. Hata Detayı: {result.errorMessage}", "Mail Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                
                                // 2. Simulate SMS - DISABLED per user request
                                /* if (!string.IsNullOrEmpty(phone))
                                {
                                    await notificationService.SendSmsAsync(phone, message);
                                } */
                            }
                            
                            string successMessage = $"Müşteri Kaydı Başarılı!\n\n";
                            if (guestCount > 1)
                            {
                                successMessage += $"Toplam {guestCount} kişi kaydedildi:\n";
                                successMessage += $"• {name} {surname} (Ana Müşteri)\n";
                                foreach (var guestPanel in _additionalGuestPanels)
                                {
                                    successMessage += $"• {guestPanel.TxtName.Text.Trim()} {guestPanel.TxtSurname.Text.Trim()}\n";
                                }
                                successMessage += $"\nOda seçim linki sadece ana müşterinin e-postasına gönderildi:\n{email}\n";
                            }
                            else
                            {
                                successMessage += $"Sayın {name} {surname}\n\n";
                                successMessage += $"Link şu adrese gönderildi:\n{email}\n";
                            }
                            successMessage += "\nLütfen Gereksiz/Spam kutusunu da kontrol edin.";
                            
                            XtraMessageBox.Show(successMessage, "Kayıt ve Davet Tamamlandı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception notifyEx)
                        {
                            XtraMessageBox.Show($"Müşteri kaydedildi ancak bildirim hatası: {notifyEx.Message}", "Bildirim Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("İşlem sırasında hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkHasVehicle_CheckedChanged(object sender, EventArgs e)
        {
            bool hasVehicle = chkHasVehicle.Checked;
            lblPlate.Visible = hasVehicle;
            txtPlate.Visible = hasVehicle;
            if (!hasVehicle)
            {
                txtPlate.Text = "";
            }
        }

        private void SetupAdditionalGuestsPanel()
        {
            // İlk yüklemede ekstra kişi paneli gizli
            pnlAdditionalGuests.Visible = false;
        }

        private void cmbGuestCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            int guestCount = 1;
            if (cmbGuestCount.SelectedItem != null && int.TryParse(cmbGuestCount.SelectedItem.ToString(), out int count))
            {
                guestCount = count;
            }

            // Ekstra kişi sayısı (ana müşteri hariç)
            int additionalCount = guestCount - 1;

            // Mevcut panelleri temizle
            foreach (var panel in _additionalGuestPanels)
            {
                pnlAdditionalGuests.Controls.Remove(panel.Panel);
                panel.Panel.Dispose();
            }
            _additionalGuestPanels.Clear();

            // Ekstra kişi varsa paneli göster ve alanları oluştur
            if (additionalCount > 0)
            {
                pnlAdditionalGuests.Visible = true;
                pnlAdditionalGuests.Controls.Clear();

                System.Drawing.Font lblFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
                System.Drawing.Color goldColor = System.Drawing.Color.Gold;
                int startY = 10;
                int panelHeight = 120;
                int spacing = 10;

                for (int i = 0; i < additionalCount; i++)
                {
                    var guestPanel = new GuestInfoPanel();
                    var panel = new System.Windows.Forms.Panel();
                    panel.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
                    panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    panel.Location = new System.Drawing.Point(10, startY + i * (panelHeight + spacing));
                    panel.Size = new System.Drawing.Size(720, panelHeight);

                    // Başlık
                    var lblTitle = new DevExpress.XtraEditors.LabelControl();
                    lblTitle.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
                    lblTitle.Appearance.ForeColor = goldColor;
                    lblTitle.Location = new System.Drawing.Point(10, 10);
                    lblTitle.Text = $"{i + 2}. Kişi Bilgileri:";
                    lblTitle.Size = new System.Drawing.Size(200, 20);

                    // Ad
                    var lblName = new DevExpress.XtraEditors.LabelControl();
                    lblName.Appearance.Font = lblFont;
                    lblName.Appearance.ForeColor = goldColor;
                    lblName.Location = new System.Drawing.Point(10, 40);
                    lblName.Text = "Ad:";
                    var txtName = new DevExpress.XtraEditors.TextEdit();
                    txtName.Location = new System.Drawing.Point(120, 37);
                    txtName.Size = new System.Drawing.Size(150, 24);

                    // Soyad
                    var lblSurname = new DevExpress.XtraEditors.LabelControl();
                    lblSurname.Appearance.Font = lblFont;
                    lblSurname.Appearance.ForeColor = goldColor;
                    lblSurname.Location = new System.Drawing.Point(280, 40);
                    lblSurname.Text = "Soyad:";
                    var txtSurname = new DevExpress.XtraEditors.TextEdit();
                    txtSurname.Location = new System.Drawing.Point(360, 37);
                    txtSurname.Size = new System.Drawing.Size(150, 24);

                    // TC
                    var lblTC = new DevExpress.XtraEditors.LabelControl();
                    lblTC.Appearance.Font = lblFont;
                    lblTC.Appearance.ForeColor = goldColor;
                    lblTC.Location = new System.Drawing.Point(10, 75);
                    lblTC.Text = "T.C. / Pasaport:";
                    var txtTC = new DevExpress.XtraEditors.TextEdit();
                    txtTC.Location = new System.Drawing.Point(120, 72);
                    txtTC.Size = new System.Drawing.Size(150, 24);

                    // Telefon
                    var lblPhone = new DevExpress.XtraEditors.LabelControl();
                    lblPhone.Appearance.Font = lblFont;
                    lblPhone.Appearance.ForeColor = goldColor;
                    lblPhone.Location = new System.Drawing.Point(280, 75);
                    lblPhone.Text = "Telefon:";
                    var txtPhone = new DevExpress.XtraEditors.TextEdit();
                    txtPhone.Location = new System.Drawing.Point(360, 72);
                    txtPhone.Size = new System.Drawing.Size(150, 24);

                    // Kontrolleri panele ekle
                    panel.Controls.Add(lblTitle);
                    panel.Controls.Add(lblName);
                    panel.Controls.Add(txtName);
                    panel.Controls.Add(lblSurname);
                    panel.Controls.Add(txtSurname);
                    panel.Controls.Add(lblTC);
                    panel.Controls.Add(txtTC);
                    panel.Controls.Add(lblPhone);
                    panel.Controls.Add(txtPhone);

                    guestPanel.Panel = panel;
                    guestPanel.LblTitle = lblTitle;
                    guestPanel.TxtName = txtName;
                    guestPanel.TxtSurname = txtSurname;
                    guestPanel.TxtTC = txtTC;
                    guestPanel.TxtPhone = txtPhone;

                    pnlAdditionalGuests.Controls.Add(panel);
                    _additionalGuestPanels.Add(guestPanel);
                }

                // Panel yüksekliğini ayarla
                pnlAdditionalGuests.Height = Math.Min(400, startY + additionalCount * (panelHeight + spacing) + 20);
            }
            else
            {
                pnlAdditionalGuests.Visible = false;
            }

            // Buton pozisyonunu güncelle
            int buttonY = pnlAdditionalGuests.Visible ? pnlAdditionalGuests.Bottom + 20 : pnlMainGuest.Bottom + 20;
            btnRegister.Location = new System.Drawing.Point(300, buttonY);
        }

        private string GenerateRandomPassword(int length = 8)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
