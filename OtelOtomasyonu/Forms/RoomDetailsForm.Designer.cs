namespace OtelOtomasyonu.Forms
{
    partial class RoomDetailsForm
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
            this.lblRoomNumber = new DevExpress.XtraEditors.LabelControl();
            this.lblRoomType = new DevExpress.XtraEditors.LabelControl();
            this.lblPrice = new DevExpress.XtraEditors.LabelControl();
            this.lblStatus = new DevExpress.XtraEditors.LabelControl();
            this.lblCustomer = new DevExpress.XtraEditors.LabelControl();
            this.lblCheckIn = new DevExpress.XtraEditors.LabelControl();
            this.lblCheckOut = new DevExpress.XtraEditors.LabelControl();
            this.panelControl = new DevExpress.XtraEditors.PanelControl();

            ((System.ComponentModel.ISupportInitialize)(this.panelControl)).BeginInit();
            this.panelControl.SuspendLayout();
            this.SuspendLayout();

            // panelControl
            this.panelControl.Controls.Add(this.lblCheckOut);
            this.panelControl.Controls.Add(this.lblCheckIn);
            this.panelControl.Controls.Add(this.lblCustomer);
            this.panelControl.Controls.Add(this.lblStatus);
            this.panelControl.Controls.Add(this.lblPrice);
            this.panelControl.Controls.Add(this.lblRoomType);
            this.panelControl.Controls.Add(this.lblRoomNumber);
            this.panelControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl.Location = new System.Drawing.Point(0, 0);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(400, 300);
            this.panelControl.TabIndex = 0;

            // Labels
            this.lblRoomNumber.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblRoomNumber.Location = new System.Drawing.Point(20, 20);
            this.lblRoomNumber.Name = "lblRoomNumber";
            this.lblRoomNumber.Size = new System.Drawing.Size(100, 25);
            this.lblRoomNumber.TabIndex = 0;

            this.lblRoomType.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblRoomType.Location = new System.Drawing.Point(20, 60);
            this.lblRoomType.Name = "lblRoomType";
            this.lblRoomType.Size = new System.Drawing.Size(100, 19);
            this.lblRoomType.TabIndex = 1;

            this.lblPrice.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblPrice.Location = new System.Drawing.Point(20, 90);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(100, 19);
            this.lblPrice.TabIndex = 2;

            this.lblStatus.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblStatus.Location = new System.Drawing.Point(20, 120);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(100, 19);
            this.lblStatus.TabIndex = 3;

            this.lblCustomer.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblCustomer.Location = new System.Drawing.Point(20, 160);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(100, 19);
            this.lblCustomer.TabIndex = 4;

            this.lblCheckIn.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblCheckIn.Location = new System.Drawing.Point(20, 190);
            this.lblCheckIn.Name = "lblCheckIn";
            this.lblCheckIn.Size = new System.Drawing.Size(100, 19);
            this.lblCheckIn.TabIndex = 5;

            this.lblCheckOut.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblCheckOut.Location = new System.Drawing.Point(20, 220);
            this.lblCheckOut.Name = "lblCheckOut";
            this.lblCheckOut.Size = new System.Drawing.Size(100, 19);
            this.lblCheckOut.TabIndex = 6;

            // Form
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(770, 700);
            this.MaximumSize = new System.Drawing.Size(770, 700);
            this.Controls.Add(this.panelControl);
            this.Name = "RoomDetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ada Lovelady's Hotel - Oda Detayları";

            ((System.ComponentModel.ISupportInitialize)(this.panelControl)).EndInit();
            this.panelControl.ResumeLayout(false);
            this.panelControl.PerformLayout();
            this.ResumeLayout(false);
        }

        private DevExpress.XtraEditors.PanelControl panelControl;
        private DevExpress.XtraEditors.LabelControl lblRoomNumber;
        private DevExpress.XtraEditors.LabelControl lblRoomType;
        private DevExpress.XtraEditors.LabelControl lblPrice;
        private DevExpress.XtraEditors.LabelControl lblStatus;
        private DevExpress.XtraEditors.LabelControl lblCustomer;
        private DevExpress.XtraEditors.LabelControl lblCheckIn;
        private DevExpress.XtraEditors.LabelControl lblCheckOut;
    }
}

