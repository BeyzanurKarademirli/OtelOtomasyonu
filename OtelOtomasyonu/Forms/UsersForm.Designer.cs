
namespace OtelOtomasyonu.Forms
{
    partial class UsersForm
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
            this.tabControl = new DevExpress.XtraTab.XtraTabControl();
            this.tabStaff = new DevExpress.XtraTab.XtraTabPage();
            this.gridControlStaff = new DevExpress.XtraGrid.GridControl();
            this.gridViewStaff = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelStaffButtons = new DevExpress.XtraEditors.PanelControl();
            this.btnAddStaff = new DevExpress.XtraEditors.SimpleButton();
            this.btnUpdateStaff = new DevExpress.XtraEditors.SimpleButton();
            this.btnDeleteStaff = new DevExpress.XtraEditors.SimpleButton();
            
            this.tabCustomers = new DevExpress.XtraTab.XtraTabPage();
            this.gridControlCustomers = new DevExpress.XtraGrid.GridControl();
            this.gridViewCustomers = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelCustomerButtons = new DevExpress.XtraEditors.PanelControl();
            this.btnUpdateCustomer = new DevExpress.XtraEditors.SimpleButton();
            this.btnResendMail = new DevExpress.XtraEditors.SimpleButton();

            this.panelTopNavigation = new DevExpress.XtraEditors.PanelControl();
            this.btnTabStaff = new DevExpress.XtraEditors.SimpleButton();
            this.btnTabCustomers = new DevExpress.XtraEditors.SimpleButton();
            
