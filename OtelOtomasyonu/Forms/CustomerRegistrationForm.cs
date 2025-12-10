using System;
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
        public CustomerRegistrationForm()
        {
            InitializeComponent();
        }

        private async void btnRegister_Click(object sender, EventArgs e)
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

            // Generate Random Password
            string password = GenerateRandomPassword();

            try
            {
                using (var context = new HotelContext())
                {
                    // Check if user exists
                    if (context.Users.Any(u => u.Username == tc))
                    {
                        XtraMessageBox.Show("Bu T.C. numarası ile zaten bir kayıt mevcut.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var newCustomer = new User
                    {
                        Username = tc, // Using TC as username
                        Password = password,
                        Role = UserRole.Customer,
                        Name = name,
                        Surname = surname,
                        Email = email,
                        Phone = phone,
                        LicensePlate = plate
                    };

                    context.Users.Add(newCustomer);
                    context.SaveChanges();

                    // Send Notifications (Graceful Handling)
                    try
                    {
                        using (var notificationService = new Services.NotificationService())
                        {
                            string message = $"Sayın {name} {surname}, Otelimize hoşgeldiniz. Giriş şifreniz: {password}";
                            
                            // Simulate Email
                            if (!string.IsNullOrEmpty(email))
                            {
                                await notificationService.SendEmailAsync(email, "Otel Kayıt Bilgileri", message);
                            }
                            
                            // Simulate SMS
                            if (!string.IsNullOrEmpty(phone))
                            {
                                await notificationService.SendSmsAsync(phone, message);
                            }
                        }
                        XtraMessageBox.Show($"Müşteri Kaydı Başarılı!\n\nSayın {name} {surname}\nKullanıcı Adınız (T.C.): {tc}\nŞifreniz: {password}\n\n(Şifre müşterinin E-posta ve Telefonuna gönderildi.)", "Kayıt Tamamlandı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception notifyEx)
                    {
                        XtraMessageBox.Show($"Müşteri kaydedildi ancak bildirim gönderilemedi.\n\nHata: {notifyEx.Message}\n\nLütfen şifreyi müşteriye manuel iletin:\nSayın {name} {surname}\nKullanıcı Adı: {tc}\nŞifre: {password}", "Bildirim Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Kayıt sırasında hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private string GenerateRandomPassword(int length = 8)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
