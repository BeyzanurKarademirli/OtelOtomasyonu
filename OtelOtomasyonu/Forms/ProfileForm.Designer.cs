namespace OtelOtomasyonu.Forms
{
    partial class ProfileForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.panelLeft = new DevExpress.XtraEditors.PanelControl();
            this.lblStatus = new DevExpress.XtraEditors.LabelControl();
            this.lblLastLogin = new DevExpress.XtraEditors.LabelControl();
            this.lblRole = new DevExpress.XtraEditors.LabelControl();
            this.lblFullName = new DevExpress.XtraEditors.LabelControl();
            this.picProfile = new DevExpress.XtraEditors.PictureEdit();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.tabPersonalInfo = new DevExpress.XtraTab.XtraTabPage();
            this.panelPersonal = new DevExpress.XtraEditors.PanelControl();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.txtPlate = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtEmail = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtPhone = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtSurname = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtUsername = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.tabSecurity = new DevExpress.XtraTab.XtraTabPage();
            this.panelSecurity = new DevExpress.XtraEditors.PanelControl();
            this.btnUpdatePass = new DevExpress.XtraEditors.SimpleButton();
            this.txtConfirmPass = new DevExpress.XtraEditors.TextEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.txtNewPass = new DevExpress.XtraEditors.TextEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.txtOldPass = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).BeginInit();
            this.splitContainerControl1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).BeginInit();
            this.splitContainerControl1.Panel2.SuspendLayout();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelLeft)).BeginInit();
            this.panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProfile.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.tabPersonalInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelPersonal)).BeginInit();
            this.panelPersonal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSurname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsername.Properties)).BeginInit();
            this.tabSecurity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelSecurity)).BeginInit();
            this.panelSecurity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirmPass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOldPass.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.panelLeft);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.xtraTabControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1000, 600);
            this.splitContainerControl1.SplitterPosition = 300;
            this.splitContainerControl1.TabIndex = 0;
            // 
            // panelLeft
            // 
            this.panelLeft.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.panelLeft.Appearance.Options.UseBackColor = true;
            this.panelLeft.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelLeft.Controls.Add(this.lblStatus);
            this.panelLeft.Controls.Add(this.lblLastLogin);
            this.panelLeft.Controls.Add(this.lblRole);
            this.panelLeft.Controls.Add(this.lblFullName);
            this.panelLeft.Controls.Add(this.picProfile);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(300, 600);
            this.panelLeft.TabIndex = 0;
            // 
            // lblStatus
            // 
            this.lblStatus.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblStatus.Appearance.ForeColor = System.Drawing.Color.LightGreen;
            this.lblStatus.Appearance.Options.UseFont = true;
            this.lblStatus.Appearance.Options.UseForeColor = true;
            this.lblStatus.Location = new System.Drawing.Point(110, 260);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(76, 17);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "● Çevrimiçi";
            // 
            // lblLastLogin
            // 
            this.lblLastLogin.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblLastLogin.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.lblLastLogin.Appearance.Options.UseFont = true;
            this.lblLastLogin.Appearance.Options.UseForeColor = true;
            this.lblLastLogin.Appearance.Options.UseTextOptions = true;
            this.lblLastLogin.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblLastLogin.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblLastLogin.Location = new System.Drawing.Point(10, 560);
            this.lblLastLogin.Name = "lblLastLogin";
            this.lblLastLogin.Size = new System.Drawing.Size(280, 20);
            this.lblLastLogin.TabIndex = 3;
            this.lblLastLogin.Text = "Son Giriş: -";
            // 
            // lblRole
            // 
            this.lblRole.Appearance.Font = new System.Drawing.Font("Georgia", 10F, System.Drawing.FontStyle.Italic);
            this.lblRole.Appearance.ForeColor = System.Drawing.Color.Gold;
            this.lblRole.Appearance.Options.UseFont = true;
            this.lblRole.Appearance.Options.UseForeColor = true;
            this.lblRole.Appearance.Options.UseTextOptions = true;
            this.lblRole.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblRole.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblRole.Location = new System.Drawing.Point(10, 230);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(280, 20);
            this.lblRole.TabIndex = 2;
            this.lblRole.Text = "YÖNETİCİ";
            // 
            // lblFullName
            // 
            this.lblFullName.Appearance.Font = new System.Drawing.Font("Georgia", 14F, System.Drawing.FontStyle.Bold);
            this.lblFullName.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblFullName.Appearance.Options.UseFont = true;
            this.lblFullName.Appearance.Options.UseForeColor = true;
            this.lblFullName.Appearance.Options.UseTextOptions = true;
            this.lblFullName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFullName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblFullName.Location = new System.Drawing.Point(10, 190);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(280, 30);
            this.lblFullName.TabIndex = 1;
            this.lblFullName.Text = "KULLANICI ADI";
            // 
            // picProfile
            // 
            this.picProfile.EditValue = null;
            this.picProfile.Location = new System.Drawing.Point(85, 40);
            this.picProfile.Name = "picProfile";
            this.picProfile.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.picProfile.Properties.Appearance.Options.UseBackColor = true;
            this.picProfile.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.picProfile.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.picProfile.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.picProfile.Size = new System.Drawing.Size(130, 130);
            this.picProfile.TabIndex = 0;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Appearance.BackColor = System.Drawing.Color.Black;
            this.xtraTabControl1.Appearance.Options.UseBackColor = true;
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.tabPersonalInfo;
            this.xtraTabControl1.Size = new System.Drawing.Size(690, 600);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabPersonalInfo,
            this.tabSecurity});
            // 
            // tabPersonalInfo
            // 
            this.tabPersonalInfo.Controls.Add(this.panelPersonal);
            this.tabPersonalInfo.Name = "tabPersonalInfo";
            this.tabPersonalInfo.Size = new System.Drawing.Size(688, 575);
            this.tabPersonalInfo.Text = "Kişisel Bilgiler";
            // 
            // panelPersonal
            // 
            this.panelPersonal.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.panelPersonal.Appearance.Options.UseBackColor = true;
            this.panelPersonal.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelPersonal.Controls.Add(this.btnSave);
            this.panelPersonal.Controls.Add(this.txtPlate);
            this.panelPersonal.Controls.Add(this.labelControl6);
            this.panelPersonal.Controls.Add(this.txtEmail);
            this.panelPersonal.Controls.Add(this.labelControl5);
            this.panelPersonal.Controls.Add(this.txtPhone);
            this.panelPersonal.Controls.Add(this.labelControl4);
            this.panelPersonal.Controls.Add(this.txtSurname);
            this.panelPersonal.Controls.Add(this.labelControl3);
            this.panelPersonal.Controls.Add(this.txtName);
            this.panelPersonal.Controls.Add(this.labelControl2);
            this.panelPersonal.Controls.Add(this.txtUsername);
            this.panelPersonal.Controls.Add(this.labelControl1);
            this.panelPersonal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPersonal.Location = new System.Drawing.Point(0, 0);
            this.panelPersonal.Name = "panelPersonal";
            this.panelPersonal.Size = new System.Drawing.Size(688, 575);
            this.panelPersonal.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Appearance.BackColor = System.Drawing.Color.Gold;
            this.btnSave.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSave.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Appearance.Options.UseBackColor = true;
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Appearance.Options.UseForeColor = true;
            this.btnSave.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnSave.Location = new System.Drawing.Point(400, 350);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(150, 45);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "KAYDET";
            // 
            // txtPlate
            // 
            this.txtPlate.Location = new System.Drawing.Point(200, 280);
            this.txtPlate.Name = "txtPlate";
            this.txtPlate.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtPlate.Properties.Appearance.Options.UseFont = true;
            this.txtPlate.Size = new System.Drawing.Size(350, 26);
            this.txtPlate.TabIndex = 11;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.labelControl6.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Appearance.Options.UseForeColor = true;
            this.labelControl6.Location = new System.Drawing.Point(50, 283);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(107, 20);
            this.labelControl6.TabIndex = 10;
            this.labelControl6.Text = "Araç Plaka No:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(200, 230);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtEmail.Properties.Appearance.Options.UseFont = true;
            this.txtEmail.Size = new System.Drawing.Size(350, 26);
            this.txtEmail.TabIndex = 9;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.labelControl5.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Appearance.Options.UseForeColor = true;
            this.labelControl5.Location = new System.Drawing.Point(50, 233);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(43, 20);
            this.labelControl5.TabIndex = 8;
            this.labelControl5.Text = "Email:";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(200, 180);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtPhone.Properties.Appearance.Options.UseFont = true;
            this.txtPhone.Size = new System.Drawing.Size(350, 26);
            this.txtPhone.TabIndex = 7;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.labelControl4.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Appearance.Options.UseForeColor = true;
            this.labelControl4.Location = new System.Drawing.Point(50, 183);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(83, 20);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "Telefon No:";
            // 
            // txtSurname
            // 
            this.txtSurname.Location = new System.Drawing.Point(200, 130);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtSurname.Properties.Appearance.Options.UseFont = true;
            this.txtSurname.Size = new System.Drawing.Size(350, 26);
            this.txtSurname.TabIndex = 5;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.Location = new System.Drawing.Point(50, 133);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(47, 20);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Soyad:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(200, 80);
            this.txtName.Name = "txtName";
            this.txtName.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtName.Properties.Appearance.Options.UseFont = true;
            this.txtName.Size = new System.Drawing.Size(350, 26);
            this.txtName.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(50, 83);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(25, 20);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Ad:";
            // 
            // txtUsername
            // 
            this.txtUsername.Enabled = false;
            this.txtUsername.Location = new System.Drawing.Point(200, 30);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtUsername.Properties.Appearance.Options.UseFont = true;
            this.txtUsername.Size = new System.Drawing.Size(350, 26);
            this.txtUsername.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(50, 33);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(90, 20);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Kullanıcı Adı:";
            // 
            // tabSecurity
            // 
            this.tabSecurity.Controls.Add(this.panelSecurity);
            this.tabSecurity.Name = "tabSecurity";
            this.tabSecurity.Size = new System.Drawing.Size(688, 575);
            this.tabSecurity.Text = "Güvenlik";
            // 
            // panelSecurity
            // 
            this.panelSecurity.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.panelSecurity.Appearance.Options.UseBackColor = true;
            this.panelSecurity.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelSecurity.Controls.Add(this.btnUpdatePass);
            this.panelSecurity.Controls.Add(this.txtConfirmPass);
            this.panelSecurity.Controls.Add(this.labelControl9);
            this.panelSecurity.Controls.Add(this.txtNewPass);
            this.panelSecurity.Controls.Add(this.labelControl8);
            this.panelSecurity.Controls.Add(this.txtOldPass);
            this.panelSecurity.Controls.Add(this.labelControl7);
            this.panelSecurity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSecurity.Location = new System.Drawing.Point(0, 0);
            this.panelSecurity.Name = "panelSecurity";
            this.panelSecurity.Size = new System.Drawing.Size(688, 575);
            this.panelSecurity.TabIndex = 0;
            // 
            // btnUpdatePass
            // 
            this.btnUpdatePass.Appearance.BackColor = System.Drawing.Color.Tomato;
            this.btnUpdatePass.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnUpdatePass.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnUpdatePass.Appearance.Options.UseBackColor = true;
            this.btnUpdatePass.Appearance.Options.UseFont = true;
            this.btnUpdatePass.Appearance.Options.UseForeColor = true;
            this.btnUpdatePass.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnUpdatePass.Location = new System.Drawing.Point(400, 200);
            this.btnUpdatePass.Name = "btnUpdatePass";
            this.btnUpdatePass.Size = new System.Drawing.Size(150, 45);
            this.btnUpdatePass.TabIndex = 13;
            this.btnUpdatePass.Text = "ŞİFREYİ GÜNCELLE";
            // 
            // txtConfirmPass
            // 
            this.txtConfirmPass.Location = new System.Drawing.Point(200, 130);
            this.txtConfirmPass.Name = "txtConfirmPass";
            this.txtConfirmPass.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtConfirmPass.Properties.Appearance.Options.UseFont = true;
            this.txtConfirmPass.Properties.UseSystemPasswordChar = true;
            this.txtConfirmPass.Size = new System.Drawing.Size(350, 26);
            this.txtConfirmPass.TabIndex = 7;
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.labelControl9.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl9.Appearance.Options.UseFont = true;
            this.labelControl9.Appearance.Options.UseForeColor = true;
            this.labelControl9.Location = new System.Drawing.Point(50, 133);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(124, 20);
            this.labelControl9.TabIndex = 6;
            this.labelControl9.Text = "Yeni Şifre (Tekrar):";
            // 
            // txtNewPass
            // 
            this.txtNewPass.Location = new System.Drawing.Point(200, 80);
            this.txtNewPass.Name = "txtNewPass";
            this.txtNewPass.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtNewPass.Properties.Appearance.Options.UseFont = true;
            this.txtNewPass.Properties.UseSystemPasswordChar = true;
            this.txtNewPass.Size = new System.Drawing.Size(350, 26);
            this.txtNewPass.TabIndex = 5;
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.labelControl8.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Appearance.Options.UseForeColor = true;
            this.labelControl8.Location = new System.Drawing.Point(50, 83);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(71, 20);
            this.labelControl8.TabIndex = 4;
            this.labelControl8.Text = "Yeni Şifre:";
            // 
            // txtOldPass
            // 
            this.txtOldPass.Location = new System.Drawing.Point(200, 30);
            this.txtOldPass.Name = "txtOldPass";
            this.txtOldPass.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtOldPass.Properties.Appearance.Options.UseFont = true;
            this.txtOldPass.Properties.UseSystemPasswordChar = true;
            this.txtOldPass.Size = new System.Drawing.Size(350, 26);
            this.txtOldPass.TabIndex = 3;
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.labelControl7.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Appearance.Options.UseForeColor = true;
            this.labelControl7.Location = new System.Drawing.Point(50, 33);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(68, 20);
            this.labelControl7.TabIndex = 2;
            this.labelControl7.Text = "Eski Şifre:";
            // 
            // ProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.splitContainerControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ProfileForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Profil Yönetimi";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).EndInit();
            this.splitContainerControl1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).EndInit();
            this.splitContainerControl1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelLeft)).EndInit();
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProfile.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.tabPersonalInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelPersonal)).EndInit();
            this.panelPersonal.ResumeLayout(false);
            this.panelPersonal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSurname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsername.Properties)).EndInit();
            this.tabSecurity.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelSecurity)).EndInit();
            this.panelSecurity.ResumeLayout(false);
            this.panelSecurity.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirmPass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOldPass.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.PanelControl panelLeft;
        private DevExpress.XtraEditors.PictureEdit picProfile;
        private DevExpress.XtraEditors.LabelControl lblFullName;
        private DevExpress.XtraEditors.LabelControl lblRole;
        private DevExpress.XtraEditors.LabelControl lblLastLogin;
        private DevExpress.XtraEditors.LabelControl lblStatus;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage tabPersonalInfo;
        private DevExpress.XtraEditors.PanelControl panelPersonal;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtUsername;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtSurname;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtPhone;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtEmail;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txtPlate;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraTab.XtraTabPage tabSecurity;
        private DevExpress.XtraEditors.PanelControl panelSecurity;
        private DevExpress.XtraEditors.SimpleButton btnUpdatePass;
        private DevExpress.XtraEditors.TextEdit txtConfirmPass;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.TextEdit txtNewPass;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.TextEdit txtOldPass;
        private DevExpress.XtraEditors.LabelControl labelControl7;
    }
}
