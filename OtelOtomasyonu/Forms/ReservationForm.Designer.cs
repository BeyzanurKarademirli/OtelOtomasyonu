namespace OtelOtomasyonu.Forms
{
    partial class ReservationForm
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
            this.panelTop = new DevExpress.XtraEditors.PanelControl();
            this.dtStart = new DevExpress.XtraEditors.DateEdit();
            this.dtEnd = new DevExpress.XtraEditors.DateEdit();
            this.lblStart = new DevExpress.XtraEditors.LabelControl();
            this.lblEnd = new DevExpress.XtraEditors.LabelControl();
            this.btnSearchRooms = new DevExpress.XtraEditors.SimpleButton();
            
            this.panelBottom = new DevExpress.XtraEditors.PanelControl();
            this.txtCustomerTC = new DevExpress.XtraEditors.TextEdit();
            this.lblTC = new DevExpress.XtraEditors.LabelControl();
            this.btnFindCustomer = new DevExpress.XtraEditors.SimpleButton();
            this.lblCustomerName = new DevExpress.XtraEditors.LabelControl();
            this.lblTotalPrice = new DevExpress.XtraEditors.LabelControl();
            this.btnCreateReservation = new DevExpress.XtraEditors.SimpleButton();

            this.gridControlRooms = new DevExpress.XtraGrid.GridControl();
            this.gridViewRooms = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.picBackground = new DevExpress.XtraEditors.PictureEdit();

            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).BeginInit();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEnd.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEnd.Properties)).BeginInit();
            
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).BeginInit();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerTC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBackground.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlRooms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewRooms)).BeginInit();
            this.SuspendLayout();

            // Panel Top (Date Selection)
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Height = 60;
            this.panelTop.Controls.Add(this.btnSearchRooms);
            this.panelTop.Controls.Add(this.lblEnd);
            this.panelTop.Controls.Add(this.lblStart);
            this.panelTop.Controls.Add(this.dtEnd);
            this.panelTop.Controls.Add(this.dtStart);

            this.lblStart.Text = "Giriş Tarihi:";
            this.lblStart.Location = new System.Drawing.Point(12, 20);
            
            this.dtStart.Location = new System.Drawing.Point(80, 17);
            this.dtStart.Size = new System.Drawing.Size(120, 20);

            this.lblEnd.Text = "Çıkış Tarihi:";
            this.lblEnd.Location = new System.Drawing.Point(220, 20);

            this.dtEnd.Location = new System.Drawing.Point(290, 17);
            this.dtEnd.Size = new System.Drawing.Size(120, 20);

            this.btnSearchRooms.Text = "Müsait Odaları Ara";
            this.btnSearchRooms.Location = new System.Drawing.Point(430, 15);
            this.btnSearchRooms.Click += new System.EventHandler(this.btnSearchRooms_Click);

            // Panel Bottom (Customer & Action)
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Height = 100;
            this.panelBottom.Controls.Add(this.btnCreateReservation);
            this.panelBottom.Controls.Add(this.lblTotalPrice);
            this.panelBottom.Controls.Add(this.lblCustomerName);
            this.panelBottom.Controls.Add(this.btnFindCustomer);
            this.panelBottom.Controls.Add(this.lblTC);
            this.panelBottom.Controls.Add(this.txtCustomerTC);

            this.lblTC.Text = "Müşteri T.C.:";
            this.lblTC.Location = new System.Drawing.Point(12, 20);

            this.txtCustomerTC.Location = new System.Drawing.Point(80, 17);
            this.txtCustomerTC.Size = new System.Drawing.Size(120, 20);

            this.btnFindCustomer.Text = "Bul";
            this.btnFindCustomer.Location = new System.Drawing.Point(210, 15);
            this.btnFindCustomer.Click += new System.EventHandler(this.btnFindCustomer_Click);

            this.lblCustomerName.Text = "Müşteri Seçilmedi";
            this.lblCustomerName.Location = new System.Drawing.Point(300, 20);
            this.lblCustomerName.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);

            this.lblTotalPrice.Text = "Toplam Tutar: 0.00 ₺";
            this.lblTotalPrice.Location = new System.Drawing.Point(12, 60);
            this.lblTotalPrice.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);

            this.btnCreateReservation.Text = "Rezervasyonu Tamamla";
            this.btnCreateReservation.Location = new System.Drawing.Point(430, 50);
            this.btnCreateReservation.Size = new System.Drawing.Size(150, 40);
            this.btnCreateReservation.Click += new System.EventHandler(this.btnCreateReservation_Click);

            // Grid Control
            this.gridControlRooms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlRooms.MainView = this.gridViewRooms;
            this.gridControlRooms.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gridViewRooms });

            this.gridViewRooms.GridControl = this.gridControlRooms;
            this.gridViewRooms.OptionsBehavior.Editable = false;
            this.gridViewRooms.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewRooms_FocusedRowChanged);

            // 
            // picBackground (Otel binası arka plan)
            // 
            this.picBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBackground.Location = new System.Drawing.Point(0, 0);
            this.picBackground.Name = "picBackground";
            this.picBackground.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.picBackground.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.picBackground.Size = new System.Drawing.Size(770, 700);
            this.picBackground.TabIndex = 0;
            // Arka plan görseli: picBackground.Properties.Image = Properties.Resources.HotelBuilding;
            this.picBackground.SendToBack();

            // Panel'leri yarı saydam yap
            this.panelTop.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panelTop.Appearance.Options.UseBackColor = true;
            this.panelBottom.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panelBottom.Appearance.Options.UseBackColor = true;
            // GridControl için yarı saydamlık GridView seviyesinde ayarlanacak

            // Form
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(770, 700);
            this.MaximumSize = new System.Drawing.Size(770, 700);
            this.Controls.Add(this.gridControlRooms);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.picBackground);
            this.Name = "ReservationForm";
            this.Text = "Ada Lovelady's Hotel - Yeni Rezervasyon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            ((System.ComponentModel.ISupportInitialize)(this.panelTop)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEnd.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEnd.Properties)).EndInit();
            
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCustomerTC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBackground.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlRooms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewRooms)).EndInit();
            this.ResumeLayout(false);
        }

        private DevExpress.XtraEditors.PictureEdit picBackground;
        private DevExpress.XtraEditors.PanelControl panelTop;
        private DevExpress.XtraEditors.DateEdit dtStart;
        private DevExpress.XtraEditors.DateEdit dtEnd;
        private DevExpress.XtraEditors.LabelControl lblStart;
        private DevExpress.XtraEditors.LabelControl lblEnd;
        private DevExpress.XtraEditors.SimpleButton btnSearchRooms;
        
        private DevExpress.XtraEditors.PanelControl panelBottom;
        private DevExpress.XtraEditors.TextEdit txtCustomerTC;
        private DevExpress.XtraEditors.LabelControl lblTC;
        private DevExpress.XtraEditors.SimpleButton btnFindCustomer;
        private DevExpress.XtraEditors.LabelControl lblCustomerName;
        private DevExpress.XtraEditors.LabelControl lblTotalPrice;
        private DevExpress.XtraEditors.SimpleButton btnCreateReservation;

        private DevExpress.XtraGrid.GridControl gridControlRooms;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewRooms;
    }
}
