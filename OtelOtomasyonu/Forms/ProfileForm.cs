using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using OtelOtomasyonu.Data;
using OtelOtomasyonu.Services;

namespace OtelOtomasyonu.Forms
{
    public partial class ProfileForm : XtraForm
    {
        private int _userId;

        public ProfileForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None; // Remove Purple Border
            
            // Allow Dragging
            this.MouseDown += (s, e) => { if (e.Button == MouseButtons.Left) { ReleaseCapture(); SendMessage(Handle, 0xA1, 0x2, 0); } };
            panelLeft.MouseDown += (s, e) => { if (e.Button == MouseButtons.Left) { ReleaseCapture(); SendMessage(Handle, 0xA1, 0x2, 0); } };
            
            // Add Custom Close Button
            SimpleButton btnClose = new SimpleButton();
            btnClose.Text = "X";
            btnClose.Size = new Size(30, 30);
            btnClose.Location = new Point(this.Width - 35, 5);
            btnClose.Appearance.BackColor = Color.Black;     // Changed to Black
            btnClose.Appearance.ForeColor = Color.Gold;      // Changed to Gold
            btnClose.Appearance.Font = new Font("Segoe UI", 12f, FontStyle.Bold);
            btnClose.Appearance.BorderColor = Color.Gold;
            btnClose.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple; // Visible border
            btnClose.Click += (s, e) => this.Close();
            this.Controls.Add(btnClose);
            btnClose.BringToFront();

            SetupTheme();

            // Load User Data
            this.Shown += (s, e) => LoadData();

            // Event Wiring
            btnSave.Click += BtnSave_Click;
            btnUpdatePass.Click += BtnUpdatePass_Click;
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void SetupTheme()
        {
            // DISABLE SKINS
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            
            // Load Background (Minimalist)
            try 
            {
                string bgPath = System.IO.Path.Combine(Application.StartupPath, "admin_bg_gold_minimal.png");
                if (System.IO.File.Exists(bgPath))
                {
                    this.BackgroundImageLayout = ImageLayout.Stretch;
                    this.BackgroundImage = Image.FromFile(bgPath);
                }
                else
                {
                    this.BackColor = Color.Black;
                }
            } 
            catch {}

            // FIX GHOSTING: Use Solid Black for Content Panels
            // Transparency causes text blurring/ghosting in WinForms.
            // We keep the main form background as marble, but panels will be Opaque Black.
            
            splitContainerControl1.Panel1.Appearance.BackColor = Color.Black; 
            splitContainerControl1.Panel2.Appearance.BackColor = Color.Black; 
            
            xtraTabControl1.Appearance.BackColor = Color.Black;
            xtraTabControl1.AppearancePage.Header.BackColor = Color.Black;
            xtraTabControl1.AppearancePage.Header.ForeColor = Color.Gold;
            xtraTabControl1.AppearancePage.HeaderActive.BackColor = Color.Gold;
            xtraTabControl1.AppearancePage.HeaderActive.ForeColor = Color.Black;
            xtraTabControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            xtraTabControl1.BorderStylePage = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;

            // Inner Panels - MUST BE BLACK for readability
            tabPersonalInfo.Appearance.PageClient.BackColor = Color.Black;
            tabPersonalInfo.Appearance.PageClient.Options.UseBackColor = true;
            panelPersonal.Appearance.BackColor = Color.Black;
            panelPersonal.Appearance.Options.UseBackColor = true;
            panelPersonal.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;

            tabSecurity.Appearance.PageClient.BackColor = Color.Black;
            tabSecurity.Appearance.PageClient.Options.UseBackColor = true;
            panelSecurity.Appearance.BackColor = Color.Black;
            panelSecurity.Appearance.Options.UseBackColor = true;
            panelSecurity.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;

            // Update Label Colors
            UpdateLabelColors(panelPersonal);
            UpdateLabelColors(panelSecurity);
            UpdateLabelColors(panelLeft);

            // Style TextBoxes (Remove White)
            StyleTextBox(txtUsername);
            StyleTextBox(txtName);
            StyleTextBox(txtSurname);
            StyleTextBox(txtPhone);
            StyleTextBox(txtEmail);
            StyleTextBox(txtPlate);
            StyleTextBox(txtOldPass);
            StyleTextBox(txtNewPass);
            StyleTextBox(txtConfirmPass);
        }

        private void StyleTextBox(TextEdit txt)
        {
            txt.Properties.Appearance.BackColor = Color.Black;
            txt.Properties.Appearance.ForeColor = Color.Gold;
            txt.Properties.Appearance.Font = new Font("Segoe UI", 11f);
            txt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            txt.Properties.Appearance.BorderColor = Color.Gold;
            txt.Properties.AppearanceFocused.BorderColor = Color.White;
        }

