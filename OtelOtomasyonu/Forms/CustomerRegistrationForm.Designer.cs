namespace OtelOtomasyonu.Forms
{
    partial class CustomerRegistrationForm
    {
        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.TextEdit txtSurname;
        private DevExpress.XtraEditors.TextEdit txtTC;
        private DevExpress.XtraEditors.TextEdit txtPhone;
        private DevExpress.XtraEditors.TextEdit txtEmail;
        private DevExpress.XtraEditors.TextEdit txtPlate;
        private DevExpress.XtraEditors.LabelControl lblName;
        private DevExpress.XtraEditors.LabelControl lblSurname;
        private DevExpress.XtraEditors.LabelControl lblTC;
        private DevExpress.XtraEditors.LabelControl lblPhone;
        private DevExpress.XtraEditors.LabelControl lblEmail;
        private DevExpress.XtraEditors.LabelControl lblPlate;
        private DevExpress.XtraEditors.CheckEdit chkHasVehicle;
        private DevExpress.XtraEditors.SimpleButton btnRegister;
        private DevExpress.XtraEditors.LabelControl lblGuestCount;
        private DevExpress.XtraEditors.ComboBoxEdit cmbGuestCount;
        private DevExpress.XtraEditors.LabelControl lblStayDays;
        private DevExpress.XtraEditors.SpinEdit numStayDays;
        private System.Windows.Forms.Panel pnlAdditionalGuests;
        private System.Windows.Forms.Panel pnlMainGuest;

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
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.txtSurname = new DevExpress.XtraEditors.TextEdit();
            this.txtTC = new DevExpress.XtraEditors.TextEdit();
            this.txtPhone = new DevExpress.XtraEditors.TextEdit();
            this.lblName = new DevExpress.XtraEditors.LabelControl();
            this.lblSurname = new DevExpress.XtraEditors.LabelControl();
            this.lblTC = new DevExpress.XtraEditors.LabelControl();
            this.lblPhone = new DevExpress.XtraEditors.LabelControl();
            this.btnRegister = new DevExpress.XtraEditors.SimpleButton();
            this.lblEmail = new DevExpress.XtraEditors.LabelControl();
            this.txtEmail = new DevExpress.XtraEditors.TextEdit();
            this.chkHasVehicle = new DevExpress.XtraEditors.CheckEdit();
            this.lblPlate = new DevExpress.XtraEditors.LabelControl();
            this.txtPlate = new DevExpress.XtraEditors.TextEdit();
            this.lblGuestCount = new DevExpress.XtraEditors.LabelControl();
            this.cmbGuestCount = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblStayDays = new DevExpress.XtraEditors.LabelControl();
            this.numStayDays = new DevExpress.XtraEditors.SpinEdit();
            this.pnlAdditionalGuests = new System.Windows.Forms.Panel();
            this.pnlMainGuest = new System.Windows.Forms.Panel();

            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSurname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkHasVehicle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbGuestCount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStayDays.Properties)).BeginInit();
            this.pnlAdditionalGuests.SuspendLayout();
            this.pnlMainGuest.SuspendLayout();
            this.SuspendLayout();

            // Shared Styles
            System.Drawing.Font lblFont = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            System.Drawing.Color goldColor = System.Drawing.Color.Gold;
            System.Drawing.Color blackColor = System.Drawing.Color.Black;

            // lblGuestCount
            this.lblGuestCount.Appearance.Font = lblFont;
            this.lblGuestCount.Appearance.ForeColor = goldColor;
            this.lblGuestCount.Location = new System.Drawing.Point(30, 30);
            this.lblGuestCount.Text = "Kişi Sayısı:";
            this.lblGuestCount.Size = new System.Drawing.Size(100, 20);

            // cmbGuestCount
            this.cmbGuestCount.Location = new System.Drawing.Point(140, 27);
            this.cmbGuestCount.Size = new System.Drawing.Size(200, 24);
            this.cmbGuestCount.Properties.Items.AddRange(new object[] { "1", "2", "3", "4" });
            this.cmbGuestCount.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbGuestCount.SelectedIndex = 0; // Default: 1 kişi
            this.cmbGuestCount.SelectedIndexChanged += new System.EventHandler(this.cmbGuestCount_SelectedIndexChanged);

            // lblStayDays
            this.lblStayDays.Appearance.Font = lblFont;
            this.lblStayDays.Appearance.ForeColor = goldColor;
            this.lblStayDays.Location = new System.Drawing.Point(360, 30);
            this.lblStayDays.Text = "Kaç Gün Kalacaksınız?:";
            this.lblStayDays.Size = new System.Drawing.Size(150, 20);

            // numStayDays
            this.numStayDays.Location = new System.Drawing.Point(520, 27);
            this.numStayDays.Size = new System.Drawing.Size(100, 24);
            this.numStayDays.Properties.MinValue = 1;
            this.numStayDays.Properties.MaxValue = 30;
            this.numStayDays.Properties.IsFloatValue = false;
            this.numStayDays.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.numStayDays.Properties.MaskSettings.Set("mask", "d");
            this.numStayDays.EditValue = 1; // Default: 1 gün

            // pnlMainGuest - Ana müşteri bilgileri
            this.pnlMainGuest.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.pnlMainGuest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMainGuest.Location = new System.Drawing.Point(20, 60);
            this.pnlMainGuest.Size = new System.Drawing.Size(740, 250);
            this.pnlMainGuest.AutoScroll = true;

            // lblName (Ana Müşteri)
            this.lblName.Appearance.Font = lblFont;
            this.lblName.Appearance.ForeColor = goldColor;
            this.lblName.Location = new System.Drawing.Point(10, 10);
            this.lblName.Text = "Ana Müşteri - Ad:";

            // txtName
            this.txtName.Location = new System.Drawing.Point(150, 7);
            this.txtName.Size = new System.Drawing.Size(200, 24);

            // lblSurname
            this.lblSurname.Appearance.Font = lblFont;
            this.lblSurname.Appearance.ForeColor = goldColor;
            this.lblSurname.Location = new System.Drawing.Point(10, 50);
            this.lblSurname.Text = "Soyad:";

            // txtSurname
            this.txtSurname.Location = new System.Drawing.Point(150, 47);
            this.txtSurname.Size = new System.Drawing.Size(200, 24);

            // lblTC
            this.lblTC.Appearance.Font = lblFont;
            this.lblTC.Appearance.ForeColor = goldColor;
            this.lblTC.Location = new System.Drawing.Point(10, 90);
            this.lblTC.Text = "T.C. / Pasaport:";

            // txtTC
            this.txtTC.Location = new System.Drawing.Point(150, 87);
            this.txtTC.Size = new System.Drawing.Size(200, 24);

            // lblPhone
            this.lblPhone.Appearance.Font = lblFont;
            this.lblPhone.Appearance.ForeColor = goldColor;
            this.lblPhone.Location = new System.Drawing.Point(10, 130);
            this.lblPhone.Text = "Telefon:";

            // txtPhone
            this.txtPhone.Location = new System.Drawing.Point(150, 127);
            this.txtPhone.Size = new System.Drawing.Size(200, 24);

            // lblEmail
            this.lblEmail.Appearance.Font = lblFont;
            this.lblEmail.Appearance.ForeColor = goldColor;
            this.lblEmail.Location = new System.Drawing.Point(10, 170);
            this.lblEmail.Text = "E-posta:";

            // txtEmail
            this.txtEmail.Location = new System.Drawing.Point(150, 167);
            this.txtEmail.Size = new System.Drawing.Size(200, 24);

            // chkHasVehicle
            this.chkHasVehicle.Location = new System.Drawing.Point(150, 200);
            this.chkHasVehicle.Properties.Appearance.Font = lblFont;
            this.chkHasVehicle.Properties.Appearance.ForeColor = goldColor;
            this.chkHasVehicle.Properties.Caption = "Araç Var mı?";
            this.chkHasVehicle.CheckedChanged += new System.EventHandler(this.chkHasVehicle_CheckedChanged);

            // lblPlate
            this.lblPlate.Appearance.Font = lblFont;
            this.lblPlate.Appearance.ForeColor = goldColor;
            this.lblPlate.Location = new System.Drawing.Point(10, 240);
            this.lblPlate.Text = "Araç Plaka:";
            this.lblPlate.Visible = false;

            // txtPlate
            this.txtPlate.Location = new System.Drawing.Point(150, 237);
            this.txtPlate.Size = new System.Drawing.Size(200, 24);
            this.txtPlate.Visible = false;

            // pnlMainGuest içine kontrolleri ekle
            this.pnlMainGuest.Controls.Add(this.txtPlate);
            this.pnlMainGuest.Controls.Add(this.lblPlate);
            this.pnlMainGuest.Controls.Add(this.chkHasVehicle);
            this.pnlMainGuest.Controls.Add(this.txtEmail);
            this.pnlMainGuest.Controls.Add(this.lblEmail);
            this.pnlMainGuest.Controls.Add(this.txtPhone);
            this.pnlMainGuest.Controls.Add(this.lblPhone);
            this.pnlMainGuest.Controls.Add(this.txtTC);
            this.pnlMainGuest.Controls.Add(this.lblTC);
            this.pnlMainGuest.Controls.Add(this.txtSurname);
            this.pnlMainGuest.Controls.Add(this.lblSurname);
            this.pnlMainGuest.Controls.Add(this.txtName);
            this.pnlMainGuest.Controls.Add(this.lblName);

            // pnlAdditionalGuests - Ekstra müşteriler
            this.pnlAdditionalGuests.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.pnlAdditionalGuests.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAdditionalGuests.Location = new System.Drawing.Point(20, 320);
            this.pnlAdditionalGuests.Size = new System.Drawing.Size(740, 200);
            this.pnlAdditionalGuests.AutoScroll = true;
            this.pnlAdditionalGuests.Visible = false;

            // btnRegister
            this.btnRegister.Appearance.BackColor = goldColor;
            this.btnRegister.Appearance.ForeColor = blackColor;
            this.btnRegister.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRegister.Location = new System.Drawing.Point(300, 550);
            this.btnRegister.Size = new System.Drawing.Size(200, 40);
            this.btnRegister.Text = "Müşteriyi Kaydet";
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);

            // CustomerRegistrationForm
            this.Appearance.BackColor = blackColor;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 650);
            this.AutoScroll = true;
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.pnlAdditionalGuests);
            this.Controls.Add(this.pnlMainGuest);
            this.Controls.Add(this.numStayDays);
            this.Controls.Add(this.lblStayDays);
            this.Controls.Add(this.cmbGuestCount);
            this.Controls.Add(this.lblGuestCount);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomerRegistrationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yeni Müşteri Kaydı";

            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSurname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkHasVehicle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbGuestCount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStayDays.Properties)).EndInit();
            this.pnlAdditionalGuests.ResumeLayout(false);
            this.pnlMainGuest.ResumeLayout(false);
            this.pnlMainGuest.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
