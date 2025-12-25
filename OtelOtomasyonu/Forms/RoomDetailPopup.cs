using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace OtelOtomasyonu.Forms
{
    public partial class RoomDetailPopup : XtraForm
    {
        public RoomDetailPopup(string roomNumber, string type, decimal totalPrice, int personCount, string status)
        {
            InitializeComponent();
            ApplyCustomTheme();
            
            lblRoomNumber.Text = $"ODA {roomNumber}";
            lblType.Text = type;
            lblStatus.Text = status; // "DURUM: BOŞ" etc.
            
            // Fiyat Formatı
            if (personCount > 1)
            {
                decimal perPerson = totalPrice / personCount;
                lblPrice.Text = $"Toplam: {totalPrice:C2}\n(Kişi Başı: {perPerson:C2})";
            }
            else
            {
                lblPrice.Text = $"{totalPrice:C2}";
            }
        }

        private void ApplyCustomTheme()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Size = new Size(400, 350); // Increased height slightly
            this.BackColor = Color.Black;
            
            // Gold Border Panel
            Panel pnlBorder = new Panel();
            pnlBorder.Dock = DockStyle.Fill;
            pnlBorder.Padding = new Padding(2);
            pnlBorder.BackColor = Color.Gold;
            this.Controls.Add(pnlBorder);

            // Container Panel
            Panel pnlContainer = new Panel();
            pnlContainer.Dock = DockStyle.Fill;
            pnlContainer.BackColor = Color.FromArgb(10, 10, 10); // Soft Black
            pnlBorder.Controls.Add(pnlContainer);

            // Close Button
            SimpleButton btnClose = new SimpleButton();
            btnClose.Text = "KAPAT";
            btnClose.Size = new Size(100, 35);
            btnClose.Location = new Point(150, 290); // Moved down
            btnClose.Appearance.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnClose.Appearance.ForeColor = Color.Black;
            btnClose.Appearance.BackColor = Color.Gold;
            btnClose.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            btnClose.Click += (s, e) => this.Close();
            pnlContainer.Controls.Add(btnClose);

            // Labels
            AddLabel(pnlContainer, lblRoomNumber, 20, 24, FontStyle.Bold);
            AddLabel(pnlContainer, lblType, 70, 14, FontStyle.Regular);
            AddLabel(pnlContainer, lblStatus, 105, 12, FontStyle.Bold, Color.LightGray);
            AddLabel(pnlContainer, lblPrice, 140, 16, FontStyle.Bold, Color.Gold, 80); // Increased height for 2 lines
        }

        private void AddLabel(Panel parent, LabelControl lbl, int top, float fontSize, FontStyle style, Color? color = null, int height = 0)
        {
            lbl.Appearance.Font = new Font("Segoe UI", fontSize, style);
            lbl.Appearance.ForeColor = color ?? Color.White;
            lbl.Appearance.Options.UseFont = true;
            lbl.Appearance.Options.UseForeColor = true;
            lbl.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            lbl.AutoSizeMode = LabelAutoSizeMode.None;
            // Use provided height or calc default
            lbl.Size = new Size(380, height > 0 ? height : (int)(fontSize * 2.5)); 
            lbl.Location = new Point(10, top);
            parent.Controls.Add(lbl);
        }

        private LabelControl lblRoomNumber = new LabelControl();
        private LabelControl lblType = new LabelControl();
        private LabelControl lblStatus = new LabelControl(); // Changed from Capacity
        private LabelControl lblPrice = new LabelControl();
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        }
    }
}
