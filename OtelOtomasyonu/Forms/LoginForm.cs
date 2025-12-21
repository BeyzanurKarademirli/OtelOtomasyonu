using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using OtelOtomasyonu.Data;
using OtelOtomasyonu.Data.Entities;
using System.Linq;

namespace OtelOtomasyonu.Forms
{
    public partial class LoginForm : XtraForm
    {


        public LoginForm()
        {
            InitializeComponent();
            SetupWebBrowser();

            
            // Form gösterildiğinde video yükle
            this.Shown += (s, e) => {
                LoadPromoVideo();
                // Video yüklendikten sonra odağı kullanıcı adına ver
                this.BeginInvoke((Action)(() => {
                    txtUsername.Focus();
                }));
            };
        }



        private void SetupWebBrowser()
        {
            // 1. COMPLETELY REMOVE Panels and Logo
            if (panelTop != null) this.Controls.Remove(panelTop);
            if (panelBottom != null) this.Controls.Remove(panelBottom);
            if (pnlGoldAccent != null) this.Controls.Remove(pnlGoldAccent);
            if (picHeaderLogo != null) this.Controls.Remove(picHeaderLogo); 

            // 2. Adjust Video
            if (webBrowserVideo != null)
            {
                webBrowserVideo.Dock = DockStyle.Fill;
                webBrowserVideo.SendToBack(); 
            }

            // 3. Ensure Controls are Visible
            if (txtUsername != null) { this.Controls.Add(txtUsername); txtUsername.BringToFront(); }
            if (txtPassword != null) { this.Controls.Add(txtPassword); txtPassword.BringToFront(); }
            if (btnLogin != null) { this.Controls.Add(btnLogin); btnLogin.BringToFront(); }
            if (chkShowPassword != null) { this.Controls.Add(chkShowPassword); chkShowPassword.BringToFront(); }
            if (btnForgotPassword != null) { this.Controls.Add(btnForgotPassword); btnForgotPassword.BringToFront(); }
            if (lblStatus != null) { this.Controls.Add(lblStatus); lblStatus.BringToFront(); }

            // WebBrowser Settings
            webBrowserVideo.ScriptErrorsSuppressed = true;
            webBrowserVideo.IsWebBrowserContextMenuEnabled = false;
            webBrowserVideo.WebBrowserShortcutsEnabled = false;
            webBrowserVideo.TabStop = false; 
        }

        private string CreateTransparentLogo(string sourcePath)
        {
            try
            {
                string destPath = System.IO.Path.Combine(Application.StartupPath, "header_logo_transparent.png");
                
                // If already processed and newer than source, use it
                if (System.IO.File.Exists(destPath) && System.IO.File.GetLastWriteTime(destPath) > System.IO.File.GetLastWriteTime(sourcePath))
                    return destPath;

                using (System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(sourcePath))
                {
                    // Lock Bits for speed
                    System.Drawing.Imaging.BitmapData data = bmp.LockBits(
                        new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height),
                        System.Drawing.Imaging.ImageLockMode.ReadWrite,
                        System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                    int bytes = Math.Abs(data.Stride) * bmp.Height;
                    byte[] rgbValues = new byte[bytes];
                    System.Runtime.InteropServices.Marshal.Copy(data.Scan0, rgbValues, 0, bytes);

                    for (int i = 0; i < rgbValues.Length; i += 4)
                    {
                        byte b = rgbValues[i];
                        byte g = rgbValues[i + 1];
                        byte r = rgbValues[i + 2];

                        // Simple threshold: if pixel is dark, make it transparent
                        if (r < 50 && g < 50 && b < 50)
                        {
                            rgbValues[i + 3] = 0; // Alpha 0
                        }
                    }

                    System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, data.Scan0, bytes);
                    bmp.UnlockBits(data);
                    bmp.Save(destPath, System.Drawing.Imaging.ImageFormat.Png);
                }
                return destPath;
            }
            catch { return sourcePath; }
        }

