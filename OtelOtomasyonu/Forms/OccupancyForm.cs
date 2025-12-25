using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraCharts;
using OtelOtomasyonu.Services;
using OtelOtomasyonu.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace OtelOtomasyonu.Forms
{
    public partial class OccupancyForm : XtraForm
    {
        private RoomService _roomService;

        public OccupancyForm()
        {
            InitializeComponent();
            _roomService = new RoomService();
        }

        private void OccupancyForm_Load(object sender, EventArgs e)
        {
            ApplyTheme();
            LoadData();
        }

        private void ApplyTheme()
        {
            Color darkBg = Color.FromArgb(30, 30, 30);
            Color slightlyLighterBg = Color.FromArgb(40, 40, 40);

            this.Appearance.BackColor = darkBg;

            // Panels
            pnlHeader.Appearance.BackColor = darkBg;
            pnlHeader.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;

            pnlTop.Appearance.BackColor = darkBg;
            pnlTop.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            
            pnlCenter.Appearance.BackColor = darkBg;
            pnlCenter.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;

            // Chart Styling
            StyleChart(chartFloors, "Katlarda Doluluk (Dolu/Boş)", ViewType.StackedBar);
            StyleChart(chartTypes, "Kişi Sayısına Göre Doluluk", ViewType.Pie);
        }

        private void StyleChart(ChartControl chart, string titleText, ViewType viewType)
        {
            chart.AppearanceName = "Dark";
            chart.BackColor = Color.FromArgb(30, 30, 30);
            chart.BorderOptions.Visibility = DevExpress.Utils.DefaultBoolean.False;

            chart.Titles.Clear();
            ChartTitle title = new ChartTitle();
            title.Text = titleText;
            title.TextColor = Color.Gold;
            title.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            chart.Titles.Add(title);

            if (chart.Diagram is XYDiagram)
            {
                XYDiagram diag = (XYDiagram)chart.Diagram;
                diag.AxisX.Label.TextColor = Color.WhiteSmoke;
                diag.AxisY.Label.TextColor = Color.WhiteSmoke;
                diag.DefaultPane.BackColor = Color.Transparent;
                diag.DefaultPane.BorderVisible = false;
            }
        }

        private void LoadData()
        {
            var stats = _roomService.GetOccupancyStats();

            // 1. Overall Rate
            lblTotalOccupancy.Text = $"%{stats.OccupancyRate:F1}";
            
            // Color code overall rate
            if (stats.OccupancyRate < 30) lblTotalOccupancy.Appearance.ForeColor = Color.IndianRed;
            else if (stats.OccupancyRate < 70) lblTotalOccupancy.Appearance.ForeColor = Color.Gold;
            else lblTotalOccupancy.Appearance.ForeColor = Color.LightGreen;

            // 2. Floor Chart (Stacked Bar: Occupied vs Empty)
            chartFloors.Series.Clear();
            
            Series sOccupied = new Series("Dolu", ViewType.StackedBar);
            sOccupied.View.Color = Color.Gold;
            
            Series sEmpty = new Series("Boş", ViewType.StackedBar);
            sEmpty.View.Color = Color.FromArgb(100, 128, 128, 128); // Semi-transparent Gray

            // Ensure we show Floors 1 to 10 strictly
            for (int i = 1; i <= 10; i++)
            {
                // Find stats for this floor
                var fs = stats.FloorStats.FirstOrDefault(f => f.FloorNumber == i);
                
                string floorName = $"{i}. Kat";
                int occupiedCount = fs != null ? fs.Occupied : 0;
                // Default to 10 total if stats missing (or use fs.Total if present)
                int totalCount = fs != null ? fs.Total : 10; 
                int emptyCount = totalCount - occupiedCount;

                // Add points
                sOccupied.Points.Add(new SeriesPoint(floorName, occupiedCount));
                sEmpty.Points.Add(new SeriesPoint(floorName, emptyCount));
            }
            
            chartFloors.Series.Add(sOccupied);
            chartFloors.Series.Add(sEmpty);
            
            // Fix Axis Scale to show integers and all labels
            if (chartFloors.Diagram is XYDiagram)
            {
                XYDiagram diag = (XYDiagram)chartFloors.Diagram;
                
                // Y-Axis: Integer only (0, 1, 2... 10)
                diag.AxisY.WholeRange.SideMarginsValue = 0;
                diag.AxisY.NumericScaleOptions.AutoGrid = false;
                diag.AxisY.NumericScaleOptions.GridSpacing = 1;

                // X-Axis: Show all labels
                diag.AxisX.QualitativeScaleOptions.AutoGrid = false;
            }

            // 3. Type Chart (Pie)
            chartTypes.Series.Clear();
            Series sTypes = new Series("Oda Tipleri", ViewType.Pie);
            
            bool hasData = stats.TypeStats.Any(t => t.Occupied > 0);

            if (!hasData)
            {
                // Show "Empty" placeholder
                SeriesPoint p = new SeriesPoint("Otel Boş", 1);
                p.Color = Color.Gray;
                sTypes.Points.Add(p);
                
                // Optional: Hide detailed legend/labels for empty state if needed, 
                // but default is fine.
            }
            else
            {
                foreach (var ts in stats.TypeStats)
                {
                    if (ts.Occupied > 0) // Only show types that have occupancy
                    {
                        string typeName = GetTypeDisplayName(ts.Type);
                        sTypes.Points.Add(new SeriesPoint(typeName, ts.Occupied)); 
                    }
                }
            }
            
            // Pie Series Label Settings
            sTypes.Label.TextPattern = "{A}: {V}"; // Argument: Value
            ((PieSeriesLabel)sTypes.Label).Position = PieSeriesLabelPosition.TwoColumns;
            ((PieSeriesLabel)sTypes.Label).TextColor = Color.WhiteSmoke;

            chartTypes.Series.Add(sTypes);
        }

        private string GetTypeDisplayName(RoomType type)
        {
            switch (type)
            {
                case RoomType.Single: return "Tek Kişilik";
                case RoomType.Double: return "Çift Kişilik";
                case RoomType.Triple: return "3 Kişilik";
                case RoomType.Quadruple: return "4 Kişilik";
                case RoomType.Suite: return "Kral Dairesi";
                default: return type.ToString();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
