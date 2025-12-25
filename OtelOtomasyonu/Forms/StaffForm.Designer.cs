namespace OtelOtomasyonu.Forms
{
    partial class StaffForm
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();

            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            
            // 
            // panelControl1 (Top Button Bar)
            // 
            this.panelControl1.Controls.Add(this.btnDelete);
            this.panelControl1.Controls.Add(this.btnUpdate);
            this.panelControl1.Controls.Add(this.btnAdd);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Height = 60;
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.Black;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;

            // Common Button Style
            System.Drawing.Font btnFont = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            System.Drawing.Color goldColor = System.Drawing.Color.Gold;

            // 
            // btnAdd
            // 
            this.btnAdd.Text = "+ Personel Ekle";
            this.btnAdd.Appearance.Font = btnFont;
            this.btnAdd.Appearance.BackColor = goldColor;
            this.btnAdd.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnAdd.Appearance.Options.UseBackColor = true;
            this.btnAdd.Appearance.Options.UseFont = true;
            this.btnAdd.Appearance.Options.UseForeColor = true;
            this.btnAdd.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.btnAdd.Location = new System.Drawing.Point(20, 15);
            this.btnAdd.Size = new System.Drawing.Size(150, 30);
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // 
            // btnUpdate
            // 
            this.btnUpdate.Text = "Güncelle";
            this.btnUpdate.Appearance.Font = btnFont;
            this.btnUpdate.Appearance.BackColor = System.Drawing.Color.FromArgb(50, 50, 50); // Dark Gray
            this.btnUpdate.Appearance.ForeColor = goldColor;
            this.btnUpdate.Appearance.Options.UseBackColor = true;
            this.btnUpdate.Appearance.Options.UseFont = true;
            this.btnUpdate.Appearance.Options.UseForeColor = true;
            this.btnUpdate.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.btnUpdate.Location = new System.Drawing.Point(190, 15);
            this.btnUpdate.Size = new System.Drawing.Size(120, 30);
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);

            // 
            // btnDelete
            // 
            this.btnDelete.Text = "Sil";
            this.btnDelete.Appearance.Font = btnFont;
            this.btnDelete.Appearance.BackColor = System.Drawing.Color.DarkRed; 
            this.btnDelete.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Appearance.Options.UseBackColor = true;
            this.btnDelete.Appearance.Options.UseFont = true;
            this.btnDelete.Appearance.Options.UseForeColor = true;
            this.btnDelete.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnDelete.Location = new System.Drawing.Point(850, 15); // Anchor Right
            this.btnDelete.Size = new System.Drawing.Size(100, 30);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gridView1 });

            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = true;
            this.gridView1.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways;
            
            // Theme Grid
            this.gridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Gold;
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.gridView1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;

            this.gridView1.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(20, 20, 20); // Very Dark Grey
            this.gridView1.Appearance.Row.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.Row.Options.UseBackColor = true;
            this.gridView1.Appearance.Row.Options.UseForeColor = true;
            
            this.gridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;

            this.gridView1.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            this.gridView1.Appearance.OddRow.Options.UseBackColor = true;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            
            // Empty Space (Fixes white bottom)
            this.gridView1.Appearance.Empty.BackColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.Empty.Options.UseBackColor = true;

            // Group Rows
            this.gridView1.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(10, 10, 10);
            this.gridView1.Appearance.GroupRow.ForeColor = System.Drawing.Color.Gold;
            this.gridView1.Appearance.GroupRow.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gridView1.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupRow.Options.UseForeColor = true;
            
            // Group Panel (Top Drag Area)
            this.gridView1.Appearance.GroupPanel.BackColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.GroupPanel.ForeColor = System.Drawing.Color.Gold;
            this.gridView1.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupPanel.Options.UseForeColor = true;
            
            // Filter Panel (Bottom)
            this.gridView1.Appearance.FilterPanel.BackColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.FilterPanel.ForeColor = System.Drawing.Color.Gold;
            this.gridView1.Appearance.FilterPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.FilterPanel.Options.UseForeColor = true;

            // Footer
            this.gridView1.Appearance.FooterPanel.BackColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Gold;
            this.gridView1.Appearance.FooterPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.FooterPanel.Options.UseForeColor = true;
            
            // Borders
            this.gridView1.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.gridView1.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView1.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            this.gridView1.Appearance.HorzLine.Options.UseBackColor = true;

            // Hide Indicator (optional, but cleaner)
            this.gridView1.OptionsView.ShowIndicator = false;

            // Form
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panelControl1);
            this.Name = "StaffForm";
            this.Text = "Ada Lovelady's Hotel - Personel Yönetimi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.SimpleButton btnUpdate;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
    }
}
