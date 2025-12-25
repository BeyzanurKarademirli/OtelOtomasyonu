using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraCharts;
using OtelOtomasyonu.Services;
using System.Collections.Generic;

namespace OtelOtomasyonu.Forms
{
    public partial class IncomeForm : XtraForm
    {
        private FinancialService _financialService;

        public IncomeForm()
        {
            InitializeComponent();
            _financialService = new FinancialService();
        }

        private void IncomeForm_Load(object sender, EventArgs e)
        {
            // Set Luxury Theme Background
            Color darkBg = Color.FromArgb(30, 30, 30);
            this.Appearance.BackColor = darkBg;
            
            // Apply to Container Panels
            pnlHeader.Appearance.BackColor = darkBg;
            pnlHeader.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            
            pnlTop.Appearance.BackColor = darkBg;
            pnlTop.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            
            pnlCenter.Appearance.BackColor = darkBg;
            pnlCenter.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;

            // Apply to GroupControls (Transparent or Dark)
            ApplyGroupStyle(groupDaily);
            ApplyGroupStyle(groupWeekly);
            ApplyGroupStyle(groupMonthly);

            LoadKPIs();
            LoadChart();
        }

        private void ApplyGroupStyle(GroupControl group)
        {
            group.Appearance.BackColor = Color.FromArgb(40, 40, 40);
            group.AppearanceCaption.ForeColor = Color.Gold;
            group.AppearanceCaption.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            group.LookAndFeel.UseDefaultLookAndFeel = false;
            group.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
        }

        private void LoadKPIs()
        {
            var stats = _financialService.GetDashboardStats();

            // Helper to set group data
            SetGroupData(lblDailyIncome, lblDailyExpense, lblDailyNet, lblDailyRatio, stats.DailyIncome, stats.DailyExpense);
            SetGroupData(lblWeeklyIncome, lblWeeklyExpense, lblWeeklyNet, lblWeeklyRatio, stats.WeeklyIncome, stats.WeeklyExpense);
            SetGroupData(lblMonthlyIncome, lblMonthlyExpense, lblMonthlyNet, lblMonthlyRatio, stats.MonthlyIncome, stats.MonthlyExpense);
        }

        private void SetGroupData(LabelControl lblInc, LabelControl lblExp, LabelControl lblNet, LabelControl lblRatio, decimal inc, decimal exp)
        {
            decimal net = inc - exp;
            decimal ratio = 0;
            if (inc > 0 || exp > 0) // Avoid DBZ if both 0
            {
                // Simple ratio: Income / (Income + Expense) or just Profit Margin
                // User asked for "Gelir Oranı", let's assume Net Profit Margin % = (Net / Income) * 100
                // Or if Income is 0, ratio is 0.
                if (inc > 0)
                    ratio = (net / inc) * 100;
                else
                    ratio = -100; // Total loss if expense > 0 and income 0
            }

            lblInc.Text = $"Gelir: {inc:C2}";
            lblExp.Text = $"Gider: {exp:C2}";
            lblNet.Text = $"Net Kâr: {net:C2}";
            lblRatio.Text = $"Kâr Oranı: %{ratio:F2}";

            // Color Coding for Net
            if (net >= 0) lblNet.Appearance.ForeColor = Color.LightGreen;
            else lblNet.Appearance.ForeColor = Color.IndianRed;
        }

        private void LoadChart()
        {
            // Set Dark Theme for Chart
            chartIncomeExpense.AppearanceName = "Dark";
            chartIncomeExpense.BackColor = Color.FromArgb(30, 30, 30);
            
            // Customize Diagram (Axis Labels) if needed
            if (chartIncomeExpense.Diagram is XYDiagram)
            {
                XYDiagram diag = (XYDiagram)chartIncomeExpense.Diagram;
                diag.AxisX.Label.TextColor = Color.WhiteSmoke;
                diag.AxisY.Label.TextColor = Color.WhiteSmoke;
            }

            chartIncomeExpense.Series.Clear();

            // 1. Income Series (Green)
            Series sIncome = new Series("Gelir", ViewType.Line);
            sIncome.View.Color = Color.LimeGreen;
            ((LineSeriesView)sIncome.View).MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;

            // 2. Expense Series (Red)
            Series sExpense = new Series("Gider", ViewType.Line);
            sExpense.View.Color = Color.Red; // Or IndianRed
            ((LineSeriesView)sExpense.View).MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;

            // Fetch Data (Last 30 Days)
            List<DailyFinancialStat> trends = _financialService.GetDailyTrends(30);

            foreach (var day in trends)
            {
                sIncome.Points.Add(new SeriesPoint(day.Date.ToString("dd MMM"), day.Income));
                sExpense.Points.Add(new SeriesPoint(day.Date.ToString("dd MMM"), day.Expense));
            }

            chartIncomeExpense.Series.Add(sIncome);
            chartIncomeExpense.Series.Add(sExpense);

            // Chart Title
            chartIncomeExpense.Titles.Clear();
            ChartTitle title = new ChartTitle();
            title.Text = "Son 30 Gün Gelir/Gider Trendi";
            title.TextColor = Color.Gold;
            title.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            chartIncomeExpense.Titles.Add(title);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
