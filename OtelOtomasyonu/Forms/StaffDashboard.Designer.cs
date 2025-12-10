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
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            this.SuspendLayout();

            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.btnNewCustomer,
            this.btnNewReservation});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 3;
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

            // RibbonPage
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Resepsiyon";

            // RibbonPageGroup
            this.ribbonPageGroup1.ItemLinks.Add(this.btnNewCustomer);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnNewReservation);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Müşteri İşlemleri";

            // Form
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.ribbon);
            this.Name = "StaffDashboard";
            this.Ribbon = this.ribbon;
            this.Text = "Personel Paneli - Otel Otomasyonu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
