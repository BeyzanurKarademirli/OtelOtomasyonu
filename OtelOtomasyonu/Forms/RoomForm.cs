
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using OtelOtomasyonu.Data;
using OtelOtomasyonu.Data.Entities;
using OtelOtomasyonu.Forms.Controls;
using System.Collections.Generic;

namespace OtelOtomasyonu.Forms
{
    public partial class RoomForm : DevExpress.XtraEditors.XtraForm
    {
        private HotelContext _context;
        private int _currentFloor = 0; // Default Zemin Kat
        private List<RoomControl> _roomControls = new List<RoomControl>();
        
        // Coordinates for Upper Floors (Guest Rooms 101-110)
        // ALIGNED to "Ada Lovelady" Image Status Pillars (Wide Layout - Vertical Pills)
        // Coordinates for Upper Floors (Guest Rooms 101-110)
        // RESPONSIVE: Using Percentages (0.0 to 1.0) relative to pnlMap Size
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

        // Coordinates for Ground Floor (Service Areas)
        private Point[] _serviceRoomLocations = new Point[]
        {
            new Point(200, 150), // ANA MUTFAK
            new Point(650, 150), // TEKNİK ODA
            new Point(800, 150), // YÖNETİM OFİSLERİ
            new Point(100, 350), // ANA RESTORAN
            new Point(120, 480), // BAGAJ ODASI
            new Point(150, 580), // RESEPSİYON
            new Point(750, 580)  // LOBİ BAR
        };

        public RoomForm()
        {
            InitializeComponent();
            _context = new HotelContext();
            pnlMap.BackgroundImageLayout = ImageLayout.Stretch;
            pnlMap.Resize += PnlMap_Resize;
        }

        private void RoomForm_Load(object sender, EventArgs e)
        {
            LoadFloors();
            EnsureAllRoomsAvailable(); // Seeds/Resets all rooms
            LoadRoomsForFloor(_currentFloor);
        }

        private void EnsureAllRoomsAvailable()
        {
            // 1. Cleanup Old Format Rooms (containing '-')
            var oldRooms = _context.Rooms.Where(r => r.RoomNumber.Contains("-")).ToList();
            if (oldRooms.Any())
            {
                _context.Rooms.RemoveRange(oldRooms);
                _context.SaveChanges();
            }

            // 2. Seed/Reset for Floors 1-10 (10 rooms each)
            for (int f = 1; f <= 10; f++)
            {
                for (int i = 0; i < 10; i++)
                {
                    // NEW FORMAT: 101, 102... 201...
                    string roomNum = $"{f * 100 + (i + 1)}";
                    
                    var room = _context.Rooms.FirstOrDefault(r => r.RoomNumber == roomNum);
                    
                    // Determine Type and Price based on Index (0-9)
                    RoomType type = RoomType.Single;
                    decimal price = 0;
                    string desc = "";

                    // 1-4 (Indices 0,1,2,3) -> Single (1 Person) -> 8000 TL
                    if (i >= 0 && i <= 3) 
                    {
                        type = RoomType.Single;
                        price = 8000;
                        desc = "Tek Kişilik Oda";
                        desc = "Tek Kişilik Oda";
                    }
                    // 5-8 (Indices 4,5,6,7) -> Double (2 Person) -> 6000 * 2 = 12000 TL
                    else if (i >= 4 && i <= 7)
                    {
                        type = RoomType.Double;
                        price = 12000;
                        desc = "Çift Kişilik Oda";
                        desc = "Çift Kişilik Oda";
                    }
                    // 9 (Index 8) -> Triple (3 Person) -> 4000 * 3 = 12000 TL
                    else if (i == 8)
                    {
                        type = RoomType.Triple;
                        price = 12000;
                        desc = "Üç Kişilik Oda";
                        desc = "Üç Kişilik Oda";
                    }
                    // 10 (Index 9) -> Quadruple (4 Person) -> 3000 * 4 = 12000 TL
                    else if (i == 9)
                    {
                        type = RoomType.Quadruple;
                        price = 12000;
                        desc = "Dört Kişilik Oda";
                        desc = "Dört Kişilik Oda";
                    }

                    if (room == null)
                    {
                        room = new Room
                        {
                            RoomNumber = roomNum,
                            Floor = f,
                            Type = type,
                            Price = price,
                            Status = RoomStatus.Available,
                            Description = desc
                        };
                        _context.Rooms.Add(room);
                    }
                    else
                    {
                        // Update existing details
                        room.Status = RoomStatus.Available;
                        room.Floor = f; 
                        room.Type = type;
                        room.Price = price;
                        room.Description = desc;
                    }
                }
            }
            
            // Ensure Ground Floor Service Rooms Exist
            if (!_context.Rooms.Any(r => r.Floor == 0))
            {
                _context.Rooms.Add(new Room { RoomNumber = "ANA MUTFAK", Floor = 0, Type = RoomType.Single, Price = 0, Status = RoomStatus.Available });
                _context.Rooms.Add(new Room { RoomNumber = "TEKNİK SERVIS", Floor = 0, Type = RoomType.Single, Price = 0, Status = RoomStatus.Occupied });
                _context.Rooms.Add(new Room { RoomNumber = "YÖNETİM", Floor = 0, Type = RoomType.Single, Price = 0, Status = RoomStatus.Available });
                _context.Rooms.Add(new Room { RoomNumber = "RESTORAN", Floor = 0, Type = RoomType.Single, Price = 0, Status = RoomStatus.Available });
                _context.Rooms.Add(new Room { RoomNumber = "BAGAJ ODASI", Floor = 0, Type = RoomType.Single, Price = 0, Status = RoomStatus.Available });
                _context.Rooms.Add(new Room { RoomNumber = "RESEPSİYON", Floor = 0, Type = RoomType.Single, Price = 0, Status = RoomStatus.Available });
                _context.Rooms.Add(new Room { RoomNumber = "LOBİ BAR", Floor = 0, Type = RoomType.Single, Price = 0, Status = RoomStatus.Available });
            }

            _context.SaveChanges();
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
            // Event subscription is in Designer now
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
                // Logic: Match room ending in '01', '02'... '10'
                // Since we used f*100 + (i+1), 101, 102...
                // Only look for rooms ON THIS FLOOR
                
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
        
        private void AddRoom(int floor, int slotIndex)
        {
             // Deprecated but kept for compilation safety
        }
    }
}

