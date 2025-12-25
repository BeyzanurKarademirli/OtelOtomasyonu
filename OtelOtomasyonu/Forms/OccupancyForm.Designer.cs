
namespace OtelOtomasyonu.Forms
{
    partial class OccupancyForm
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
            this.pnlHeader = new DevExpress.XtraEditors.PanelControl();
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.btnBack = new DevExpress.XtraEditors.SimpleButton();
            
            this.pnlTop = new DevExpress.XtraEditors.PanelControl();
            this.lblTotalOccupancy = new DevExpress.XtraEditors.LabelControl();
            this.lblTotalLabel = new DevExpress.XtraEditors.LabelControl();

            this.pnlCenter = new DevExpress.XtraEditors.PanelControl();
            this.splitContainerCharts = new DevExpress.XtraEditors.SplitContainerControl();
            this.chartFloors = new DevExpress.XtraCharts.ChartControl();
            this.chartTypes = new DevExpress.XtraCharts.ChartControl();

            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).BeginInit();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).BeginInit();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCenter)).BeginInit();
            this.pnlCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerCharts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerCharts.Panel1)).BeginInit();
            this.splitContainerCharts.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerCharts.Panel2)).BeginInit();
            this.splitContainerCharts.Panel2.SuspendLayout();
            this.splitContainerCharts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartFloors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTypes)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.btnBack);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1200, 60);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Appearance.ForeColor = System.Drawing.Color.Gold;
            this.lblTitle.Location = new System.Drawing.Point(70, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(268, 30);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "ODA DOLULUK ANALİZİ";
            // 
            // btnBack
            // 
            this.btnBack.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnBack.Appearance.Options.UseBackColor = true;
            this.btnBack.Appearance.Options.UseFont = true;
            this.btnBack.Location = new System.Drawing.Point(10, 10);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(40, 40);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "<";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.lblTotalOccupancy);
            this.pnlTop.Controls.Add(this.lblTotalLabel);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 60);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1200, 100);
            this.pnlTop.TabIndex = 1;
            // 
            // lblTotalLabel
            // 
            this.lblTotalLabel.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblTotalLabel.Appearance.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblTotalLabel.Location = new System.Drawing.Point(50, 35);
            this.lblTotalLabel.Name = "lblTotalLabel";
            this.lblTotalLabel.Size = new System.Drawing.Size(170, 25);
            this.lblTotalLabel.TabIndex = 0;
            this.lblTotalLabel.Text = "Genel Doluluk Oranı:";
            // 
            // lblTotalOccupancy
            // 
            this.lblTotalOccupancy.Appearance.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblTotalOccupancy.Appearance.ForeColor = System.Drawing.Color.Gold;
            this.lblTotalOccupancy.Location = new System.Drawing.Point(240, 25);
            this.lblTotalOccupancy.Name = "lblTotalOccupancy";
            this.lblTotalOccupancy.Size = new System.Drawing.Size(63, 45);
            this.lblTotalOccupancy.TabIndex = 1;
            this.lblTotalOccupancy.Text = "%0";
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.splitContainerCharts);
            this.pnlCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCenter.Location = new System.Drawing.Point(0, 160);
            this.pnlCenter.Name = "pnlCenter";
            this.pnlCenter.Size = new System.Drawing.Size(1200, 640);
            this.pnlCenter.TabIndex = 2;
            // 
            // splitContainerCharts
            // 
            this.splitContainerCharts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerCharts.Location = new System.Drawing.Point(2, 2);
            this.splitContainerCharts.Name = "splitContainerCharts";
            this.splitContainerCharts.Panel1.Controls.Add(this.chartFloors);
            this.splitContainerCharts.Panel1.Text = "Panel1";
            this.splitContainerCharts.Panel2.Controls.Add(this.chartTypes);
            this.splitContainerCharts.Panel2.Text = "Panel2";
            this.splitContainerCharts.Size = new System.Drawing.Size(1196, 636);
            this.splitContainerCharts.SplitterPosition = 600;
            this.splitContainerCharts.TabIndex = 0;
            // 
            // chartFloors
            // 
            this.chartFloors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartFloors.Legend.Name = "Default Legend";
            this.chartFloors.Location = new System.Drawing.Point(0, 0);
            this.chartFloors.Name = "chartFloors";
            this.chartFloors.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.chartFloors.Size = new System.Drawing.Size(600, 636);
            this.chartFloors.TabIndex = 0;
            // 
            // chartTypes
            // 
            this.chartTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartTypes.Legend.Name = "Default Legend";
            this.chartTypes.Location = new System.Drawing.Point(0, 0);
            this.chartTypes.Name = "chartTypes";
            this.chartTypes.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.chartTypes.Size = new System.Drawing.Size(586, 636);
            this.chartTypes.TabIndex = 1;
            // 
            // OccupancyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.Controls.Add(this.pnlCenter);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlHeader);
            this.Name = "OccupancyForm";
            this.Text = "Oda Doluluk";
            this.Load += new System.EventHandler(this.OccupancyForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCenter)).EndInit();
            this.pnlCenter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerCharts.Panel1)).EndInit();
            this.splitContainerCharts.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerCharts.Panel2)).EndInit();
            this.splitContainerCharts.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerCharts)).EndInit();
            this.splitContainerCharts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartFloors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTypes)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlHeader;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.SimpleButton btnBack;
        
        private DevExpress.XtraEditors.PanelControl pnlTop;
        private DevExpress.XtraEditors.LabelControl lblTotalOccupancy;
        private DevExpress.XtraEditors.LabelControl lblTotalLabel;

        private DevExpress.XtraEditors.PanelControl pnlCenter;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerCharts;
        private DevExpress.XtraCharts.ChartControl chartFloors;
        private DevExpress.XtraCharts.ChartControl chartTypes;
    }
}