        private void UpdateLabelColors(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is LabelControl lbl)
                {
                    lbl.Appearance.ForeColor = Color.Gold;
                }
            }
        }

        private void LoadData()
        {
            if (Session.CurrentUser == null)
            {
                XtraMessageBox.Show("Oturum bilgisi bulunamadı. Lütfen tekrar giriş yapın.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            _userId = Session.CurrentUser.Id;

            // Fill Left Card
            lblFullName.Text = $"{Session.CurrentUser.Name} {Session.CurrentUser.Surname}".ToUpper();
            lblRole.Text = Session.CurrentUser.Role.ToString().ToUpper();
            if (Session.CurrentUser.LastLoginDate.HasValue)
                lblLastLogin.Text = "Son Giriş: " + Session.CurrentUser.LastLoginDate.Value.ToString("g");
            else
                lblLastLogin.Text = "Son Giriş: İlk Oturum";

            // Fill Form Fields
            txtUsername.Text = Session.CurrentUser.Username;
            txtName.Text = Session.CurrentUser.Name;
            txtSurname.Text = Session.CurrentUser.Surname;
            txtPhone.Text = Session.CurrentUser.Phone;
            txtEmail.Text = Session.CurrentUser.Email;
            txtPlate.Text = Session.CurrentUser.LicensePlate;

            // Event Wiring
            picProfile.Cursor = Cursors.Hand;
            picProfile.Click += PicProfile_Click;

            // Default Avatar (Robot Icon) or Custom
            if (!string.IsNullOrEmpty(Session.CurrentUser.ProfilePicturePath) && System.IO.File.Exists(Session.CurrentUser.ProfilePicturePath))
            {
                picProfile.Image = Image.FromFile(Session.CurrentUser.ProfilePicturePath);
            }
            else
            {
                string avatarPath = System.IO.Path.Combine(Application.StartupPath, "gold_bot_circle.png");
                if (System.IO.File.Exists(avatarPath))
                    picProfile.Image = Image.FromFile(avatarPath);
            }
            picProfile.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
        }

        private void PicProfile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.bmp";
                ofd.Title = "Profil Fotoğrafı Seç";
                
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try 
                    {
                        // Copy to app directory with unique name
                        string ext = System.IO.Path.GetExtension(ofd.FileName);
                        string newFileName = $"profile_{_userId}_{DateTime.Now.Ticks}{ext}";
                        string destPath = System.IO.Path.Combine(Application.StartupPath, "UserImages");
                        
                        if (!System.IO.Directory.Exists(destPath))
                            System.IO.Directory.CreateDirectory(destPath);
                            
                        string fullDestPath = System.IO.Path.Combine(destPath, newFileName);
                        System.IO.File.Copy(ofd.FileName, fullDestPath, true);

                        // Update UI
                        picProfile.Image = Image.FromFile(fullDestPath);

                        // Save to DB immediately
                        using (var context = new HotelContext())
                        {
                            var user = context.Users.FirstOrDefault(u => u.Id == _userId);
                            if (user != null)
                            {
                                user.ProfilePicturePath = fullDestPath;
                                
                                // Explicitly mark property as modified just in case
                                context.Entry(user).Property(u => u.ProfilePicturePath).IsModified = true;
                                
                                context.SaveChanges();
                                
                                // Update Session
                                Session.CurrentUser.ProfilePicturePath = fullDestPath;
                            }
                        }
                        
                        XtraMessageBox.Show("Profil fotoğrafı güncellendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show("Fotoğraf yüklenirken hata: " + ex.Message);
                    }
                }
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new HotelContext())
                {
                    var user = context.Users.FirstOrDefault(u => u.Id == _userId);
                    if (user != null)
                    {
                        user.Name = txtName.Text;
                        user.Surname = txtSurname.Text;
                        user.Phone = txtPhone.Text;
                        user.Email = txtEmail.Text;
                        user.LicensePlate = txtPlate.Text;
                        // ProfilePicturePath is handled separately in PicProfile_Click

                        context.SaveChanges();

                        // Update Session
                        Session.CurrentUser = user; 
                        
                        // Update Label
                        lblFullName.Text = $"{user.Name} {user.Surname}".ToUpper();

                        XtraMessageBox.Show("Profil bilgileriniz başarıyla güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Kaydetme hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnUpdatePass_Click(object sender, EventArgs e)
        {
            string oldPass = txtOldPass.Text;
            string newPass = txtNewPass.Text;
            string confirmPass = txtConfirmPass.Text;

            if (string.IsNullOrEmpty(oldPass) || string.IsNullOrEmpty(newPass))
            {
                XtraMessageBox.Show("Lütfen tüm alanları doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newPass != confirmPass)
            {
                XtraMessageBox.Show("Yeni şifreler uyuşmuyor.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var context = new HotelContext())
                {
                    var user = context.Users.FirstOrDefault(u => u.Id == _userId);
                    if (user != null)
                    {
                        if (user.Password != oldPass)
                        {
                            XtraMessageBox.Show("Eski şifreniz hatalı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        user.Password = newPass;
                        context.SaveChanges();

                        XtraMessageBox.Show("Şifreniz başarıyla değiştirildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        // Clear fields
                        txtOldPass.Text = "";
                        txtNewPass.Text = "";
                        txtConfirmPass.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Şifre güncelleme hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
