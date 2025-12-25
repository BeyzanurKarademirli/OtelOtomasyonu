namespace OtelOtomasyonu.Forms
{
    partial class StaffDashboard
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
            this.lblUserName = new DevExpress.XtraEditors.LabelControl();
            this.pnlMenu = new System.Windows.Forms.TableLayoutPanel();
            this.btnNewCustomer = new DevExpress.XtraEditors.SimpleButton();
            this.btnCertificates = new DevExpress.XtraEditors.SimpleButton();
            this.btnCheckInOut = new DevExpress.XtraEditors.SimpleButton();
            this.btnFloorPlan = new DevExpress.XtraEditors.SimpleButton();
            this.btnCustomers = new DevExpress.XtraEditors.SimpleButton();
            this.btnProfile = new DevExpress.XtraEditors.SimpleButton();
            this.btnRevenue = new DevExpress.XtraEditors.SimpleButton();
            this.btnRoomInfo = new DevExpress.XtraEditors.SimpleButton();
            this.btnOccupancy = new DevExpress.XtraEditors.SimpleButton();
            this.btnHelp = new DevExpress.XtraEditors.SimpleButton();
            this.picLogo = new DevExpress.XtraEditors.PictureEdit();
            this.pnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo.Properties)).BeginInit();
            this.SuspendLayout();

            // 
            // lblUserName
            // 
            this.lblUserName.Appearance.Font = new System.Drawing.Font("Georgia", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(168)))), ((int)(((byte)(105)))));
            this.lblUserName.Appearance.Options.UseFont = true;
            this.lblUserName.Appearance.Options.UseForeColor = true;
            this.lblUserName.Appearance.Options.UseTextOptions = true;
            this.lblUserName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblUserName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblUserName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblUserName.Location = new System.Drawing.Point(0, 160);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(1280, 50);
            this.lblUserName.TabIndex = 1;
            this.lblUserName.Text = "PERSONEL";
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.Transparent;
            this.pnlMenu.ColumnCount = 2;
            this.pnlMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlMenu.Controls.Add(this.btnNewCustomer, 0, 0);
            this.pnlMenu.Controls.Add(this.btnCertificates, 1, 0);
            this.pnlMenu.Controls.Add(this.btnCheckInOut, 0, 1);
            this.pnlMenu.Controls.Add(this.btnFloorPlan, 1, 1);
            this.pnlMenu.Controls.Add(this.btnCustomers, 0, 2);
            this.pnlMenu.Controls.Add(this.btnProfile, 1, 2);
            this.pnlMenu.Controls.Add(this.btnRoomInfo, 0, 3);
            this.pnlMenu.Controls.Add(this.btnOccupancy, 1, 3);
            this.pnlMenu.Location = new System.Drawing.Point(240, 250);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.RowCount = 4;
            this.pnlMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.pnlMenu.Size = new System.Drawing.Size(800, 400);
            this.pnlMenu.TabIndex = 2;
            // 
            // btnNewCustomer
            // 
            this.btnNewCustomer.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular);
            this.btnNewCustomer.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnNewCustomer.Appearance.Options.UseFont = true;
            this.btnNewCustomer.Appearance.Options.UseForeColor = true;
            this.btnNewCustomer.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnNewCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNewCustomer.Location = new System.Drawing.Point(20, 10);
            this.btnNewCustomer.Margin = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.btnNewCustomer.Name = "btnNewCustomer";
            this.btnNewCustomer.Size = new System.Drawing.Size(360, 80);
            this.btnNewCustomer.TabIndex = 0;
            this.btnNewCustomer.Text = "Yeni Müşteri Kaydı";
            // 
            // btnCertificates
            // 
            this.btnCertificates.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular);
            this.btnCertificates.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnCertificates.Appearance.Options.UseFont = true;
            this.btnCertificates.Appearance.Options.UseForeColor = true;
            this.btnCertificates.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnCertificates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCertificates.Location = new System.Drawing.Point(420, 10);
            this.btnCertificates.Margin = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.btnCertificates.Name = "btnCertificates";
            this.btnCertificates.Size = new System.Drawing.Size(360, 80);
            this.btnCertificates.TabIndex = 1;
            this.btnCertificates.Text = "Sertifikalar";
            // 
            // btnCheckInOut
            // 
            this.btnCheckInOut.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular);
            this.btnCheckInOut.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnCheckInOut.Appearance.Options.UseFont = true;
            this.btnCheckInOut.Appearance.Options.UseForeColor = true;
            this.btnCheckInOut.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnCheckInOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCheckInOut.Location = new System.Drawing.Point(20, 110);
            this.btnCheckInOut.Margin = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.btnCheckInOut.Name = "btnCheckInOut";
            this.btnCheckInOut.Size = new System.Drawing.Size(360, 80);
            this.btnCheckInOut.TabIndex = 2;
            this.btnCheckInOut.Text = "Check-In/Check-Out";
            // 
            // btnFloorPlan
            // 
            this.btnFloorPlan.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular);
            this.btnFloorPlan.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnFloorPlan.Appearance.Options.UseFont = true;
            this.btnFloorPlan.Appearance.Options.UseForeColor = true;
            this.btnFloorPlan.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnFloorPlan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFloorPlan.Location = new System.Drawing.Point(420, 110);
            this.btnFloorPlan.Margin = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.btnFloorPlan.Name = "btnFloorPlan";
            this.btnFloorPlan.Size = new System.Drawing.Size(360, 80);
            this.btnFloorPlan.TabIndex = 3;
            this.btnFloorPlan.Text = "Kat Planı";
            // 
            // btnCustomers
            // 
            this.btnCustomers.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular);
            this.btnCustomers.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnCustomers.Appearance.Options.UseFont = true;
            this.btnCustomers.Appearance.Options.UseForeColor = true;
            this.btnCustomers.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCustomers.Location = new System.Drawing.Point(20, 210);
            this.btnCustomers.Margin = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.btnCustomers.Name = "btnCustomers";
            this.btnCustomers.Size = new System.Drawing.Size(360, 80);
            this.btnCustomers.TabIndex = 4;
            this.btnCustomers.Text = "Müşteri Bilgileri";
            // 
            // btnProfile
            // 
            this.btnProfile.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular);
            this.btnProfile.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnProfile.Appearance.Options.UseFont = true;
            this.btnProfile.Appearance.Options.UseForeColor = true;
            this.btnProfile.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnProfile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnProfile.Location = new System.Drawing.Point(420, 210);
            this.btnProfile.Margin = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(360, 80);
            this.btnProfile.TabIndex = 5;
            this.btnProfile.Text = "Profil";
            // 
            // btnRevenue
            // 
            this.btnRevenue.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular);
            this.btnRevenue.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnRevenue.Appearance.Options.UseFont = true;
            this.btnRevenue.Appearance.Options.UseForeColor = true;
            this.btnRevenue.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnRevenue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRevenue.Location = new System.Drawing.Point(20, 310);
            this.btnRevenue.Margin = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.btnRevenue.Name = "btnRevenue";
            this.btnRevenue.Size = new System.Drawing.Size(360, 80);
            this.btnRevenue.TabIndex = 6;
            this.btnRevenue.Text = "Gelir Oranı";
            this.btnRevenue.Visible = false;
            // 
            // btnRoomInfo
            // 
            this.btnRoomInfo.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular);
            this.btnRoomInfo.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnRoomInfo.Appearance.Options.UseFont = true;
            this.btnRoomInfo.Appearance.Options.UseForeColor = true;
            this.btnRoomInfo.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnRoomInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRoomInfo.Location = new System.Drawing.Point(20, 310);
            this.btnRoomInfo.Margin = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.btnRoomInfo.Name = "btnRoomInfo";
            this.btnRoomInfo.Size = new System.Drawing.Size(360, 80);
            this.btnRoomInfo.TabIndex = 7;
            this.btnRoomInfo.Text = "Oda Bilgisi";
            this.btnRoomInfo.Visible = false;
            // 
            // btnOccupancy
            // 
            this.btnOccupancy.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular);
            this.btnOccupancy.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnOccupancy.Appearance.Options.UseFont = true;
            this.btnOccupancy.Appearance.Options.UseForeColor = true;
            this.btnOccupancy.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnOccupancy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOccupancy.Location = new System.Drawing.Point(420, 310);
            this.btnOccupancy.Margin = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.btnOccupancy.Name = "btnOccupancy";
            this.btnOccupancy.Size = new System.Drawing.Size(360, 80);
            this.btnOccupancy.TabIndex = 8;
            this.btnOccupancy.Text = "Oda Doluluk Oranı";
            this.btnOccupancy.Visible = false;
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelp.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnHelp.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnHelp.Appearance.Options.UseFont = true;
            this.btnHelp.Appearance.Options.UseForeColor = true;
            this.btnHelp.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnHelp.Location = new System.Drawing.Point(1150, 650);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(100, 100);
            this.btnHelp.TabIndex = 3;
            this.btnHelp.Text = "YARDIM";
            // 
            // picLogo
            // 
            this.picLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.picLogo.Location = new System.Drawing.Point(0, 0);
            this.picLogo.Name = "picLogo";
            this.picLogo.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.picLogo.Properties.Appearance.Options.UseBackColor = true;
            this.picLogo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.picLogo.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.picLogo.Size = new System.Drawing.Size(1280, 80);
            this.picLogo.TabIndex = 4;
            // 
            // StaffDashboard
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 768);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.btnHelp);
            this.Name = "StaffDashboard";
            this.Text = "Ada Lovelady's Hotel - Personel Paneli";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblUserName;
        private System.Windows.Forms.TableLayoutPanel pnlMenu;
        private DevExpress.XtraEditors.SimpleButton btnNewCustomer;
        private DevExpress.XtraEditors.SimpleButton btnCertificates;
        private DevExpress.XtraEditors.SimpleButton btnCheckInOut;
        private DevExpress.XtraEditors.SimpleButton btnFloorPlan;
        private DevExpress.XtraEditors.SimpleButton btnCustomers;
        private DevExpress.XtraEditors.SimpleButton btnProfile;
        private DevExpress.XtraEditors.SimpleButton btnRevenue;
        private DevExpress.XtraEditors.SimpleButton btnRoomInfo;
        private DevExpress.XtraEditors.SimpleButton btnOccupancy;
        private DevExpress.XtraEditors.SimpleButton btnHelp;
        private DevExpress.XtraEditors.PictureEdit picLogo;
    }
}
