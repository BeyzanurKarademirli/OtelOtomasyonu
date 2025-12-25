
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using OtelOtomasyonu.Data.Entities;

namespace OtelOtomasyonu.Forms.Controls
{
    public partial class RoomControl : XtraUserControl
    {
        public int RoomId { get; set; }
        private string _roomNumber;
        private OtelOtomasyonu.Data.Entities.RoomStatus _status;

        public event EventHandler RoomClick;

        public RoomControl()
        {
            InitializeComponent();
            this.Click += RoomControl_Click;
            // lblRoomNumber removed
            
            // Transparent Background to show the map underneath
            this.BackColor = Color.Transparent; 
        }

        private void RoomControl_Click(object sender, EventArgs e)
        {
            RoomClick?.Invoke(this, e);
        }

        public string RoomNumber
        {
            get { return _roomNumber; }
            set
            {
                _roomNumber = value;
                _roomNumber = value;
                Invalidate(); // Redraw with new number
            }
        }

        public OtelOtomasyonu.Data.Entities.RoomStatus Status
        {
            get { return _status; }
            set
            {
                _status = value;
                UpdateVisuals();
            }
        }

        private void UpdateVisuals()
        {
            Color statusColor;
            string statusText;

            // Updated Luxury Scheme
            switch (_status)
            {
                case OtelOtomasyonu.Data.Entities.RoomStatus.Occupied:
                    statusColor = Color.FromArgb(200, 139, 0, 0); // Semi-transparent Dark Red
                    statusText = "DOLU";
                    break;
                case OtelOtomasyonu.Data.Entities.RoomStatus.Available:
                    statusColor = Color.FromArgb(200, 0, 100, 0);   // Semi-transparent Dark Green
                    statusText = "BOŞ";
                    break;
                case OtelOtomasyonu.Data.Entities.RoomStatus.Cleaning:
                    statusColor = Color.FromArgb(200, 255, 140, 0); // Semi-transparent Orange
                    statusText = "TEMİZLİK";
                    break;
                default:
                    statusColor = Color.FromArgb(200, 100, 100, 100); // Semi-transparent Gray
                    statusText = "BAKIM";
                    break;
            }

            pnlBadge.BackColor = statusColor;
            lblStatus.Text = statusText;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Determine Appearance Colors based on Status
            Color topColor, bottomColor;
            
            if (Status == RoomStatus.Available)
            {
                // Rich Emerald Green Gradient
                topColor = Color.FromArgb(0, 180, 0); 
                bottomColor = Color.FromArgb(0, 60, 0);
            }
            else
            {
                // Rich Post-Modern Red/Gray Gradient for Occupied
                topColor = Color.FromArgb(180, 40, 40);
                bottomColor = Color.FromArgb(80, 0, 0);
            }

            // Draw Gradient Background
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, topColor, bottomColor, 90F))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }

            // Draw Glass/Shine Effect (Top half semi-transparent white)
            Rectangle shineRect = new Rectangle(0, 0, Width, Height / 2);
            using (LinearGradientBrush shineBrush = new LinearGradientBrush(shineRect, Color.FromArgb(100, 255, 255, 255), Color.Transparent, 90F))
            {
                e.Graphics.FillRectangle(shineBrush, shineRect);
            }

            // Draw Border (Gold - Thicker)
            using (Pen pen = new Pen(Color.Gold, 3))
            {
                pen.Alignment = PenAlignment.Inset;
                e.Graphics.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
            }

            // Draw Text
            bool isVertical = Height > Width;
            
            using (SolidBrush textBrush = new SolidBrush(Color.White))
            using (Font font = new Font("Segoe UI", 10, FontStyle.Bold)) 
            {
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;

                if (isVertical)
                {
                    // Rotate Graphics for Vertical Text
                    e.Graphics.TranslateTransform(Width / 2, Height / 2);
                    e.Graphics.RotateTransform(-90); // Bottom to Top orientation
                    
                    // Draw Room Number (Centered)
                    e.Graphics.DrawString(RoomNumber, font, textBrush, 0, 0, sf);
                    
                    e.Graphics.ResetTransform();
                }
                else
                {
                    string text = $"{RoomNumber}\n{(Status == RoomStatus.Available ? "BOŞ" : "DOLU")}";
                    e.Graphics.DrawString(text, font, textBrush, ClientRectangle, sf);
                }
            }
        }
    }
}
