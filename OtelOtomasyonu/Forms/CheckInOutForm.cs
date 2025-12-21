using System;
using System.Linq;
using System.Windows.Forms;
using System.Data.Entity;
using DevExpress.XtraEditors;
using OtelOtomasyonu.Data;
using OtelOtomasyonu.Data.Entities;
using OtelOtomasyonu.Services;

namespace OtelOtomasyonu.Forms
{
    public partial class CheckInOutForm : XtraForm
    {
        private readonly ReservationService _reservationService;
        private Reservation _selectedReservation;

        public CheckInOutForm()
        {
            InitializeComponent();
            _reservationService = new ReservationService();
            LoadReservations();
        }

        private void LoadReservations()
        {
            try
            {
                using (var context = new HotelContext())
                {
                    var today = DateTime.Today;
                    var reservations = context.Reservations
                        .Include("Customer")
                        .Include("Room")
                        .Where(r => r.Status == ReservationStatus.Confirmed || 
                                    r.Status == ReservationStatus.Pending)
                        .OrderBy(r => r.StartDate)
                        .ToList();

                    gridControlReservations.DataSource = reservations.Select(r => new
                    {
                        r.Id,
                        Musteri = r.Customer?.Name + " " + r.Customer?.Surname,
                        Oda = r.Room?.RoomNumber,
                        Giris = r.StartDate,
                        Cikis = r.EndDate,
                        Durum = r.Status.ToString()
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Rezervasyonlar yüklenirken hata: " + ex.Message);
            }
        }

        private void gridViewReservations_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var view = gridViewReservations;
            if (view.FocusedRowHandle >= 0)
            {
                int reservationId = (int)view.GetRowCellValue(view.FocusedRowHandle, "Id");
                
                using (var context = new HotelContext())
                {
                    _selectedReservation = context.Reservations
                        .Include("Customer")
                        .Include("Room")
                        .Include("GuestDetail")
                        .FirstOrDefault(r => r.Id == reservationId);

                    if (_selectedReservation != null)
                    {
                        LoadReservationDetails();
                    }
                }
            }
        }

        private void LoadReservationDetails()
        {
            if (_selectedReservation == null) return;

            lblCustomerName.Text = $"{_selectedReservation.Customer?.Name} {_selectedReservation.Customer?.Surname}";
            lblRoomNumber.Text = _selectedReservation.Room?.RoomNumber;
            lblCheckInDate.Text = _selectedReservation.StartDate.ToShortDateString();
            lblCheckOutDate.Text = _selectedReservation.EndDate.ToShortDateString();
            lblTotalPrice.Text = _selectedReservation.TotalPrice.ToString("C2");

            btnCheckIn.Enabled = _selectedReservation.Status == ReservationStatus.Pending;
            btnCheckOut.Enabled = _selectedReservation.Status == ReservationStatus.Confirmed;
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            if (_selectedReservation == null)
            {
                XtraMessageBox.Show("Lütfen bir rezervasyon seçiniz.");
                return;
            }

            try
            {
                using (var context = new HotelContext())
                {
                    var reservation = context.Reservations
                        .Include("Room")
                        .FirstOrDefault(r => r.Id == _selectedReservation.Id);

                    if (reservation != null)
                    {
                        reservation.Status = ReservationStatus.Confirmed;
                        reservation.Room.Status = RoomStatus.Occupied;
                        context.SaveChanges();

                        XtraMessageBox.Show("Check-in işlemi başarıyla tamamlandı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadReservations();
                        LoadReservationDetails();
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Check-in işlemi sırasında hata: " + ex.Message);
            }
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            if (_selectedReservation == null)
            {
                XtraMessageBox.Show("Lütfen bir rezervasyon seçiniz.");
                return;
            }

            try
            {
                using (var context = new HotelContext())
                {
                    var reservation = context.Reservations
                        .Include("Room")
                        .FirstOrDefault(r => r.Id == _selectedReservation.Id);

                    if (reservation != null)
                    {
                        reservation.Status = ReservationStatus.Completed;
                        reservation.Room.Status = RoomStatus.Cleaning;
                        context.SaveChanges();

                        XtraMessageBox.Show("Check-out işlemi başarıyla tamamlandı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadReservations();
                        LoadReservationDetails();
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Check-out işlemi sırasında hata: " + ex.Message);
            }
        }
    }
}