            ((System.ComponentModel.ISupportInitialize)(this.tabControl)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabStaff.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlStaff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewStaff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelStaffButtons)).BeginInit();
            this.panelStaffButtons.SuspendLayout();
            
            this.tabCustomers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlCustomers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCustomers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelCustomerButtons)).BeginInit();
            this.panelCustomerButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelTopNavigation)).BeginInit();
            this.panelTopNavigation.SuspendLayout();
            this.SuspendLayout();

            // 
            // panelTopNavigation
            // 
            this.panelTopNavigation.Controls.Add(this.btnTabCustomers);
            this.panelTopNavigation.Controls.Add(this.btnTabStaff);
            this.panelTopNavigation.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopNavigation.Height = 60;
            this.panelTopNavigation.Appearance.BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            this.panelTopNavigation.Appearance.Options.UseBackColor = true;
            this.panelTopNavigation.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;

            System.Drawing.Font navFont = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);

            // btnTabStaff
            this.btnTabStaff.Text = "PERSONEL";
            this.btnTabStaff.Location = new System.Drawing.Point(20, 10);
            this.btnTabStaff.Size = new System.Drawing.Size(150, 40);
            this.btnTabStaff.Appearance.Font = navFont;
            this.btnTabStaff.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.btnTabStaff.Click += new System.EventHandler(this.btnTabStaff_Click);

            // btnTabCustomers
            this.btnTabCustomers.Text = "MÜŞTERİLER";
            this.btnTabCustomers.Location = new System.Drawing.Point(180, 10);
            this.btnTabCustomers.Size = new System.Drawing.Size(150, 40);
            this.btnTabCustomers.Appearance.Font = navFont;
            this.btnTabCustomers.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.btnTabCustomers.Click += new System.EventHandler(this.btnTabCustomers_Click);

            // 
            // tabControl
            // 
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 60);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedTabPage = this.tabStaff;
            this.tabControl.Size = new System.Drawing.Size(984, 601);
            this.tabControl.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabStaff,
            this.tabCustomers});
            this.tabControl.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False; // HIDE HEADER
            
            // 
            // tabStaff
            // 
            this.tabStaff.Controls.Add(this.gridControlStaff);
            this.tabStaff.Controls.Add(this.panelStaffButtons);
            this.tabStaff.Name = "tabStaff";
            this.tabStaff.Text = "Personel";

            // 
            // panelStaffButtons
            // 
            this.panelStaffButtons.Controls.Add(this.btnDeleteStaff);
            this.panelStaffButtons.Controls.Add(this.btnUpdateStaff);
            this.panelStaffButtons.Controls.Add(this.btnAddStaff);
            this.panelStaffButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelStaffButtons.Height = 50;
            this.panelStaffButtons.Appearance.BackColor = System.Drawing.Color.Black;
            this.panelStaffButtons.Appearance.Options.UseBackColor = true;
            this.panelStaffButtons.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;

            System.Drawing.Font btnFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);

            // btnAddStaff
            this.btnAddStaff.Text = "Personel Ekle";
            this.btnAddStaff.Location = new System.Drawing.Point(10, 10);
            this.btnAddStaff.Size = new System.Drawing.Size(100, 30);
            this.btnAddStaff.Appearance.Font = btnFont;
            this.btnAddStaff.Appearance.BackColor = System.Drawing.Color.Gold;
            this.btnAddStaff.Appearance.Options.UseBackColor = true;
            this.btnAddStaff.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.btnAddStaff.Click += new System.EventHandler(this.btnAddStaff_Click);

            // btnUpdateStaff
            this.btnUpdateStaff.Text = "Güncelle";
            this.btnUpdateStaff.Location = new System.Drawing.Point(120, 10);
            this.btnUpdateStaff.Size = new System.Drawing.Size(100, 30);
            this.btnUpdateStaff.Appearance.Font = btnFont;
            this.btnUpdateStaff.Appearance.BackColor = System.Drawing.Color.DimGray;
            this.btnUpdateStaff.Appearance.ForeColor = System.Drawing.Color.Gold;
            this.btnUpdateStaff.Appearance.Options.UseBackColor = true;
            this.btnUpdateStaff.Appearance.Options.UseForeColor = true;
            this.btnUpdateStaff.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.btnUpdateStaff.Click += new System.EventHandler(this.btnUpdateStaff_Click);

            // btnDeleteStaff
            this.btnDeleteStaff.Text = "Sil";
            this.btnDeleteStaff.Location = new System.Drawing.Point(230, 10);
            this.btnDeleteStaff.Size = new System.Drawing.Size(100, 30);
            this.btnDeleteStaff.Appearance.Font = btnFont;
            this.btnDeleteStaff.Appearance.BackColor = System.Drawing.Color.Maroon;
            this.btnDeleteStaff.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnDeleteStaff.Appearance.Options.UseBackColor = true;
            this.btnDeleteStaff.Appearance.Options.UseForeColor = true;
            this.btnDeleteStaff.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.btnDeleteStaff.Click += new System.EventHandler(this.btnDeleteStaff_Click);

            // 
            // gridControlStaff
            // 
            this.gridControlStaff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlStaff.MainView = this.gridViewStaff;
            this.gridControlStaff.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gridViewStaff });
            
            // 
            // gridViewStaff
            // 
            this.gridViewStaff.GridControl = this.gridControlStaff;
            this.gridViewStaff.OptionsBehavior.Editable = false;
            this.gridViewStaff.OptionsView.ShowGroupPanel = true;

            // 
            // tabCustomers
            // 
            this.tabCustomers.Controls.Add(this.gridControlCustomers);
            this.tabCustomers.Controls.Add(this.panelCustomerButtons);
            this.tabCustomers.Name = "tabCustomers";
            this.tabCustomers.Text = "Müşteriler";
            
            //
            // panelCustomerButtons
            //
            this.panelCustomerButtons.Controls.Add(this.btnResendMail);
            this.panelCustomerButtons.Controls.Add(this.btnUpdateCustomer);
            this.panelCustomerButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCustomerButtons.Height = 50;
            this.panelCustomerButtons.Appearance.BackColor = System.Drawing.Color.Black;
            this.panelCustomerButtons.Appearance.Options.UseBackColor = true;
            this.panelCustomerButtons.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;

            // btnUpdateCustomer
            this.btnUpdateCustomer.Text = "Düzenle";
            this.btnUpdateCustomer.Location = new System.Drawing.Point(10, 10);
            this.btnUpdateCustomer.Size = new System.Drawing.Size(100, 30);
            this.btnUpdateCustomer.Appearance.Font = btnFont;
            this.btnUpdateCustomer.Appearance.BackColor = System.Drawing.Color.Gold;
            this.btnUpdateCustomer.Appearance.Options.UseBackColor = true;
            this.btnUpdateCustomer.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.btnUpdateCustomer.Click += new System.EventHandler(this.btnUpdateCustomer_Click);

            // btnResendMail
            this.btnResendMail.Text = "Tekrar Mail Gönder";
            this.btnResendMail.Location = new System.Drawing.Point(120, 10);
            this.btnResendMail.Size = new System.Drawing.Size(150, 30);
            this.btnResendMail.Appearance.Font = btnFont;
            this.btnResendMail.Appearance.BackColor = System.Drawing.Color.DimGray;
            this.btnResendMail.Appearance.ForeColor = System.Drawing.Color.Gold;
            this.btnResendMail.Appearance.Options.UseBackColor = true;
            this.btnResendMail.Appearance.Options.UseForeColor = true;
            this.btnResendMail.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.btnResendMail.Click += new System.EventHandler(this.btnResendMail_Click);

            // 
            // gridControlCustomers
            // 
            this.gridControlCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlCustomers.MainView = this.gridViewCustomers;
            this.gridControlCustomers.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gridViewCustomers });

            // 
            // gridViewCustomers
            // 
            this.gridViewCustomers.GridControl = this.gridControlCustomers;
            this.gridViewCustomers.OptionsBehavior.Editable = false;
            this.gridViewCustomers.OptionsView.ShowGroupPanel = true;

            // 
            // UsersForm
            // 
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.panelTopNavigation);
            this.Name = "UsersForm";
            this.Text = "Kullanıcı Yönetimi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            ((System.ComponentModel.ISupportInitialize)(this.tabControl)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabStaff.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlStaff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewStaff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelStaffButtons)).EndInit();
            this.panelStaffButtons.ResumeLayout(false);
            
            this.tabCustomers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlCustomers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewCustomers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelCustomerButtons)).EndInit();
            this.panelCustomerButtons.ResumeLayout(false);
            
            ((System.ComponentModel.ISupportInitialize)(this.panelTopNavigation)).EndInit();
            this.panelTopNavigation.ResumeLayout(false);
            
            this.ResumeLayout(false);
        }

        private DevExpress.XtraEditors.PanelControl panelTopNavigation;
        private DevExpress.XtraEditors.SimpleButton btnTabStaff;
        private DevExpress.XtraEditors.SimpleButton btnTabCustomers;

        private DevExpress.XtraTab.XtraTabControl tabControl;
        private DevExpress.XtraTab.XtraTabPage tabStaff;
        private DevExpress.XtraTab.XtraTabPage tabCustomers;
        
        // Staff Controls
        private DevExpress.XtraGrid.GridControl gridControlStaff;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewStaff;
        private DevExpress.XtraEditors.PanelControl panelStaffButtons;
        private DevExpress.XtraEditors.SimpleButton btnAddStaff;
        private DevExpress.XtraEditors.SimpleButton btnUpdateStaff;
        private DevExpress.XtraEditors.SimpleButton btnDeleteStaff;

        // Customer Controls
        private DevExpress.XtraGrid.GridControl gridControlCustomers;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewCustomers;
        private DevExpress.XtraEditors.PanelControl panelCustomerButtons;
        private DevExpress.XtraEditors.SimpleButton btnUpdateCustomer;
        private DevExpress.XtraEditors.SimpleButton btnResendMail;
    }
}
