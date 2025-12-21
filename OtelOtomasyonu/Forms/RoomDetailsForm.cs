using System;
using System.Linq;
using System.Windows.Forms;
using System.Data.Entity;
using DevExpress.XtraEditors;
using OtelOtomasyonu.Data;
using OtelOtomasyonu.Data.Entities;

namespace OtelOtomasyonu.Forms
{
    public partial class RoomDetailsForm : XtraForm
    {
        private readonly Room _room;

        public RoomDetailsForm(Room room)
        {
            InitializeComponent();
            _room = room;
            LoadRoomDetails();
        }

        private void LoadRoomDetails()
        {
            if (_room == null) return;

            lblRoomNumber.Text = $"Oda: {_room.RoomNumber}";
            lblRoomType.Text = $"Tip: {_room.Type}";
            lblPrice.Text = $"Fiyat: {_room.Price:C2}";
            lblStatus.Text = $"Durum: {_room.Status}";

            using (var context = new HotelContext())
            {
                var currentReservation = context.Reservations
                    .Include(r => r.Customer)
                    .Where(r => r.RoomId == _room.Id && 
                                r.Status != ReservationStatus.Cancelled &&
                                r.Status != ReservationStatus.Completed &&
                                r.StartDate <= DateTime.Today && 
                                r.EndDate >= DateTime.Today)
                    .FirstOrDefault();

                if (currentReservation != null)
                {
                    lblCustomer.Text = $"Müşteri: {currentReservation.Customer?.Name} {currentReservation.Customer?.Surname}";
                    lblCheckIn.Text = $"Giriş: {currentReservation.StartDate.ToShortDateString()}";
                    lblCheckOut.Text = $"Çıkış: {currentReservation.EndDate.ToShortDateString()}";
                }
                else
                {
                    lblCustomer.Text = "Müşteri: -";
                    lblCheckIn.Text = "Giriş: -";
                    lblCheckOut.Text = "Çıkış: -";
                }
            }
        }
    }
}

