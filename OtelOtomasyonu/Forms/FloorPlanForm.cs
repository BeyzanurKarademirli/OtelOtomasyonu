using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using OtelOtomasyonu.Data;
using OtelOtomasyonu.Data.Entities;
using OtelOtomasyonu.Services;
using System.Drawing;
using OtelOtomasyonu.Forms.Controls;

namespace OtelOtomasyonu.Forms
{
    public partial class FloorPlanForm : XtraForm
    {
        private HotelContext _context;
        private int _currentFloor = 0; // Default Zemin Kat
        private List<RoomControl> _roomControls = new List<RoomControl>();
        
        // Coordinates for Upper Floors (Guest Rooms 101-110)
        // ALIGNED to "Ada Lovelady" Image Status Pillars (Wide Layout - Vertical Pills)
        private PointF[] _guestRoomLocations = new PointF[]
        {
            // Left Column (Approx 7.8% from left - CENTER of Pillar)
            new PointF(0.078f, 0.22f),   // 101
            new PointF(0.078f, 0.36f),   // 102
            new PointF(0.078f, 0.50f),   // 103
            new PointF(0.078f, 0.64f),   // 104
            new PointF(0.078f, 0.78f),   // 105
            
            // Right Column (Approx 92.2% from left - CENTER of Pillar)
            new PointF(0.922f, 0.22f),  // 106
            new PointF(0.922f, 0.36f),  // 107
            new PointF(0.922f, 0.50f),  // 108
            new PointF(0.922f, 0.64f),  // 109
            new PointF(0.922f, 0.78f)   // 110
        };

        public FloorPlanForm()
        {
            InitializeComponent();
            _context = new HotelContext();
            pnlMap.BackgroundImageLayout = ImageLayout.Stretch;
            pnlMap.Resize += PnlMap_Resize;
            
            // Apply Dark Theme
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.LookAndFeel.SkinName = "DevExpress Dark Style";
            ApplyTheme();
        }

        private void FloorPlanForm_Load(object sender, EventArgs e)
        {
            LoadFloors();
            LoadRoomsForFloor(_currentFloor);
        }

        private void ApplyTheme()
        {
            // Form background
            this.Appearance.BackColor = Color.Black;
            this.Appearance.Options.UseBackColor = true;
            
            // Sidebar
            if (pnlSidebar != null)
            {
                pnlSidebar.Appearance.BackColor = Color.FromArgb(20, 20, 20);
                pnlSidebar.Appearance.Options.UseBackColor = true;
            }
            
            // Floor list
            if (lstFloors != null)
            {
                lstFloors.Appearance.BackColor = Color.FromArgb(30, 30, 30);
                lstFloors.Appearance.ForeColor = Color.Gold;
                lstFloors.Appearance.Font = new Font("Segoe UI", 12F);
            }
            
            // Title label
            if (lblFloorsTitle != null)
            {
                lblFloorsTitle.Appearance.ForeColor = Color.Gold;
                lblFloorsTitle.Appearance.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            }
        }

        private void LoadFloors()
        {
            lstFloors.Items.Clear();
            lstFloors.Items.Add("Zemin Kat");
            for (int i = 1; i <= 10; i++)
            {
                lstFloors.Items.Add($"{i}. Kat");
            }
            lstFloors.SelectedIndex = 0;
        }

        private void LstFloors_SelectedIndexChanged(object sender, EventArgs e)
        {
            _currentFloor = lstFloors.SelectedIndex;
            LoadRoomsForFloor(_currentFloor);
        }

