namespace OtelOtomasyonu.Forms
{
    partial class AdminDashboard
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
            this.lblHotelName = new DevExpress.XtraEditors.LabelControl();
            this.lblUserName = new DevExpress.XtraEditors.LabelControl();
            this.pnlMenu = new System.Windows.Forms.TableLayoutPanel();
            this.btnOdaBilgisi = new DevExpress.XtraEditors.SimpleButton();
            this.btnPersonel = new DevExpress.XtraEditors.SimpleButton();
            this.btnGelir = new DevExpress.XtraEditors.SimpleButton();
            this.btnDoluluk = new DevExpress.XtraEditors.SimpleButton();
            this.btnRaporlar = new DevExpress.XtraEditors.SimpleButton();
            this.btnMusteri = new DevExpress.XtraEditors.SimpleButton();
            this.btnHelp = new DevExpress.XtraEditors.SimpleButton();
            this.picLogo = new DevExpress.XtraEditors.PictureEdit();
            this.pnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo.Properties)).BeginInit();
            
            // Stats Panel
            this.pnlStats = new DevExpress.XtraEditors.PanelControl();
            // Solid dark gray to ensure visibility
            this.pnlStats.Appearance.BackColor = System.Drawing.Color.FromArgb(40, 40, 40); 
            this.pnlStats.Appearance.Options.UseBackColor = true;
            this.pnlStats.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.pnlStats.Appearance.BorderColor = System.Drawing.Color.Gold;

            this.chartFinancial = new DevExpress.XtraCharts.ChartControl();
            this.tblStatsLabels = new System.Windows.Forms.TableLayoutPanel();
            this.lblDailyIncome = new DevExpress.XtraEditors.LabelControl();
            this.lblWeeklyIncome = new DevExpress.XtraEditors.LabelControl();
            this.lblMonthlyIncome = new DevExpress.XtraEditors.LabelControl();
            this.lblDailyExpense = new DevExpress.XtraEditors.LabelControl();
            this.lblWeeklyExpense = new DevExpress.XtraEditors.LabelControl();
            this.lblMonthlyExpense = new DevExpress.XtraEditors.LabelControl();

            ((System.ComponentModel.ISupportInitialize)(this.pnlStats)).BeginInit();
            this.pnlStats.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartFinancial)).BeginInit();
            this.tblStatsLabels.SuspendLayout();

            this.SuspendLayout();

            // 
            // pnlStats
            // 
            this.pnlStats.Controls.Add(this.chartFinancial);
            this.pnlStats.Controls.Add(this.tblStatsLabels);
            this.pnlStats.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlStats.Location = new System.Drawing.Point(0, 500);
            this.pnlStats.Name = "pnlStats";
            this.pnlStats.Size = new System.Drawing.Size(1280, 268);
            this.pnlStats.TabIndex = 10;
            this.pnlStats.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pnlStats.Appearance.Options.UseBackColor = true;
            this.pnlStats.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;

            // 
            // chartFinancial
            // 
            this.chartFinancial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartFinancial.Location = new System.Drawing.Point(0, 0);
            this.chartFinancial.Name = "chartFinancial";
            this.chartFinancial.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.chartFinancial.Size = new System.Drawing.Size(900, 268);
            this.chartFinancial.TabIndex = 0;
            // 
            // tblStatsLabels
            // 
            this.tblStatsLabels.ColumnCount = 2;
            this.tblStatsLabels.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblStatsLabels.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            
            this.tblStatsLabels.Controls.Add(this.lblDailyIncome, 0, 0);
            this.tblStatsLabels.Controls.Add(this.lblDailyExpense, 1, 0);
            this.tblStatsLabels.Controls.Add(this.lblWeeklyIncome, 0, 1);
            this.tblStatsLabels.Controls.Add(this.lblWeeklyExpense, 1, 1);
            this.tblStatsLabels.Controls.Add(this.lblMonthlyIncome, 0, 2);
            this.tblStatsLabels.Controls.Add(this.lblMonthlyExpense, 1, 2);
            
            this.tblStatsLabels.Dock = System.Windows.Forms.DockStyle.Right;
            this.tblStatsLabels.Location = new System.Drawing.Point(900, 0);
            this.tblStatsLabels.Name = "tblStatsLabels";
            this.tblStatsLabels.RowCount = 3;
            this.tblStatsLabels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tblStatsLabels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tblStatsLabels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tblStatsLabels.Size = new System.Drawing.Size(380, 268);
            this.tblStatsLabels.TabIndex = 1;
            // 
            // Labels Styling
            // 
            InitializeLabel(this.lblDailyIncome, "Günlük: 0 TL");
            InitializeLabel(this.lblWeeklyIncome, "Haftalık: 0 TL");
            InitializeLabel(this.lblMonthlyIncome, "Aylık: 0 TL");
            InitializeLabel(this.lblDailyExpense, "Gider (Gün): 0 TL");
            InitializeLabel(this.lblWeeklyExpense, "Gider (Hafta): 0 TL");
            InitializeLabel(this.lblMonthlyExpense, "Gider (Ay): 0 TL");

            // lblHotelName
            // 
            this.lblHotelName.Appearance.Font = new System.Drawing.Font("Times New Roman", 36F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHotelName.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(0))))); // Pure Gold
            this.lblHotelName.Appearance.Options.UseFont = true;
            this.lblHotelName.Appearance.Options.UseForeColor = true;
            this.lblHotelName.Appearance.Options.UseTextOptions = true;
            this.lblHotelName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblHotelName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblHotelName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHotelName.Location = new System.Drawing.Point(0, 80);
            this.lblHotelName.Name = "lblHotelName";
            this.lblHotelName.Padding = new System.Windows.Forms.Padding(0, 20, 0, 0);
            this.lblHotelName.Size = new System.Drawing.Size(1280, 80);
            this.lblHotelName.TabIndex = 0;
            this.lblHotelName.Text = "Ada Lovelady\'s Hotel";
            // 
            // lblUserName
            // 
            this.lblUserName.Appearance.Font = new System.Drawing.Font("Georgia", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(168)))), ((int)(((byte)(105))))); // Muted Gold
            this.lblUserName.Appearance.Options.UseFont = true;
            this.lblUserName.Appearance.Options.UseForeColor = true;
            this.lblUserName.Appearance.Options.UseTextOptions = true;
            this.lblUserName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblUserName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblUserName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblUserName.Location = new System.Drawing.Point(0, 160);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(1280, 50);
            this.lblUserName.TabIndex = 1;
            this.lblUserName.Text = "BEYZANUR KARADEMİRLİ (YÖNETİCİ)";
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.Transparent;
            this.pnlMenu.ColumnCount = 2;
            this.pnlMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlMenu.Controls.Add(this.btnOdaBilgisi, 0, 0);
            this.pnlMenu.Controls.Add(this.btnPersonel, 1, 0);
            this.pnlMenu.Controls.Add(this.btnGelir, 0, 1);
            this.pnlMenu.Controls.Add(this.btnDoluluk, 1, 1);
            this.pnlMenu.Controls.Add(this.btnRaporlar, 0, 2);
            this.pnlMenu.Controls.Add(this.btnMusteri, 1, 2);
            this.pnlMenu.Location = new System.Drawing.Point(240, 250);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.RowCount = 3;
            this.pnlMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.pnlMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.pnlMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.pnlMenu.Size = new System.Drawing.Size(800, 300);
            this.pnlMenu.TabIndex = 2;
            // 
            // btnOdaBilgisi
            // 
            this.btnOdaBilgisi.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular);
            this.btnOdaBilgisi.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnOdaBilgisi.Appearance.Options.UseFont = true;
            this.btnOdaBilgisi.Appearance.Options.UseForeColor = true;
            this.btnOdaBilgisi.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnOdaBilgisi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOdaBilgisi.Location = new System.Drawing.Point(20, 10);
            this.btnOdaBilgisi.Margin = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.btnOdaBilgisi.Name = "btnOdaBilgisi";
            this.btnOdaBilgisi.Size = new System.Drawing.Size(360, 80);
            this.btnOdaBilgisi.TabIndex = 0;
            this.btnOdaBilgisi.Text = "Oda Bilgisi";
            // 
            // btnPersonel
            // 
            this.btnPersonel.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular);
            this.btnPersonel.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnPersonel.Appearance.Options.UseFont = true;
            this.btnPersonel.Appearance.Options.UseForeColor = true;
            this.btnPersonel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnPersonel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPersonel.Location = new System.Drawing.Point(420, 10);
            this.btnPersonel.Margin = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.btnPersonel.Name = "btnPersonel";
            this.btnPersonel.Size = new System.Drawing.Size(360, 80);
            this.btnPersonel.TabIndex = 1;
            this.btnPersonel.Text = "Personel / Müşteri Bilgileri";
            // 
            // btnGelir
            // 
            this.btnGelir.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular);
            this.btnGelir.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnGelir.Appearance.Options.UseFont = true;
            this.btnGelir.Appearance.Options.UseForeColor = true;
            this.btnGelir.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnGelir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGelir.Location = new System.Drawing.Point(20, 110);
            this.btnGelir.Margin = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.btnGelir.Name = "btnGelir";
            this.btnGelir.Size = new System.Drawing.Size(360, 80);
            this.btnGelir.TabIndex = 2;
            this.btnGelir.Text = "Gelir Oranı";
            // 
            // btnDoluluk
            // 
            this.btnDoluluk.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular);
            this.btnDoluluk.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnDoluluk.Appearance.Options.UseFont = true;
            this.btnDoluluk.Appearance.Options.UseForeColor = true;
            this.btnDoluluk.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnDoluluk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDoluluk.Location = new System.Drawing.Point(420, 110);
            this.btnDoluluk.Margin = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.btnDoluluk.Name = "btnDoluluk";
            this.btnDoluluk.Size = new System.Drawing.Size(360, 80);
            this.btnDoluluk.TabIndex = 3;
            this.btnDoluluk.Text = "Oda Doluluk Oranı";
            // 
            // btnRaporlar
            // 
            this.btnRaporlar.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular);
            this.btnRaporlar.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnRaporlar.Appearance.Options.UseFont = true;
            this.btnRaporlar.Appearance.Options.UseForeColor = true;
            this.btnRaporlar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnRaporlar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRaporlar.Location = new System.Drawing.Point(20, 210);
            this.btnRaporlar.Margin = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.btnRaporlar.Name = "btnRaporlar";
            this.btnRaporlar.Size = new System.Drawing.Size(360, 80);
            this.btnRaporlar.TabIndex = 4;
            this.btnRaporlar.Text = "Raporlar";
            // 
            // btnMusteri
            // 
            this.btnMusteri.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular);
            this.btnMusteri.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnMusteri.Appearance.Options.UseFont = true;
            this.btnMusteri.Appearance.Options.UseForeColor = true;
            this.btnMusteri.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnMusteri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMusteri.Location = new System.Drawing.Point(420, 210);
            this.btnMusteri.Margin = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.btnMusteri.Name = "btnMusteri";
            this.btnMusteri.Size = new System.Drawing.Size(360, 80);
            this.btnMusteri.TabIndex = 5;
            this.btnMusteri.Text = "Müşteri Kaydı";
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelp.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnHelp.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnHelp.Appearance.Options.UseFont = true;
            this.btnHelp.Appearance.Options.UseForeColor = true;
            this.btnHelp.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnHelp.Location = new System.Drawing.Point(1150, 650);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(100, 100);
            this.btnHelp.TabIndex = 3;
            this.btnHelp.Text = "YARDIM";
            // 
            // picLogo (Centered Top Logo)
            // 
            this.picLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.picLogo.Location = new System.Drawing.Point(0, 0);
            this.picLogo.Name = "picLogo";
            this.picLogo.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.picLogo.Properties.Appearance.Options.UseBackColor = true;
            this.picLogo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.picLogo.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.picLogo.Size = new System.Drawing.Size(1280, 80);
            this.picLogo.TabIndex = 4;
            // 
            // AdminDashboard
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 768);
            this.Controls.Add(this.pnlStats);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.lblHotelName);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.btnHelp);
            this.Name = "AdminDashboard";
            this.Text = "Ada Lovelady\'s Hotel - Yönetim Paneli";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblHotelName;
        private DevExpress.XtraEditors.LabelControl lblUserName;
        private System.Windows.Forms.TableLayoutPanel pnlMenu;
        private DevExpress.XtraEditors.SimpleButton btnOdaBilgisi;
        private DevExpress.XtraEditors.SimpleButton btnPersonel;
        private DevExpress.XtraEditors.SimpleButton btnGelir;
        private DevExpress.XtraEditors.SimpleButton btnDoluluk;
        private DevExpress.XtraEditors.SimpleButton btnRaporlar;
        private DevExpress.XtraEditors.SimpleButton btnMusteri;
        private DevExpress.XtraEditors.SimpleButton btnHelp;
        private DevExpress.XtraEditors.PictureEdit picLogo;
        private void InitializeLabel(DevExpress.XtraEditors.LabelControl lbl, string text)
        {
            lbl.Text = text;
            lbl.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lbl.Appearance.ForeColor = System.Drawing.Color.Gold;
            lbl.Dock = System.Windows.Forms.DockStyle.Fill;
            lbl.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lbl.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            lbl.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
        }

        private DevExpress.XtraEditors.PanelControl pnlStats;
        private DevExpress.XtraCharts.ChartControl chartFinancial;
        private DevExpress.XtraEditors.LabelControl lblDailyIncome;
        private DevExpress.XtraEditors.LabelControl lblWeeklyIncome;
        private DevExpress.XtraEditors.LabelControl lblMonthlyIncome;
        private DevExpress.XtraEditors.LabelControl lblDailyExpense;
        private DevExpress.XtraEditors.LabelControl lblWeeklyExpense;
        private DevExpress.XtraEditors.LabelControl lblMonthlyExpense;
        private System.Windows.Forms.TableLayoutPanel tblStatsLabels;
    }
}