        private void LoadPromoVideo()
        {
            try
            {
                string videoPath = System.IO.Path.Combine(Application.StartupPath, "login_video.mp4");
                string bgPath = System.IO.Path.Combine(Application.StartupPath, "admin_bg_gold_framed_soft.png");
                string logoPath = System.IO.Path.Combine(Application.StartupPath, "header_logo.png");

                // Fallback BG
                if (!System.IO.File.Exists(bgPath))
                     bgPath = System.IO.Path.Combine(Application.StartupPath, "admin_bg_gold_only.png");

                string cssBg = "";
                if (System.IO.File.Exists(bgPath))
                {
                    cssBg = $"background-image: url('file:///{bgPath.Replace(@"\", @"/")}'); background-size: cover; background-position: center; background-repeat: no-repeat;";
                }
                
                string logoHtml = "";
                if (System.IO.File.Exists(logoPath))
                {
                    // Generate Transparency for IE compatibility
                    string transparentLogoPath = CreateTransparentLogo(logoPath);

                    logoHtml = $@"
                    <div class='logo-container'>
                        <img src=""file:///{transparentLogoPath.Replace(@"\", @"/")}"" class='logo-img' />
                        <div class='shine'></div>
                    </div>";
                }

                string commonCss = $@"
        * {{ margin: 0; padding: 0; overflow: hidden; }}
        body {{ 
            background-color: #000; 
            {cssBg}
            width: 100%; 
            height: 100%; 
        }}
        /* Logo Styles */
        .logo-container {{
            position: absolute;
            top: 10px; 
            left: -40px; /* Pull left to compensate for padding */
            width: 350px; 
            z-index: 9999;
            /* mix-blend-mode removed as IE doesn't support it */
        }}
        .logo-img {{
            width: 100%;
            height: auto;
            display: block;
        }}
        /* CSS Shine Animation */
        .shine {{
            position: absolute;
            top: 0;
            left: -100%;
            width: 50%;
            height: 100%;
            background: linear-gradient(to right, rgba(255,255,255,0) 0%, rgba(255,255,255,0.4) 50%, rgba(255,255,255,0) 100%);
            transform: skewX(-25deg);
            animation: shineAnim 3s infinite;
        }}
        @keyframes shineAnim {{
            0% {{ left: -100%; }}
            20% {{ left: 200%; }}
            100% {{ left: 200%; }}
        }}
                ";

                if (System.IO.File.Exists(videoPath))
                {
                    string htmlContent = $@"
<!DOCTYPE html>
<html>
<head>
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
    <style>
        {commonCss}
        video {{
            position: absolute;
            top: 50%;
            left: 50%;
            transform: translate(-50%, -50%);
            min-width: 100%;
            min-height: 100%;
            width: auto;
            height: auto;
        }}
    </style>
</head>
<body>
    <video autoplay loop muted playsinline>
        <source src=""file:///{videoPath.Replace(@"\", @"/")}"" type=""video/mp4"">
    </video>
    {logoHtml}
</body>
</html>";
                    webBrowserVideo.DocumentText = htmlContent;
                }
                else
                {
                    // Fallback w/o video
                    string fallbackHtml = $@"
<!DOCTYPE html>
<html>
<head>
    <style>
        {commonCss}
    </style>
</head>
<body>
    {logoHtml}
</body>
</html>";
                    webBrowserVideo.DocumentText = fallbackHtml;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Video yüklenemedi: " + ex.Message);
            }
        }



        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                XtraMessageBox.Show("Lütfen kullanıcı adı ve şifre giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var authService = new Services.AuthService();
                var user = authService.Login(username, password);

                if (user != null)
                {
                    // Set Global Session
                    OtelOtomasyonu.Services.Session.CurrentUser = user;

                    this.Hide();
                    if (user.Role == UserRole.Staff)
                    {
                        new StaffDashboard().ShowDialog();
                    }
                    else
                    {
                        new AdminDashboard().ShowDialog();
                    }
                    this.Close();
                }
                else
                {
                    XtraMessageBox.Show("Kullanıcı adı veya şifre hatalı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblForgotPassword_HyperlinkClick(object sender, EventArgs e)
        {
             XtraMessageBox.Show("Lütfen sistem yöneticisi ile iletişime geçin.", "Şifre Sıfırlama", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.Properties.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

    }
}
