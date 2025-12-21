using System;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using OtelOtomasyonu.Data;
using OtelOtomasyonu.Data.Entities;
using OtelOtomasyonu.Services;

namespace OtelOtomasyonu.Forms
{
    public partial class ReservationForm : XtraForm
    {
        private readonly ReservationService _reservationService;
        private User _selectedCustomer;
        private Room _selectedRoom;

        public ReservationForm()
        {
            InitializeComponent();
            _reservationService = new ReservationService();
            
            dtStart.DateTime = DateTime.Today;
            dtEnd.DateTime = DateTime.Today.AddDays(1);
            
            LoadBackgroundImage();
        }

        private void LoadBackgroundImage()
        {
            try
            {
                // Otel binası görseli Resources'dan yükle
                // picBackground.Properties.Image = Properties.Resources.HotelBuilding;
                // Görsel yoksa sessizce devam et
            }
            catch
            {
                // Görsel yoksa sessizce devam et
            }
        }

        private void btnSearchRooms_Click(object sender, EventArgs e)
        {
            try
            {
                var rooms = _reservationService.GetAvailableRooms(dtStart.DateTime, dtEnd.DateTime);
                gridControlRooms.DataSource = rooms;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void btnFindCustomer_Click(object sender, EventArgs e)
        {
            string tc = txtCustomerTC.Text.Trim();
            if (string.IsNullOrEmpty(tc)) return;

            using (var context = new HotelContext())
            {
                _selectedCustomer = context.Users.FirstOrDefault(u => u.Username == tc && u.Role == UserRole.Customer);
                
                if (_selectedCustomer != null)
                {
                    lblCustomerName.Text = $"Müşteri: {_selectedCustomer.Username}"; // In real app, add Name/Surname to User entity
                    CalculatePrice();
                }
                else
                {
                    XtraMessageBox.Show("Müşteri bulunamadı. Lütfen önce kayıt oluşturun.");
                    lblCustomerName.Text = "Müşteri Seçilmedi";
                }
            }
        }

        private void gridViewRooms_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var view = gridViewRooms;
            if (view.FocusedRowHandle >= 0)
            {
                int id = (int)view.GetRowCellValue(view.FocusedRowHandle, "Id");
                // We need to fetch the full object or just use the row data if it's bound to List<Room>
                _selectedRoom = (Room)view.GetRow(view.FocusedRowHandle);
                CalculatePrice();
            }
        }

        private void CalculatePrice()
        {
            if (_selectedRoom != null && dtEnd.DateTime > dtStart.DateTime)
            {
                int days = (int)(dtEnd.DateTime - dtStart.DateTime).TotalDays;
                decimal total = _selectedRoom.Price * days;
                lblTotalPrice.Text = $"Toplam Tutar: {total:C2}";
            }
            else
            {
                lblTotalPrice.Text = "Toplam Tutar: 0.00 ₺";
            }
        }

        private void btnCreateReservation_Click(object sender, EventArgs e)
        {
            if (_selectedCustomer == null)
            {
                XtraMessageBox.Show("Lütfen bir müşteri seçiniz.");
                return;
            }
            if (_selectedRoom == null)
            {
                XtraMessageBox.Show("Lütfen bir oda seçiniz.");
                return;
            }

            try
            {
                _reservationService.CreateReservation(
                    _selectedCustomer.Id,
                    _selectedRoom.Id,
                    dtStart.DateTime,
                    dtEnd.DateTime
                );

                XtraMessageBox.Show("Rezervasyon başarıyla oluşturuldu!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Rezervasyon oluşturulurken hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
