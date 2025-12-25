
namespace OtelOtomasyonu.Forms
{
    partial class IncomeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlTop = new DevExpress.XtraEditors.PanelControl();
            this.groupMonthly = new DevExpress.XtraEditors.GroupControl();
            this.lblMonthlyRatio = new DevExpress.XtraEditors.LabelControl();
            this.lblMonthlyNet = new DevExpress.XtraEditors.LabelControl();
            this.lblMonthlyExpense = new DevExpress.XtraEditors.LabelControl();
            this.lblMonthlyIncome = new DevExpress.XtraEditors.LabelControl();
            this.groupWeekly = new DevExpress.XtraEditors.GroupControl();
            this.lblWeeklyRatio = new DevExpress.XtraEditors.LabelControl();
            this.lblWeeklyNet = new DevExpress.XtraEditors.LabelControl();
            this.lblWeeklyExpense = new DevExpress.XtraEditors.LabelControl();
            this.lblWeeklyIncome = new DevExpress.XtraEditors.LabelControl();
            this.groupDaily = new DevExpress.XtraEditors.GroupControl();
            this.lblDailyRatio = new DevExpress.XtraEditors.LabelControl();
            this.lblDailyNet = new DevExpress.XtraEditors.LabelControl();
            this.lblDailyExpense = new DevExpress.XtraEditors.LabelControl();
            this.lblDailyIncome = new DevExpress.XtraEditors.LabelControl();
            this.pnlCenter = new DevExpress.XtraEditors.PanelControl();
            this.chartIncomeExpense = new DevExpress.XtraCharts.ChartControl();
            this.pnlHeader = new DevExpress.XtraEditors.PanelControl();
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.btnBack = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).BeginInit();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupMonthly)).BeginInit();
            this.groupMonthly.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupWeekly)).BeginInit();
            this.groupWeekly.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupDaily)).BeginInit();
            this.groupDaily.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCenter)).BeginInit();
            this.pnlCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartIncomeExpense)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.groupMonthly);
            this.pnlTop.Controls.Add(this.groupWeekly);
            this.pnlTop.Controls.Add(this.groupDaily);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 60);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1200, 220);
            this.pnlTop.TabIndex = 0;
            // 
            // groupMonthly
            // 
            this.groupMonthly.Controls.Add(this.lblMonthlyRatio);
            this.groupMonthly.Controls.Add(this.lblMonthlyNet);
            this.groupMonthly.Controls.Add(this.lblMonthlyExpense);
            this.groupMonthly.Controls.Add(this.lblMonthlyIncome);
            this.groupMonthly.Location = new System.Drawing.Point(820, 20);
            this.groupMonthly.Name = "groupMonthly";
            this.groupMonthly.Size = new System.Drawing.Size(350, 180);
            this.groupMonthly.TabIndex = 2;
            this.groupMonthly.Text = "Aylık Durum";
            // 
            // lblMonthlyRatio
            // 
            this.lblMonthlyRatio.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblMonthlyRatio.Appearance.ForeColor = System.Drawing.Color.Gold;
            this.lblMonthlyRatio.Location = new System.Drawing.Point(20, 140);
            this.lblMonthlyRatio.Name = "lblMonthlyRatio";
            this.lblMonthlyRatio.Size = new System.Drawing.Size(115, 21);
            this.lblMonthlyRatio.TabIndex = 3;
            this.lblMonthlyRatio.Text = "Gelir Oranı: %0";
            // 
            // lblMonthlyNet
            // 
            this.lblMonthlyNet.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblMonthlyNet.Appearance.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblMonthlyNet.Location = new System.Drawing.Point(20, 105);
            this.lblMonthlyNet.Name = "lblMonthlyNet";
            this.lblMonthlyNet.Size = new System.Drawing.Size(84, 20);
            this.lblMonthlyNet.TabIndex = 2;
            this.lblMonthlyNet.Text = "Net Kâr: 0 TL";
            // 
            // lblMonthlyExpense
            // 
            this.lblMonthlyExpense.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblMonthlyExpense.Appearance.ForeColor = System.Drawing.Color.IndianRed;
            this.lblMonthlyExpense.Location = new System.Drawing.Point(20, 70);
            this.lblMonthlyExpense.Name = "lblMonthlyExpense";
            this.lblMonthlyExpense.Size = new System.Drawing.Size(73, 20);
            this.lblMonthlyExpense.TabIndex = 1;
            this.lblMonthlyExpense.Text = "Gider: 0 TL";
            // 
            // lblMonthlyIncome
            // 
            this.lblMonthlyIncome.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblMonthlyIncome.Appearance.ForeColor = System.Drawing.Color.LightGreen;
            this.lblMonthlyIncome.Location = new System.Drawing.Point(20, 35);
            this.lblMonthlyIncome.Name = "lblMonthlyIncome";
            this.lblMonthlyIncome.Size = new System.Drawing.Size(69, 20);
            this.lblMonthlyIncome.TabIndex = 0;
            this.lblMonthlyIncome.Text = "Gelir: 0 TL";
            // 
            // groupWeekly
            // 
            this.groupWeekly.Controls.Add(this.lblWeeklyRatio);
            this.groupWeekly.Controls.Add(this.lblWeeklyNet);
            this.groupWeekly.Controls.Add(this.lblWeeklyExpense);
            this.groupWeekly.Controls.Add(this.lblWeeklyIncome);
            this.groupWeekly.Location = new System.Drawing.Point(425, 20);
            this.groupWeekly.Name = "groupWeekly";
            this.groupWeekly.Size = new System.Drawing.Size(350, 180);
            this.groupWeekly.TabIndex = 1;
            this.groupWeekly.Text = "Haftalık Durum";
            // 
            // lblWeeklyRatio
            // 
            this.lblWeeklyRatio.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblWeeklyRatio.Appearance.ForeColor = System.Drawing.Color.Gold;
            this.lblWeeklyRatio.Location = new System.Drawing.Point(20, 140);
            this.lblWeeklyRatio.Name = "lblWeeklyRatio";
            this.lblWeeklyRatio.Size = new System.Drawing.Size(115, 21);
            this.lblWeeklyRatio.TabIndex = 3;
            this.lblWeeklyRatio.Text = "Gelir Oranı: %0";
            // 
            // lblWeeklyNet
            // 
            this.lblWeeklyNet.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblWeeklyNet.Appearance.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblWeeklyNet.Location = new System.Drawing.Point(20, 105);
            this.lblWeeklyNet.Name = "lblWeeklyNet";
            this.lblWeeklyNet.Size = new System.Drawing.Size(84, 20);
            this.lblWeeklyNet.TabIndex = 2;
            this.lblWeeklyNet.Text = "Net Kâr: 0 TL";
            // 
            // lblWeeklyExpense
            // 
            this.lblWeeklyExpense.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblWeeklyExpense.Appearance.ForeColor = System.Drawing.Color.IndianRed;
            this.lblWeeklyExpense.Location = new System.Drawing.Point(20, 70);
            this.lblWeeklyExpense.Name = "lblWeeklyExpense";
            this.lblWeeklyExpense.Size = new System.Drawing.Size(73, 20);
            this.lblWeeklyExpense.TabIndex = 1;
            this.lblWeeklyExpense.Text = "Gider: 0 TL";
            // 
            // lblWeeklyIncome
            // 
            this.lblWeeklyIncome.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblWeeklyIncome.Appearance.ForeColor = System.Drawing.Color.LightGreen;
            this.lblWeeklyIncome.Location = new System.Drawing.Point(20, 35);
            this.lblWeeklyIncome.Name = "lblWeeklyIncome";
            this.lblWeeklyIncome.Size = new System.Drawing.Size(69, 20);
            this.lblWeeklyIncome.TabIndex = 0;
            this.lblWeeklyIncome.Text = "Gelir: 0 TL";
            // 
            // groupDaily
            // 
            this.groupDaily.Controls.Add(this.lblDailyRatio);
            this.groupDaily.Controls.Add(this.lblDailyNet);
            this.groupDaily.Controls.Add(this.lblDailyExpense);
            this.groupDaily.Controls.Add(this.lblDailyIncome);
            this.groupDaily.Location = new System.Drawing.Point(30, 20);
            this.groupDaily.Name = "groupDaily";
            this.groupDaily.Size = new System.Drawing.Size(350, 180);
            this.groupDaily.TabIndex = 0;
            this.groupDaily.Text = "Günlük Durum";
            // 
            // lblDailyRatio
            // 
            this.lblDailyRatio.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblDailyRatio.Appearance.ForeColor = System.Drawing.Color.Gold;
            this.lblDailyRatio.Location = new System.Drawing.Point(20, 140);
            this.lblDailyRatio.Name = "lblDailyRatio";
            this.lblDailyRatio.Size = new System.Drawing.Size(115, 21);
            this.lblDailyRatio.TabIndex = 3;
            this.lblDailyRatio.Text = "Gelir Oranı: %0";
            // 
            // lblDailyNet
            // 
            this.lblDailyNet.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblDailyNet.Appearance.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblDailyNet.Location = new System.Drawing.Point(20, 105);
            this.lblDailyNet.Name = "lblDailyNet";
            this.lblDailyNet.Size = new System.Drawing.Size(84, 20);
            this.lblDailyNet.TabIndex = 2;
            this.lblDailyNet.Text = "Net Kâr: 0 TL";
            // 
            // lblDailyExpense
            // 
            this.lblDailyExpense.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblDailyExpense.Appearance.ForeColor = System.Drawing.Color.IndianRed;
            this.lblDailyExpense.Location = new System.Drawing.Point(20, 70);
            this.lblDailyExpense.Name = "lblDailyExpense";
            this.lblDailyExpense.Size = new System.Drawing.Size(73, 20);
            this.lblDailyExpense.TabIndex = 1;
            this.lblDailyExpense.Text = "Gider: 0 TL";
            // 
            // lblDailyIncome
            // 
            this.lblDailyIncome.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblDailyIncome.Appearance.ForeColor = System.Drawing.Color.LightGreen;
            this.lblDailyIncome.Location = new System.Drawing.Point(20, 35);
            this.lblDailyIncome.Name = "lblDailyIncome";
            this.lblDailyIncome.Size = new System.Drawing.Size(69, 20);
            this.lblDailyIncome.TabIndex = 0;
            this.lblDailyIncome.Text = "Gelir: 0 TL";
            // 
            // pnlCenter
            // 
            this.pnlCenter.Controls.Add(this.chartIncomeExpense);
            this.pnlCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCenter.Location = new System.Drawing.Point(0, 280);
            this.pnlCenter.Name = "pnlCenter";
            this.pnlCenter.Size = new System.Drawing.Size(1200, 520);
            this.pnlCenter.TabIndex = 1;
            // 
            // chartIncomeExpense
            // 
            this.chartIncomeExpense.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartIncomeExpense.Legend.Name = "Default Legend";
            this.chartIncomeExpense.Location = new System.Drawing.Point(2, 2);
            this.chartIncomeExpense.Name = "chartIncomeExpense";
            this.chartIncomeExpense.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.chartIncomeExpense.Size = new System.Drawing.Size(1196, 516);
            this.chartIncomeExpense.TabIndex = 0;
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.btnBack);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1200, 60);
            this.pnlHeader.TabIndex = 2;
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Appearance.ForeColor = System.Drawing.Color.Gold;
            this.lblTitle.Location = new System.Drawing.Point(70, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(268, 30);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "GELİR VE FİNANSAL TABLO";
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
            // IncomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.Controls.Add(this.pnlCenter);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlHeader);
            this.Name = "IncomeForm";
            this.Text = "Gelir Durumu";
            this.Load += new System.EventHandler(this.IncomeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).EndInit();
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupMonthly)).EndInit();
            this.groupMonthly.ResumeLayout(false);
            this.groupMonthly.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupWeekly)).EndInit();
            this.groupWeekly.ResumeLayout(false);
            this.groupWeekly.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupDaily)).EndInit();
            this.groupDaily.ResumeLayout(false);
            this.groupDaily.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCenter)).EndInit();
            this.pnlCenter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartIncomeExpense)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlTop;
        private DevExpress.XtraEditors.PanelControl pnlCenter;
        private DevExpress.XtraEditors.PanelControl pnlHeader;
        private DevExpress.XtraCharts.ChartControl chartIncomeExpense;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.SimpleButton btnBack;

        private DevExpress.XtraEditors.GroupControl groupDaily;
        private DevExpress.XtraEditors.LabelControl lblDailyIncome;
        private DevExpress.XtraEditors.LabelControl lblDailyExpense;
        private DevExpress.XtraEditors.LabelControl lblDailyNet;
        private DevExpress.XtraEditors.LabelControl lblDailyRatio;

        private DevExpress.XtraEditors.GroupControl groupWeekly;
        private DevExpress.XtraEditors.LabelControl lblWeeklyIncome;
        private DevExpress.XtraEditors.LabelControl lblWeeklyExpense;
        private DevExpress.XtraEditors.LabelControl lblWeeklyNet;
        private DevExpress.XtraEditors.LabelControl lblWeeklyRatio;

        private DevExpress.XtraEditors.GroupControl groupMonthly;
        private DevExpress.XtraEditors.LabelControl lblMonthlyIncome;
        private DevExpress.XtraEditors.LabelControl lblMonthlyExpense;
        private DevExpress.XtraEditors.LabelControl lblMonthlyNet;
        private DevExpress.XtraEditors.LabelControl lblMonthlyRatio;
    }
}