        private void LoadRoomsForFloor(int floor)
        {
            pnlMap.Controls.Clear();
            _roomControls.Clear();
            pnlMap.BackgroundImage = null; 

            string resourcePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources");
            string imageFileName = (floor == 0) ? "floor_ground.jpg" : "floor_upper.jpg";
            string fullPath = System.IO.Path.Combine(resourcePath, imageFileName);

            PictureBox pbBackground = null;

            if (System.IO.File.Exists(fullPath))
            {
                pbBackground = new PictureBox();
                try { pbBackground.Image = Image.FromFile(fullPath); } catch {}
                pbBackground.SizeMode = PictureBoxSizeMode.StretchImage;
                pbBackground.Dock = DockStyle.Fill;
                pbBackground.BackColor = Color.Black;
                pnlMap.Controls.Add(pbBackground);
            }
            else
            {
                pnlMap.BackColor = Color.Black;
            }

            if (floor == 0) return;

            var rooms = _context.Rooms.Where(r => r.Floor == floor).ToList();
            
            // Aktif ve gelecekteki rezervasyonları kontrol et (bugün ve gelecek için)
            var today = DateTime.Today;
            var activeReservations = _context.Reservations
                .Where(r => r.Status != ReservationStatus.Cancelled && 
                           r.Status != ReservationStatus.Completed &&
                           r.EndDate >= today) // Bugün veya gelecekte biten rezervasyonlar
                .ToList();
            
            for (int i = 0; i < _guestRoomLocations.Length; i++)
            {
                string targetNum = $"{floor * 100 + (i + 1)}";
                Room room = rooms.FirstOrDefault(r => r.RoomNumber == targetNum);

                RoomControl rc = new RoomControl();
                rc.Size = new Size(40, 100); 
                rc.Location = new Point(0,0);
                
                if (room != null)
                {
                    rc.RoomId = room.Id;
                    rc.RoomNumber = room.RoomNumber;
                    
                    // Rezervasyonları kontrol et - gerçek durumu göster
                    var roomReservations = activeReservations.Where(r => r.RoomId == room.Id).ToList();
                    if (roomReservations.Any())
                    {
                        // Aktif veya gelecekteki rezervasyon var, oda dolu
                        rc.Status = RoomStatus.Occupied;
                    }
                    else
                    {
                        // Aktif rezervasyon yok, oda durumunu göster
                        rc.Status = room.Status;
                    }
                    
                    rc.RoomClick += Rc_RoomClick;
                }
                else
                {
                    rc.RoomNumber = targetNum;
                    rc.Status = RoomStatus.Maintenance;
                }
                
                pnlMap.Controls.Add(rc);
                rc.BringToFront();
                _roomControls.Add(rc);
            }
            
            RepositionRooms();

            if (pbBackground != null) pbBackground.SendToBack();
        }

        private void PnlMap_Resize(object sender, EventArgs e)
        {
             RepositionRooms();
        }

        private void RepositionRooms()
        {
            if (_currentFloor == 0) return; 
            if (_roomControls == null || _roomControls.Count == 0) return;

            for (int i = 0; i < _roomControls.Count; i++)
            {
                if (i >= _guestRoomLocations.Length) break;

                RoomControl rc = _roomControls[i];
                PointF percentLoc = _guestRoomLocations[i];

                int x = (int)(pnlMap.Width * percentLoc.X);
                int y = (int)(pnlMap.Height * percentLoc.Y);
                
                x -= rc.Width / 2;
                y -= rc.Height / 2;

                rc.Location = new Point(x, y);
            }
        }

        private void Rc_RoomClick(object sender, EventArgs e)
        {
            RoomControl clickedRoom = sender as RoomControl;
            if (clickedRoom != null && clickedRoom.RoomId > 0 && clickedRoom.Status == RoomStatus.Available)
            {
                var room = _context.Rooms.Find(clickedRoom.RoomId);
                if (room != null)
                {
                    int personCount = 1;
                    if (room.Type == RoomType.Double) personCount = 2;
                    else if (room.Type == RoomType.Triple) personCount = 3;
                    else if (room.Type == RoomType.Quadruple) personCount = 4;
                    else if (room.Type == RoomType.Suite) personCount = 2;

                    string statusText = "DURUM: BOŞ";
                    if (room.Status == RoomStatus.Occupied) statusText = "DURUM: DOLU";
                    else if (room.Status == RoomStatus.Cleaning) statusText = "DURUM: TEMİZLİK";
                    else if (room.Status == RoomStatus.Maintenance) statusText = "DURUM: BAKIMDA";

                    using (var popup = new RoomDetailPopup(
                        room.RoomNumber, 
                        room.Description, 
                        room.Price, 
                        personCount,
                        statusText))
                    {
                        popup.ShowDialog();
                    }
                }
            }
            else if (clickedRoom != null && clickedRoom.RoomId > 0)
            {
                 XtraMessageBox.Show($"Oda: {clickedRoom.RoomNumber}\nDurum: {clickedRoom.Status}", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
