using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using OtelOtomasyonu.Data;
using OtelOtomasyonu.Data.Entities;
using OtelOtomasyonu.Services;
using System.Drawing;

namespace OtelOtomasyonu.Forms
{
    public partial class FloorPlanForm : XtraForm
    {
        private readonly RoomService _roomService;
        private readonly ReservationService _reservationService;
        private string _selectedFloor = "Zemin";
        private Dictionary<string, SimpleButton> _roomButtons;

        public FloorPlanForm()
        {
            InitializeComponent();
            _roomService = new RoomService();
            _reservationService = new ReservationService();
            _roomButtons = new Dictionary<string, SimpleButton>();
            LoadBackgroundImage();
            LoadFloors();
            LoadFloorPlan();
        }

        private void LoadBackgroundImage()
        {
            try
            {
                // Kat planı görseli Resources'dan yükle
                // picFloorPlan.Properties.Image = Properties.Resources.FloorPlan;
                // Görsel yoksa sessizce devam et
            }
            catch
            {
                // Görsel yoksa sessizce devam et
            }
        }

        private void LoadFloors()
        {
            cmbFloor.Properties.Items.Clear();
            cmbFloor.Properties.Items.AddRange(new object[] { "Zemin", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
            cmbFloor.SelectedIndex = 0;
        }

        private void LoadFloorPlan()
        {
            try
            {
                panelRooms.Controls.Clear();
                _roomButtons.Clear();

                using (var context = new HotelContext())
                {
                    var today = DateTime.Today;
                    var reservations = context.Reservations
                        .Where(r => r.Status == ReservationStatus.Confirmed || 
                                    r.Status == ReservationStatus.Pending)
                        .Where(r => r.StartDate <= today && r.EndDate >= today)
                        .ToList();

                    // Oda numaralandırması: 
                    // Zemin: 001-010 veya 101-110
                    // 1.Kat: 101-110, 2.Kat: 201-210, ..., 10.Kat: 1001-1010
                    List<Room> allRooms = context.Rooms.ToList();
                    List<Room> rooms;
                    
                    if (_selectedFloor == "Zemin")
                    {
                        // Zemin katı: 001-010 formatında
                        rooms = allRooms
                            .Where(r => r.RoomNumber.StartsWith("00") && r.RoomNumber.Length == 3)
                            .OrderBy(r => r.RoomNumber)
                            .ToList();
                        
                        // Eğer 001-010 formatında oda yoksa, 101-110'u kontrol et (alternatif numaralandırma)
                        if (!rooms.Any())
                        {
                            rooms = allRooms
                                .Where(r => {
                                    int roomNum;
                                    if (int.TryParse(r.RoomNumber, out roomNum))
                                        return roomNum >= 101 && roomNum <= 110;
                                    return false;
                                })
                                .OrderBy(r => r.RoomNumber)
                                .ToList();
                        }
                    }
                    else
                    {
                        int floorNum = int.Parse(_selectedFloor);
                        // Her kat için: 1.Kat=101-110, 2.Kat=201-210, ..., 10.Kat=1001-1010
                        int startRoom = floorNum * 100 + 1;
                        int endRoom = floorNum * 100 + 10;
                        
                        rooms = allRooms
                            .Where(r => {
                                int roomNum;
                                if (int.TryParse(r.RoomNumber, out roomNum))
                                {
                                    return roomNum >= startRoom && roomNum <= endRoom;
                                }
                                return false;
                            })
                            .OrderBy(r => r.RoomNumber)
                            .ToList();
                    }

                    // Her katta 10 oda olacak şekilde 2x5 grid düzeni
                    int x = 20, y = 20;
                    int buttonWidth = 130;
                    int buttonHeight = 90;
                    int spacing = 15;
                    int roomsPerRow = 5; // Her satırda 5 oda

                    // Eğer oda yoksa, beklenen 10 odayı göster (placeholder)
                    if (!rooms.Any())
                    {
                        for (int i = 1; i <= 10; i++)
                        {
                            string roomNumber = _selectedFloor == "Zemin" 
                                ? $"00{i:D2}" 
                                : $"{int.Parse(_selectedFloor) * 100 + i}";
                            
                            CreateRoomButton(roomNumber, RoomDisplayStatus.Available, 
                                new Point(x, y), new Size(buttonWidth, buttonHeight), null);
                            
                            x += buttonWidth + spacing;
                            if (i % roomsPerRow == 0)
                            {
                                x = 20;
                                y += buttonHeight + spacing;
                            }
                        }
                    }
                    else
                    {
                        // Mevcut odaları göster
                        foreach (var room in rooms)
                        {
                            var reservation = reservations.FirstOrDefault(r => r.RoomId == room.Id);
                            var status = GetRoomStatus(room, reservation);
                            
                            CreateRoomButton(room.RoomNumber, status, 
                                new Point(x, y), new Size(buttonWidth, buttonHeight), room);
                            
                            x += buttonWidth + spacing;
                            if (_roomButtons.Count % roomsPerRow == 0)
                            {
                                x = 20;
                                y += buttonHeight + spacing;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Kat planı yüklenirken hata: " + ex.Message);
            }
        }

        private RoomDisplayStatus GetRoomStatus(Room room, Reservation reservation)
        {
            if (reservation != null && reservation.Status == ReservationStatus.Confirmed)
                return RoomDisplayStatus.Occupied;
            if (reservation != null && reservation.Status == ReservationStatus.Pending)
                return RoomDisplayStatus.Reserved;
            if (room.Status == RoomStatus.Cleaning)
                return RoomDisplayStatus.Cleaning;
            if (room.Status == RoomStatus.Maintenance)
                return RoomDisplayStatus.Maintenance;
            return RoomDisplayStatus.Available;
        }

        private Color GetStatusColor(RoomDisplayStatus status)
        {
            switch (status)
            {
                case RoomDisplayStatus.Available:
                    return Color.FromArgb(76, 175, 80); // Yeşil
                case RoomDisplayStatus.Occupied:
                    return Color.FromArgb(244, 67, 54); // Kırmızı
                case RoomDisplayStatus.Reserved:
                    return Color.FromArgb(33, 150, 243); // Mavi
                case RoomDisplayStatus.Cleaning:
                    return Color.FromArgb(255, 152, 0); // Turuncu
                case RoomDisplayStatus.Maintenance:
                    return Color.FromArgb(158, 158, 158); // Gri
                default:
                    return Color.Gray;
            }
        }

        private string GetStatusText(RoomDisplayStatus status)
        {
            switch (status)
            {
                case RoomDisplayStatus.Available:
                    return "Boş";
                case RoomDisplayStatus.Occupied:
                    return "Dolu";
                case RoomDisplayStatus.Reserved:
                    return "Rezerve";
                case RoomDisplayStatus.Cleaning:
                    return "Temizlik";
                case RoomDisplayStatus.Maintenance:
                    return "Bakım";
                default:
                    return "-";
            }
        }

        private void BtnRoom_Click(object sender, EventArgs e)
        {
            var btn = sender as SimpleButton;
            var room = btn?.Tag as Room;
            if (room != null)
            {
                var roomForm = new RoomDetailsForm(room);
                roomForm.ShowDialog();
                LoadFloorPlan(); // Yenile
            }
        }

        private void CreateRoomButton(string roomNumber, RoomDisplayStatus status, Point location, Size size, Room room)
        {
            var btnRoom = new SimpleButton
            {
                Text = $"{roomNumber}\r\n{GetStatusText(status)}",
                Location = location,
                Size = size,
                Appearance = { 
                    BackColor = GetStatusColor(status),
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                    TextOptions = { HAlignment = DevExpress.Utils.HorzAlignment.Center, VAlignment = DevExpress.Utils.VertAlignment.Center }
                },
                Tag = room
            };

            if (room != null)
            {
                btnRoom.Click += BtnRoom_Click;
            }
            
            panelRooms.Controls.Add(btnRoom);
            _roomButtons[roomNumber] = btnRoom;
        }

        private void cmbFloor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFloor.SelectedItem != null)
            {
                _selectedFloor = cmbFloor.SelectedItem.ToString();
                LoadFloorPlan();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadFloorPlan();
        }
    }

    public enum RoomDisplayStatus
    {
        Available,
        Occupied,
        Reserved,
        Cleaning,
        Maintenance
    }
}

