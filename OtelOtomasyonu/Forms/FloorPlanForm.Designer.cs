namespace OtelOtomasyonu.Forms
{
    partial class FloorPlanForm
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
            this.panelRooms = new DevExpress.XtraEditors.PanelControl();
            this.panelHeader = new DevExpress.XtraEditors.PanelControl();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.cmbFloor = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblFloor = new DevExpress.XtraEditors.LabelControl();
            this.picLogo = new DevExpress.XtraEditors.PictureEdit();
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.panelLegend = new DevExpress.XtraEditors.PanelControl();
            this.lblLegend = new DevExpress.XtraEditors.LabelControl();
            this.picFloorPlan = new DevExpress.XtraEditors.PictureEdit();

            ((System.ComponentModel.ISupportInitialize)(this.panelRooms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelHeader)).BeginInit();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFloor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFloorPlan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelLegend)).BeginInit();
            this.panelLegend.SuspendLayout();
            this.SuspendLayout();

            // panelHeader
            this.panelHeader.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.panelHeader.Appearance.Options.UseBackColor = true;
            this.panelHeader.Controls.Add(this.lblLegend);
            this.panelHeader.Controls.Add(this.picLogo);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Controls.Add(this.lblFloor);
            this.panelHeader.Controls.Add(this.cmbFloor);
            this.panelHeader.Controls.Add(this.btnRefresh);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(770, 120);
            this.panelHeader.TabIndex = 0;

            // picLogo
            this.picLogo.Location = new System.Drawing.Point(10, 10);
            this.picLogo.Name = "picLogo";
            this.picLogo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.picLogo.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.picLogo.Size = new System.Drawing.Size(80, 80);
            this.picLogo.TabIndex = 0;

            // lblTitle
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Appearance.Options.UseFont = true;
            this.lblTitle.Appearance.Options.UseForeColor = true;
            this.lblTitle.Location = new System.Drawing.Point(100, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(200, 25);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Kat Planı Görünümü";

            // lblFloor
            this.lblFloor.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblFloor.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblFloor.Appearance.Options.UseFont = true;
            this.lblFloor.Appearance.Options.UseForeColor = true;
            this.lblFloor.Location = new System.Drawing.Point(100, 55);
            this.lblFloor.Name = "lblFloor";
            this.lblFloor.Size = new System.Drawing.Size(50, 19);
            this.lblFloor.TabIndex = 2;
            this.lblFloor.Text = "Kat:";

            // cmbFloor
            this.cmbFloor.Location = new System.Drawing.Point(160, 52);
            this.cmbFloor.Name = "cmbFloor";
            this.cmbFloor.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbFloor.Properties.Appearance.Options.UseFont = true;
            this.cmbFloor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbFloor.Size = new System.Drawing.Size(100, 26);
            this.cmbFloor.TabIndex = 3;
            this.cmbFloor.SelectedIndexChanged += new System.EventHandler(this.cmbFloor_SelectedIndexChanged);

            // btnRefresh
            this.btnRefresh.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnRefresh.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnRefresh.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Appearance.Options.UseBackColor = true;
            this.btnRefresh.Appearance.Options.UseFont = true;
            this.btnRefresh.Appearance.Options.UseForeColor = true;
            this.btnRefresh.Location = new System.Drawing.Point(280, 50);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 30);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Yenile";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // lblLegend
            this.lblLegend.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblLegend.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblLegend.Appearance.Options.UseFont = true;
            this.lblLegend.Appearance.Options.UseForeColor = true;
            this.lblLegend.Location = new System.Drawing.Point(400, 20);
            this.lblLegend.Name = "lblLegend";
            this.lblLegend.Size = new System.Drawing.Size(350, 80);
            this.lblLegend.TabIndex = 5;
            this.lblLegend.Text = "Renkler:\r\n🟢 Yeşil: Boş | 🔴 Kırmızı: Dolu | 🔵 Mavi: Rezerve\r\n🟠 Turuncu: Temizlik | ⚪ Gri: Bakım";

            // 
            // picFloorPlan (Kat planı görseli arka plan)
            // 
            this.picFloorPlan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picFloorPlan.Location = new System.Drawing.Point(0, 120);
            this.picFloorPlan.Name = "picFloorPlan";
            this.picFloorPlan.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.picFloorPlan.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.picFloorPlan.Size = new System.Drawing.Size(770, 580);
            this.picFloorPlan.TabIndex = 3;
            // Kat planı görseli: picFloorPlan.Properties.Image = Properties.Resources.FloorPlan;
            this.picFloorPlan.SendToBack();

            // panelRooms (Oda butonları görsel üzerinde)
            this.panelRooms.AutoScroll = true;
            this.panelRooms.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.panelRooms.Appearance.Options.UseBackColor = true;
            this.panelRooms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRooms.Location = new System.Drawing.Point(0, 120);
            this.panelRooms.Name = "panelRooms";
            this.panelRooms.Size = new System.Drawing.Size(770, 580);
            this.panelRooms.TabIndex = 1;

            // panelLegend
            this.panelLegend.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panelLegend.Appearance.Options.UseBackColor = true;
            this.panelLegend.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelLegend.Location = new System.Drawing.Point(0, 700);
            this.panelLegend.Name = "panelLegend";
            this.panelLegend.Size = new System.Drawing.Size(770, 0);
            this.panelLegend.TabIndex = 2;

            // Form
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(770, 700);
            this.Controls.Add(this.panelRooms);
            this.Controls.Add(this.picFloorPlan);
            this.Controls.Add(this.panelLegend);
            this.Controls.Add(this.panelHeader);
            this.MaximumSize = new System.Drawing.Size(770, 700);
            this.Name = "FloorPlanForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ada Lovelady's Hotel - Kat Planı";

            ((System.ComponentModel.ISupportInitialize)(this.panelRooms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelHeader)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFloor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFloorPlan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelLegend)).EndInit();
            this.panelLegend.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private DevExpress.XtraEditors.PictureEdit picFloorPlan;
        private DevExpress.XtraEditors.PanelControl panelRooms;
        private DevExpress.XtraEditors.PanelControl panelHeader;
        private DevExpress.XtraEditors.PictureEdit picLogo;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.LabelControl lblFloor;
        private DevExpress.XtraEditors.ComboBoxEdit cmbFloor;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.PanelControl panelLegend;
        private DevExpress.XtraEditors.LabelControl lblLegend;
    }
}

