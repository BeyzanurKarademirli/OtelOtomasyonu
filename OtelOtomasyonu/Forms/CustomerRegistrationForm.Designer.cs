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

            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSurname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhone.Properties)).BeginInit();
            this.SuspendLayout();

            // lblName
            this.lblName.Location = new System.Drawing.Point(30, 30);
            this.lblName.Text = "Ad:";

            // txtName
            this.txtName.Location = new System.Drawing.Point(120, 27);
            this.txtName.Size = new System.Drawing.Size(200, 20);

            // lblSurname
            this.lblSurname.Location = new System.Drawing.Point(30, 70);
            this.lblSurname.Text = "Soyad:";

            // txtSurname
            this.txtSurname.Location = new System.Drawing.Point(120, 67);
            this.txtSurname.Size = new System.Drawing.Size(200, 20);

            // lblTC
            this.lblTC.Location = new System.Drawing.Point(30, 110);
            this.lblTC.Text = "T.C. / Pasaport:";

            // txtTC
            this.txtTC.Location = new System.Drawing.Point(120, 107);
            this.txtTC.Size = new System.Drawing.Size(200, 20);

            // lblPhone
            this.lblPhone.Location = new System.Drawing.Point(30, 150);
            this.lblPhone.Text = "Telefon:";

            // txtPhone
            this.txtPhone.Location = new System.Drawing.Point(120, 147);
            this.txtPhone.Size = new System.Drawing.Size(200, 20);

            // lblEmail
            this.lblEmail = new DevExpress.XtraEditors.LabelControl();
            this.lblEmail.Location = new System.Drawing.Point(30, 190);
            this.lblEmail.Text = "E-posta:";
            this.Controls.Add(this.lblEmail);

            // txtEmail
            this.txtEmail = new DevExpress.XtraEditors.TextEdit();
            this.txtEmail.Location = new System.Drawing.Point(120, 187);
            this.txtEmail.Size = new System.Drawing.Size(200, 20);
            this.Controls.Add(this.txtEmail);

            // chkHasVehicle
            this.chkHasVehicle = new DevExpress.XtraEditors.CheckEdit();
            this.chkHasVehicle.Location = new System.Drawing.Point(120, 220);
            this.chkHasVehicle.Properties.Caption = "Araç Var mı?";
            this.chkHasVehicle.CheckedChanged += new System.EventHandler(this.chkHasVehicle_CheckedChanged);
            this.Controls.Add(this.chkHasVehicle);

            // lblPlate
            this.lblPlate = new DevExpress.XtraEditors.LabelControl();
            this.lblPlate.Location = new System.Drawing.Point(30, 250);
            this.lblPlate.Text = "Araç Plaka:";
            this.lblPlate.Visible = false;
            this.Controls.Add(this.lblPlate);

            // txtPlate
            this.txtPlate = new DevExpress.XtraEditors.TextEdit();
            this.txtPlate.Location = new System.Drawing.Point(120, 247);
            this.txtPlate.Size = new System.Drawing.Size(200, 20);
            this.txtPlate.Visible = false;
            this.Controls.Add(this.txtPlate);

            // btnRegister
            this.btnRegister.Location = new System.Drawing.Point(120, 290);
            this.btnRegister.Size = new System.Drawing.Size(200, 40);
            this.btnRegister.Text = "Müşteriyi Kaydet";
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);

            // Form
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(770, 700);
            this.MaximumSize = new System.Drawing.Size(770, 700);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtTC);
            this.Controls.Add(this.lblTC);
            this.Controls.Add(this.txtSurname);
            this.Controls.Add(this.lblSurname);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Name = "CustomerRegistrationForm";
            this.Text = "Ada Lovelady's Hotel - Yeni Müşteri Kaydı";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSurname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlate.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
