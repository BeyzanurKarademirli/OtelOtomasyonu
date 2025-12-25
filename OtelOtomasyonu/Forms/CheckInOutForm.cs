using System;
using System.Linq;
using System.Windows.Forms;
using System.Data.Entity;
using DevExpress.XtraEditors;
using OtelOtomasyonu.Data;
using OtelOtomasyonu.Data.Entities;
using OtelOtomasyonu.Services;
using System.Drawing;

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
            
            // Apply Dark Theme
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.LookAndFeel.SkinName = "DevExpress Dark Style";
            ApplyTheme();
            
            LoadReservations();
        }

        private void ApplyTheme()
        {
            // Form background
            this.Appearance.BackColor = Color.Black;
            this.Appearance.Options.UseBackColor = true;
            
            // Details panel
            if (panelControlDetails != null)
            {
                panelControlDetails.Appearance.BackColor = Color.FromArgb(30, 30, 30);
                panelControlDetails.Appearance.Options.UseBackColor = true;
                panelControlDetails.Appearance.BorderColor = Color.Gold;
                panelControlDetails.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            }
            
            // Labels styling
            if (labelControl1 != null)
            {
                labelControl1.Appearance.ForeColor = Color.Gold;
                labelControl1.Appearance.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            }
            if (labelControl2 != null)
            {
                labelControl2.Appearance.ForeColor = Color.Gold;
                labelControl2.Appearance.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            }
            if (labelControl3 != null)
            {
                labelControl3.Appearance.ForeColor = Color.Gold;
                labelControl3.Appearance.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            }
            if (labelControl4 != null)
            {
                labelControl4.Appearance.ForeColor = Color.Gold;
                labelControl4.Appearance.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            }
            if (labelControl5 != null)
            {
                labelControl5.Appearance.ForeColor = Color.Gold;
                labelControl5.Appearance.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            }
            
            // Value labels
            if (lblCustomerName != null)
            {
                lblCustomerName.Appearance.ForeColor = Color.White;
                lblCustomerName.Appearance.Font = new Font("Segoe UI", 9F);
            }
            if (lblRoomNumber != null)
            {
                lblRoomNumber.Appearance.ForeColor = Color.White;
                lblRoomNumber.Appearance.Font = new Font("Segoe UI", 9F);
            }
            if (lblCheckInDate != null)
            {
                lblCheckInDate.Appearance.ForeColor = Color.White;
                lblCheckInDate.Appearance.Font = new Font("Segoe UI", 9F);
            }
            if (lblCheckOutDate != null)
            {
                lblCheckOutDate.Appearance.ForeColor = Color.White;
                lblCheckOutDate.Appearance.Font = new Font("Segoe UI", 9F);
            }
            if (lblTotalPrice != null)
            {
                lblTotalPrice.Appearance.ForeColor = Color.White;
                lblTotalPrice.Appearance.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            }
            
            // Buttons
            if (btnCheckIn != null)
            {
                btnCheckIn.Appearance.BackColor = Color.FromArgb(76, 175, 80);
                btnCheckIn.Appearance.ForeColor = Color.White;
                btnCheckIn.Appearance.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                btnCheckIn.MouseEnter += (s, e) => {
                    btnCheckIn.Appearance.BackColor = Color.FromArgb(69, 160, 73);
                };
                btnCheckIn.MouseLeave += (s, e) => {
                    btnCheckIn.Appearance.BackColor = Color.FromArgb(76, 175, 80);
                };
            }
            if (btnCheckOut != null)
            {
                btnCheckOut.Appearance.BackColor = Color.FromArgb(244, 67, 54);
                btnCheckOut.Appearance.ForeColor = Color.White;
                btnCheckOut.Appearance.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                btnCheckOut.MouseEnter += (s, e) => {
                    btnCheckOut.Appearance.BackColor = Color.FromArgb(229, 57, 53);
                };
                btnCheckOut.MouseLeave += (s, e) => {
                    btnCheckOut.Appearance.BackColor = Color.FromArgb(244, 67, 54);
                };
            }
            
            // Grid styling
            if (gridViewReservations != null)
            {
                gridViewReservations.Appearance.HeaderPanel.BackColor = Color.Black;
                gridViewReservations.Appearance.HeaderPanel.ForeColor = Color.Gold;
                gridViewReservations.Appearance.HeaderPanel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                
                gridViewReservations.Appearance.Row.BackColor = Color.FromArgb(30, 30, 30);
                gridViewReservations.Appearance.Row.ForeColor = Color.White;
                
                gridViewReservations.Appearance.EvenRow.BackColor = Color.FromArgb(20, 20, 20);
                gridViewReservations.OptionsView.EnableAppearanceEvenRow = true;
                
                gridViewReservations.Appearance.SelectedRow.BackColor = Color.Gold;
                gridViewReservations.Appearance.SelectedRow.ForeColor = Color.Black;
                
                gridViewReservations.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }
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

