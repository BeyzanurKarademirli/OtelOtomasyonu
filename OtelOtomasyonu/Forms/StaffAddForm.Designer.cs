namespace OtelOtomasyonu.Forms
{
    partial class StaffAddForm
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

        private void InitializeComponent()
        {
            this.pnlMain = new DevExpress.XtraEditors.PanelControl();
            this.lblName = new DevExpress.XtraEditors.LabelControl();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.lblSurname = new DevExpress.XtraEditors.LabelControl();
            this.txtSurname = new DevExpress.XtraEditors.TextEdit();
            this.lblUsername = new DevExpress.XtraEditors.LabelControl();
            this.txtUsername = new DevExpress.XtraEditors.TextEdit();
            this.lblPassword = new DevExpress.XtraEditors.LabelControl();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.lblDept = new DevExpress.XtraEditors.LabelControl();
            this.cmbDepartment = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblJob = new DevExpress.XtraEditors.LabelControl();
            this.cmbJobTitle = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblSalary = new DevExpress.XtraEditors.LabelControl();
            this.cmbSalary = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblWorkHours = new DevExpress.XtraEditors.LabelControl();
            this.cmbWorkHours = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblPhone = new DevExpress.XtraEditors.LabelControl();
            this.txtPhone = new DevExpress.XtraEditors.TextEdit();
            this.lblEmail = new DevExpress.XtraEditors.LabelControl();
            this.txtEmail = new DevExpress.XtraEditors.TextEdit();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSurname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsername.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDepartment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbJobTitle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSalary.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbWorkHours.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Appearance.BackColor = System.Drawing.Color.Black;
            this.pnlMain.Appearance.Options.UseBackColor = true;
            this.pnlMain.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlMain.Controls.Add(this.btnCancel);
            this.pnlMain.Controls.Add(this.btnSave);
            this.pnlMain.Controls.Add(this.txtEmail);
            this.pnlMain.Controls.Add(this.lblEmail);
            this.pnlMain.Controls.Add(this.txtPhone);
            this.pnlMain.Controls.Add(this.lblPhone);
            this.pnlMain.Controls.Add(this.cmbWorkHours);
            this.pnlMain.Controls.Add(this.lblWorkHours);
            this.pnlMain.Controls.Add(this.cmbSalary);
            this.pnlMain.Controls.Add(this.lblSalary);
            this.pnlMain.Controls.Add(this.cmbJobTitle);
            this.pnlMain.Controls.Add(this.lblJob);
            this.pnlMain.Controls.Add(this.cmbDepartment);
            this.pnlMain.Controls.Add(this.lblDept);
            this.pnlMain.Controls.Add(this.txtPassword);
            this.pnlMain.Controls.Add(this.lblPassword);
            this.pnlMain.Controls.Add(this.txtUsername);
            this.pnlMain.Controls.Add(this.lblUsername);
            this.pnlMain.Controls.Add(this.txtSurname);
            this.pnlMain.Controls.Add(this.lblSurname);
            this.pnlMain.Controls.Add(this.txtName);
            this.pnlMain.Controls.Add(this.lblName);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(400, 500);
            this.pnlMain.TabIndex = 0;
            // 
            // Labels and Controls
            // 
            System.Drawing.Font lblFont = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            System.Drawing.Color goldColor = System.Drawing.Color.Gold;

            this.lblName.Appearance.Font = lblFont;
            this.lblName.Appearance.ForeColor = goldColor;
            this.lblName.Location = new System.Drawing.Point(30, 30);
            this.lblName.Text = "Ad:";

            this.txtName.Location = new System.Drawing.Point(130, 27);
            this.txtName.Size = new System.Drawing.Size(200, 24);

            this.lblSurname.Appearance.Font = lblFont;
            this.lblSurname.Appearance.ForeColor = goldColor;
            this.lblSurname.Location = new System.Drawing.Point(30, 70);
            this.lblSurname.Text = "Soyad:";

            this.txtSurname.Location = new System.Drawing.Point(130, 67);
            this.txtSurname.Size = new System.Drawing.Size(200, 24);

            this.lblUsername.Appearance.Font = lblFont;
            this.lblUsername.Appearance.ForeColor = goldColor;
            this.lblUsername.Location = new System.Drawing.Point(30, 110);
            this.lblUsername.Text = "Kullanıcı Adı:";

            this.txtUsername.Location = new System.Drawing.Point(130, 107);
            this.txtUsername.Size = new System.Drawing.Size(200, 24);

            this.lblPassword.Appearance.Font = lblFont;
            this.lblPassword.Appearance.ForeColor = goldColor;
            this.lblPassword.Location = new System.Drawing.Point(30, 150);
            this.lblPassword.Text = "Şifre:";

            this.txtPassword.Location = new System.Drawing.Point(130, 147);
            this.txtPassword.Size = new System.Drawing.Size(200, 24);

            this.lblDept.Appearance.Font = lblFont;
            this.lblDept.Appearance.ForeColor = goldColor;
            this.lblDept.Location = new System.Drawing.Point(30, 190);
            this.lblDept.Text = "Departman:";

            this.cmbDepartment.Location = new System.Drawing.Point(130, 187);
            this.cmbDepartment.Size = new System.Drawing.Size(200, 24);

            this.lblJob.Appearance.Font = lblFont;
            this.lblJob.Appearance.ForeColor = goldColor;
            this.lblJob.Location = new System.Drawing.Point(30, 230);
            this.lblJob.Text = "Görev:";

            this.cmbJobTitle.Location = new System.Drawing.Point(130, 227);
            this.cmbJobTitle.Size = new System.Drawing.Size(200, 24);

            this.lblSalary.Appearance.Font = lblFont;
            this.lblSalary.Appearance.ForeColor = goldColor;
            this.lblSalary.Location = new System.Drawing.Point(30, 270);
            this.lblSalary.Text = "Maaş:";

            this.cmbSalary.Location = new System.Drawing.Point(130, 267);
            this.cmbSalary.Size = new System.Drawing.Size(200, 24);

            this.lblWorkHours.Appearance.Font = lblFont;
            this.lblWorkHours.Appearance.ForeColor = goldColor;
            this.lblWorkHours.Location = new System.Drawing.Point(30, 310);
            this.lblWorkHours.Text = "Çalışma Saati:";

            this.cmbWorkHours.Location = new System.Drawing.Point(130, 307);
            this.cmbWorkHours.Size = new System.Drawing.Size(200, 24);
            
            this.lblPhone.Appearance.Font = lblFont;
            this.lblPhone.Appearance.ForeColor = goldColor;
            this.lblPhone.Location = new System.Drawing.Point(30, 350);
            this.lblPhone.Text = "Telefon:";

            this.txtPhone.Location = new System.Drawing.Point(130, 347);
            this.txtPhone.Size = new System.Drawing.Size(200, 24);

            this.lblEmail.Appearance.Font = lblFont;
            this.lblEmail.Appearance.ForeColor = goldColor;
            this.lblEmail.Location = new System.Drawing.Point(30, 390);
            this.lblEmail.Text = "Email:";

            this.txtEmail.Location = new System.Drawing.Point(130, 387);
            this.txtEmail.Size = new System.Drawing.Size(200, 24);
            
            // Allow manual text entry if needed, but ComboBox implies selection
            // We'll set these properties in code-behind or here if needed to be strict List
            this.cmbJobTitle.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbSalary.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbWorkHours.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbDepartment.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

            // Buttons
            this.btnSave.Text = "Kaydet";
            this.btnSave.Appearance.BackColor = goldColor;
            this.btnSave.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.Location = new System.Drawing.Point(130, 430);
            this.btnSave.Size = new System.Drawing.Size(90, 35);
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.btnCancel.Text = "İptal";
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCancel.Location = new System.Drawing.Point(240, 430);
            this.btnCancel.Size = new System.Drawing.Size(90, 35);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // 
            // StaffAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 500);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StaffAddForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Personel Ekle";
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSurname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsername.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDepartment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbJobTitle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSalary.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbWorkHours.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).EndInit();
            this.ResumeLayout(false);
        }

        private DevExpress.XtraEditors.PanelControl pnlMain;
        private DevExpress.XtraEditors.LabelControl lblName;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.LabelControl lblSurname;
        private DevExpress.XtraEditors.TextEdit txtSurname;
        private DevExpress.XtraEditors.LabelControl lblUsername;
        private DevExpress.XtraEditors.TextEdit txtUsername;
        private DevExpress.XtraEditors.LabelControl lblPassword;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.LabelControl lblDept;
        private DevExpress.XtraEditors.ComboBoxEdit cmbDepartment;
        private DevExpress.XtraEditors.LabelControl lblJob;
        private DevExpress.XtraEditors.ComboBoxEdit cmbJobTitle;
        private DevExpress.XtraEditors.LabelControl lblSalary;
        private DevExpress.XtraEditors.ComboBoxEdit cmbSalary;
        private DevExpress.XtraEditors.LabelControl lblWorkHours;
        private DevExpress.XtraEditors.ComboBoxEdit cmbWorkHours;
        private DevExpress.XtraEditors.LabelControl lblPhone;
        private DevExpress.XtraEditors.TextEdit txtPhone;
        private DevExpress.XtraEditors.LabelControl lblEmail;
        private DevExpress.XtraEditors.TextEdit txtEmail;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
    }
}
