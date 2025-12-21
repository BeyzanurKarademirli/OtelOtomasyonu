namespace OtelOtomasyonu.Forms
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtUsername = new DevExpress.XtraEditors.TextEdit();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.chkShowPassword = new DevExpress.XtraEditors.CheckEdit();
            this.btnLogin = new DevExpress.XtraEditors.SimpleButton();
            this.lblStatus = new DevExpress.XtraEditors.LabelControl();
            this.panelTop = new System.Windows.Forms.Panel();
            this.picHeaderLogo = new DevExpress.XtraEditors.PictureEdit();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.pnlGoldAccent = new System.Windows.Forms.Panel();
            this.picFooterBg = new DevExpress.XtraEditors.PictureEdit();
            this.webBrowserVideo = new System.Windows.Forms.WebBrowser();

            this.btnForgotPassword = new DevExpress.XtraEditors.SimpleButton();

            ((System.ComponentModel.ISupportInitialize)(this.txtUsername.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkShowPassword.Properties)).BeginInit();
            
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHeaderLogo.Properties)).BeginInit();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFooterBg.Properties)).BeginInit();
            
            this.SuspendLayout();

            // 
            // webBrowserVideo (Tam ekran video arka plan)
            // 
            this.webBrowserVideo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserVideo.Location = new System.Drawing.Point(0, 0);
            this.webBrowserVideo.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserVideo.Name = "webBrowserVideo";
            this.webBrowserVideo.ScrollBarsEnabled = false;
            this.webBrowserVideo.Size = new System.Drawing.Size(900, 700);
            this.webBrowserVideo.TabIndex = 0;

            // 
            // picLogo (Sol Üst Logo)
            // 
 

            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.Black;
            this.panelTop.Controls.Add(this.picHeaderLogo);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(900, 150);
            this.panelTop.TabIndex = 10;
            
            // 
            // picHeaderLogo
            // 
            this.picHeaderLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picHeaderLogo.Location = new System.Drawing.Point(0, 0);
            this.picHeaderLogo.Name = "picHeaderLogo";
            this.picHeaderLogo.Properties.Appearance.BackColor = System.Drawing.Color.Black;
            this.picHeaderLogo.Properties.Appearance.Options.UseBackColor = true;
            this.picHeaderLogo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.picHeaderLogo.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.picHeaderLogo.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.picHeaderLogo.Size = new System.Drawing.Size(900, 150);
            this.picHeaderLogo.TabIndex = 0;

            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.Black;
            this.panelBottom.Controls.Add(this.pnlGoldAccent);
            this.panelBottom.Controls.Add(this.picFooterBg);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 600);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(900, 100);
            this.panelBottom.TabIndex = 11;

            // 
            // pnlGoldAccent
            // 
            this.pnlGoldAccent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(175)))), ((int)(((byte)(55)))));
            this.pnlGoldAccent.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGoldAccent.Location = new System.Drawing.Point(0, 0);
            this.pnlGoldAccent.Name = "pnlGoldAccent";
            this.pnlGoldAccent.Size = new System.Drawing.Size(900, 2);
            this.pnlGoldAccent.TabIndex = 1; // Highlight on top
            this.pnlGoldAccent.BringToFront();

            // 
            // picFooterBg
            // 
            this.picFooterBg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picFooterBg.Location = new System.Drawing.Point(0, 0);
            this.picFooterBg.Name = "picFooterBg";
            this.picFooterBg.Properties.Appearance.BackColor = System.Drawing.Color.Black;
            this.picFooterBg.Properties.Appearance.Options.UseBackColor = true;
            this.picFooterBg.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.picFooterBg.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.picFooterBg.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.picFooterBg.Size = new System.Drawing.Size(900, 100);
            this.picFooterBg.TabIndex = 0;


            // txtUsername (Siyah arka plan, altın yazı)
            // 
            this.txtUsername.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtUsername.Location = new System.Drawing.Point(600, 250);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Properties.Appearance.BackColor = System.Drawing.Color.Black;
            this.txtUsername.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtUsername.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(175)))), ((int)(((byte)(55))))); // Gold text
            this.txtUsername.Properties.Appearance.Options.UseBackColor = true;
            this.txtUsername.Properties.Appearance.Options.UseFont = true;
            this.txtUsername.Properties.Appearance.Options.UseForeColor = true;
            this.txtUsername.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtUsername.Properties.Appearance.Options.UseTextOptions = true;
            this.txtUsername.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Black;
            this.txtUsername.Properties.AppearanceFocused.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(175)))), ((int)(((byte)(55)))));
            this.txtUsername.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtUsername.Properties.AppearanceFocused.Options.UseBorderColor = true;
            this.txtUsername.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtUsername.Properties.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(175)))), ((int)(((byte)(55)))));
            this.txtUsername.Properties.Appearance.Options.UseBorderColor = true;
            this.txtUsername.Properties.NullValuePrompt = "Kullanıcı Adı";
            this.txtUsername.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtUsername.Properties.AutoHeight = false;
            this.txtUsername.Size = new System.Drawing.Size(250, 40);
            this.txtUsername.TabIndex = 1;

            // 
            // txtPassword (Siyah arka plan, altın yazı)
            // 
            this.txtPassword.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtPassword.Location = new System.Drawing.Point(600, 310);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.Appearance.BackColor = System.Drawing.Color.Black;
            this.txtPassword.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtPassword.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(175)))), ((int)(((byte)(55))))); // Gold text
            this.txtPassword.Properties.Appearance.Options.UseBackColor = true;
            this.txtPassword.Properties.Appearance.Options.UseFont = true;
            this.txtPassword.Properties.Appearance.Options.UseForeColor = true;
            this.txtPassword.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtPassword.Properties.Appearance.Options.UseTextOptions = true;
            this.txtPassword.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Black;
            this.txtPassword.Properties.AppearanceFocused.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(175)))), ((int)(((byte)(55)))));
            this.txtPassword.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtPassword.Properties.AppearanceFocused.Options.UseBorderColor = true;
            this.txtPassword.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtPassword.Properties.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(175)))), ((int)(((byte)(55)))));
            this.txtPassword.Properties.Appearance.Options.UseBorderColor = true;
            this.txtPassword.Properties.NullValuePrompt = "Şifre";
            this.txtPassword.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtPassword.Properties.UseSystemPasswordChar = true;
            this.txtPassword.Properties.AutoHeight = false;
            this.txtPassword.Size = new System.Drawing.Size(250, 40);
            this.txtPassword.TabIndex = 2;

            // 
            // chkShowPassword
            // 
            this.chkShowPassword.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.chkShowPassword.Location = new System.Drawing.Point(600, 355);
            this.chkShowPassword.Name = "chkShowPassword";
            this.chkShowPassword.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkShowPassword.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(175)))), ((int)(((byte)(55)))));
            this.chkShowPassword.Properties.Appearance.Options.UseFont = true;
            this.chkShowPassword.Properties.Appearance.Options.UseForeColor = true;
            this.chkShowPassword.Properties.Caption = "Şifreyi Göster";
            this.chkShowPassword.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.chkShowPassword.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.chkShowPassword.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.chkShowPassword.Size = new System.Drawing.Size(250, 20);
            this.chkShowPassword.TabIndex = 8;
            this.chkShowPassword.CheckedChanged += new System.EventHandler(this.chkShowPassword_CheckedChanged);

            // 
            // btnLogin (Altın arka plan, siyah yazı)
            // 
            this.btnLogin.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnLogin.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(175)))), ((int)(((byte)(55))))); // Gold
            this.btnLogin.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnLogin.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnLogin.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(175)))), ((int)(((byte)(55)))));
            this.btnLogin.Appearance.Options.UseBackColor = true;
            this.btnLogin.Appearance.Options.UseFont = true;
            this.btnLogin.Appearance.Options.UseForeColor = true;
            this.btnLogin.Appearance.Options.UseBorderColor = true;
            this.btnLogin.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(195)))), ((int)(((byte)(75)))));
            this.btnLogin.AppearanceHovered.Options.UseBackColor = true;
            this.btnLogin.Location = new System.Drawing.Point(600, 380);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(250, 45);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Giriş Yap";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);

            // 
            // btnForgotPassword (Siyah arka plan, altın yazı, buton görünümü)
            // 
            this.btnForgotPassword.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnForgotPassword.Appearance.BackColor = System.Drawing.Color.Black;
            this.btnForgotPassword.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnForgotPassword.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(175)))), ((int)(((byte)(55))))); // Gold text
            this.btnForgotPassword.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(175)))), ((int)(((byte)(55))))); // Gold border
            this.btnForgotPassword.Appearance.Options.UseBackColor = true;
            this.btnForgotPassword.Appearance.Options.UseFont = true;
            this.btnForgotPassword.Appearance.Options.UseForeColor = true;
            this.btnForgotPassword.Appearance.Options.UseBorderColor = true;
            this.btnForgotPassword.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnForgotPassword.AppearanceHovered.Options.UseBackColor = true;
            this.btnForgotPassword.Location = new System.Drawing.Point(600, 440);
            this.btnForgotPassword.Name = "btnForgotPassword";
            this.btnForgotPassword.Size = new System.Drawing.Size(250, 40);
            this.btnForgotPassword.TabIndex = 7;
            this.btnForgotPassword.Text = "Şifremi Unuttum?";
            this.btnForgotPassword.Click += new System.EventHandler(this.lblForgotPassword_HyperlinkClick);

            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblStatus.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStatus.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblStatus.Appearance.Options.UseFont = true;
            this.lblStatus.Appearance.Options.UseForeColor = true;
            this.lblStatus.Appearance.Options.UseTextOptions = true;
            this.lblStatus.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblStatus.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblStatus.Location = new System.Drawing.Point(600, 470);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(250, 20);
            this.lblStatus.TabIndex = 4;

            // 
            // LoginForm
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(900, 700);
            this.BackColor = System.Drawing.Color.Black;
            // WebBrowser'ı ilk ekle ve arka plana gönder
            this.BackColor = System.Drawing.Color.Black;
            
            // Panelleri ekle (WebBrowser fill olduğu için panelleri önce eklemezsek sorun olabilir, ama Dock sırası önemli)
            // Dock sırası: Top, Bottom, Fill (kalan)
            
            this.Controls.Add(this.panelTop); // Top
            this.Controls.Add(this.panelBottom); // Bottom
            
            // WebBrowser'ı ekle ve Fill yap (Video arka plan ama panellerin arasında kalmalı)
            this.Controls.Add(this.webBrowserVideo);
            this.webBrowserVideo.SendToBack(); 
            // WinForms'da WebBrowser kontrolü her zaman diğer GDI kontrollerinin üstünde durur (Airspace issue).
            // Ancak, parent'ına göre davranır. Eğer video tam ekransa panelleri örter.
            // Fakat webBrowserVideo.Dock = Fill yaptık ve Top/Bottom paneller var. 
            // Dock mantığına göre Top ve Bottom alanları ayrılır, kalan alana WebBrowser yerleşir.
            // Yani video sadece orta kısımda oynar. Siyah barların olduğu yerlere paneller geldi.
            // Bu yüzden "Siyah bar" sorunu da çözülmüş olur çünkü video aspect ratio'yu korusa bile paneller o boşluğu dolduruyor.
            
            // Diğer kontrolleri en üste ekle (Text alanları vs)
            this.Controls.Add(this.btnForgotPassword);
            this.Controls.Add(this.chkShowPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.lblStatus);
            
            this.Controls.SetChildIndex(this.webBrowserVideo, 100); 
            this.Controls.SetChildIndex(this.panelTop, 1);
            this.Controls.SetChildIndex(this.panelBottom, 2);
            this.Controls.SetChildIndex(this.txtUsername, 0); // Inputlar en üstte
            this.Controls.SetChildIndex(this.txtPassword, 0);
            this.Controls.SetChildIndex(this.chkShowPassword, 0);
            this.Controls.SetChildIndex(this.btnLogin, 0);
            this.Controls.SetChildIndex(this.btnForgotPassword, 0);
            this.Controls.SetChildIndex(this.lblStatus, 0);

            this.MaximumSize = new System.Drawing.Size(900, 700);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ada Lovelady's Hotel - Giriş";
            ((System.ComponentModel.ISupportInitialize)(this.txtUsername.Properties)).EndInit();

            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkShowPassword.Properties)).EndInit();


            this.panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picHeaderLogo.Properties)).EndInit();
            this.panelBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picFooterBg.Properties)).EndInit();
            
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtUsername;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.CheckEdit chkShowPassword;
        private DevExpress.XtraEditors.SimpleButton btnLogin;
        private DevExpress.XtraEditors.LabelControl lblStatus;
        private System.Windows.Forms.WebBrowser webBrowserVideo;
        private System.Windows.Forms.Panel panelTop;
        private DevExpress.XtraEditors.PictureEdit picHeaderLogo;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel pnlGoldAccent;
        private DevExpress.XtraEditors.PictureEdit picFooterBg;

        private DevExpress.XtraEditors.SimpleButton btnForgotPassword;
    }
}
