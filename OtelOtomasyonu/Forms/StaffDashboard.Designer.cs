namespace OtelOtomasyonu.Forms
{
    partial class StaffDashboard
    {
        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem btnNewCustomer;
        private DevExpress.XtraBars.BarButtonItem btnNewReservation;
        private DevExpress.XtraBars.BarButtonItem btnCheckInOut;
        private DevExpress.XtraBars.BarButtonItem btnFloorPlan;

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
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btnNewCustomer = new DevExpress.XtraBars.BarButtonItem();
            this.btnNewReservation = new DevExpress.XtraBars.BarButtonItem();
            this.btnCheckInOut = new DevExpress.XtraBars.BarButtonItem();
            this.btnFloorPlan = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            this.SuspendLayout();

            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.btnNewCustomer,
            this.btnNewReservation,
            this.btnCheckInOut,
            this.btnFloorPlan});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 5;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.Size = new System.Drawing.Size(800, 150);

            // btnNewCustomer
            this.btnNewCustomer.Caption = "Yeni Müşteri Kaydı";
            this.btnNewCustomer.Id = 1;
            this.btnNewCustomer.ImageOptions.ImageUri.Uri = "Add";
            this.btnNewCustomer.Name = "btnNewCustomer";
            this.btnNewCustomer.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNewCustomer_ItemClick);

            // 
            // btnNewReservation
            // 
            this.btnNewReservation.Caption = "Yeni Rezervasyon";
            this.btnNewReservation.Id = 2;
            this.btnNewReservation.ImageOptions.ImageUri.Uri = "Calendar";
            this.btnNewReservation.Name = "btnNewReservation";
            this.btnNewReservation.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNewReservation_ItemClick);

            // btnCheckInOut
            this.btnCheckInOut.Caption = "Check-In/Check-Out";
            this.btnCheckInOut.Id = 3;
            this.btnCheckInOut.ImageOptions.ImageUri.Uri = "Check";
            this.btnCheckInOut.Name = "btnCheckInOut";
            this.btnCheckInOut.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCheckInOut_ItemClick);

            // btnFloorPlan
            this.btnFloorPlan.Caption = "Kat Planı";
            this.btnFloorPlan.Id = 4;
            this.btnFloorPlan.ImageOptions.ImageUri.Uri = "Map";
            this.btnFloorPlan.Name = "btnFloorPlan";
            this.btnFloorPlan.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFloorPlan_ItemClick);

            // RibbonPage
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Resepsiyon";

            // RibbonPageGroup
            this.ribbonPageGroup1.ItemLinks.Add(this.btnNewCustomer);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnNewReservation);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnCheckInOut);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnFloorPlan);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Müşteri İşlemleri";

            // Form
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.ribbon);
            this.Name = "StaffDashboard";
            this.Ribbon = this.ribbon;
            this.Text = "Ada Lovelady's Hotel - Personel Paneli";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
