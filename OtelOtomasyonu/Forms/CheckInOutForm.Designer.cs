namespace OtelOtomasyonu.Forms
{
    partial class CheckInOutForm
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
            this.gridControlReservations = new DevExpress.XtraGrid.GridControl();
            this.gridViewReservations = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControlDetails = new DevExpress.XtraEditors.PanelControl();
            this.lblTotalPrice = new DevExpress.XtraEditors.LabelControl();
            this.lblCheckOutDate = new DevExpress.XtraEditors.LabelControl();
            this.lblCheckInDate = new DevExpress.XtraEditors.LabelControl();
            this.lblRoomNumber = new DevExpress.XtraEditors.LabelControl();
            this.lblCustomerName = new DevExpress.XtraEditors.LabelControl();
            this.btnCheckOut = new DevExpress.XtraEditors.SimpleButton();
            this.btnCheckIn = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();

            ((System.ComponentModel.ISupportInitialize)(this.gridControlReservations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewReservations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlDetails)).BeginInit();
            this.panelControlDetails.SuspendLayout();
            this.SuspendLayout();

            // gridControlReservations
            this.gridControlReservations.Dock = System.Windows.Forms.DockStyle.Top;
            this.gridControlReservations.Location = new System.Drawing.Point(0, 0);
            this.gridControlReservations.MainView = this.gridViewReservations;
            this.gridControlReservations.Name = "gridControlReservations";
            this.gridControlReservations.Size = new System.Drawing.Size(770, 300);
            this.gridControlReservations.TabIndex = 0;
            this.gridControlReservations.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gridViewReservations });

            // gridViewReservations
            this.gridViewReservations.GridControl = this.gridControlReservations;
            this.gridViewReservations.Name = "gridViewReservations";
            this.gridViewReservations.OptionsBehavior.Editable = false;
            this.gridViewReservations.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewReservations_FocusedRowChanged);

            // panelControlDetails
            this.panelControlDetails.Controls.Add(this.labelControl5);
            this.panelControlDetails.Controls.Add(this.labelControl4);
            this.panelControlDetails.Controls.Add(this.labelControl3);
            this.panelControlDetails.Controls.Add(this.labelControl2);
            this.panelControlDetails.Controls.Add(this.labelControl1);
            this.panelControlDetails.Controls.Add(this.lblTotalPrice);
            this.panelControlDetails.Controls.Add(this.lblCheckOutDate);
            this.panelControlDetails.Controls.Add(this.lblCheckInDate);
            this.panelControlDetails.Controls.Add(this.lblRoomNumber);
            this.panelControlDetails.Controls.Add(this.lblCustomerName);
            this.panelControlDetails.Controls.Add(this.btnCheckOut);
            this.panelControlDetails.Controls.Add(this.btnCheckIn);
            this.panelControlDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControlDetails.Location = new System.Drawing.Point(0, 300);
            this.panelControlDetails.Name = "panelControlDetails";
            this.panelControlDetails.Size = new System.Drawing.Size(770, 200);
            this.panelControlDetails.TabIndex = 1;

            // Labels
            this.labelControl1.Text = "Müşteri:";
            this.labelControl1.Location = new System.Drawing.Point(10, 15);
            this.labelControl1.Size = new System.Drawing.Size(80, 13);

            this.lblCustomerName.Text = "-";
            this.lblCustomerName.Location = new System.Drawing.Point(100, 15);
            this.lblCustomerName.Size = new System.Drawing.Size(200, 13);

            this.labelControl2.Text = "Oda:";
            this.labelControl2.Location = new System.Drawing.Point(10, 40);
            this.labelControl2.Size = new System.Drawing.Size(80, 13);

            this.lblRoomNumber.Text = "-";
            this.lblRoomNumber.Location = new System.Drawing.Point(100, 40);
            this.lblRoomNumber.Size = new System.Drawing.Size(100, 13);

            this.labelControl3.Text = "Giriş:";
            this.labelControl3.Location = new System.Drawing.Point(10, 65);
            this.labelControl3.Size = new System.Drawing.Size(80, 13);

            this.lblCheckInDate.Text = "-";
            this.lblCheckInDate.Location = new System.Drawing.Point(100, 65);
            this.lblCheckInDate.Size = new System.Drawing.Size(100, 13);

            this.labelControl4.Text = "Çıkış:";
            this.labelControl4.Location = new System.Drawing.Point(10, 90);
            this.labelControl4.Size = new System.Drawing.Size(80, 13);

            this.lblCheckOutDate.Text = "-";
            this.lblCheckOutDate.Location = new System.Drawing.Point(100, 90);
            this.lblCheckOutDate.Size = new System.Drawing.Size(100, 13);

            this.labelControl5.Text = "Toplam:";
            this.labelControl5.Location = new System.Drawing.Point(10, 115);
            this.labelControl5.Size = new System.Drawing.Size(80, 13);

            this.lblTotalPrice.Text = "0.00 ₺";
            this.lblTotalPrice.Location = new System.Drawing.Point(100, 115);
            this.lblTotalPrice.Size = new System.Drawing.Size(100, 13);

            // Buttons
            this.btnCheckIn.Text = "Check-In";
            this.btnCheckIn.Location = new System.Drawing.Point(300, 50);
            this.btnCheckIn.Size = new System.Drawing.Size(120, 40);
            this.btnCheckIn.Enabled = false;
            this.btnCheckIn.Click += new System.EventHandler(this.btnCheckIn_Click);

            this.btnCheckOut.Text = "Check-Out";
            this.btnCheckOut.Location = new System.Drawing.Point(450, 50);
            this.btnCheckOut.Size = new System.Drawing.Size(120, 40);
            this.btnCheckOut.Enabled = false;
            this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);

            // Form
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(770, 700);
            this.Controls.Add(this.panelControlDetails);
            this.Controls.Add(this.gridControlReservations);
            this.Name = "CheckInOutForm";
            this.Text = "Ada Lovelady's Hotel - Check-In / Check-Out İşlemleri";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.MaximumSize = new System.Drawing.Size(770, 700);

            ((System.ComponentModel.ISupportInitialize)(this.gridControlReservations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewReservations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlDetails)).EndInit();
            this.panelControlDetails.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private DevExpress.XtraGrid.GridControl gridControlReservations;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewReservations;
        private DevExpress.XtraEditors.PanelControl panelControlDetails;
        private DevExpress.XtraEditors.LabelControl lblCustomerName;
        private DevExpress.XtraEditors.LabelControl lblRoomNumber;
        private DevExpress.XtraEditors.LabelControl lblCheckInDate;
        private DevExpress.XtraEditors.LabelControl lblCheckOutDate;
        private DevExpress.XtraEditors.LabelControl lblTotalPrice;
        private DevExpress.XtraEditors.SimpleButton btnCheckIn;
        private DevExpress.XtraEditors.SimpleButton btnCheckOut;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
    }
}

