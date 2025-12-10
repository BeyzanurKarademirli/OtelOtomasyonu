using System;
using System.Windows.Forms;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using OtelOtomasyonu.Data;
using System.Linq;
using System.Data.Entity;
using OtelOtomasyonu.Services;

namespace OtelOtomasyonu.Forms
{
    public partial class AdminDashboard : RibbonForm
    {
        private readonly ReservationService _reservationService;
        private DevExpress.XtraBars.BarButtonItem btnLogout;

        public AdminDashboard()
        {
            InitializeComponent();
            _reservationService = new ReservationService();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var reservations = _reservationService
                    .GetUpcomingReservations()
                    .Select(r => new
                    {
                        RezervasyonNo = r.Id,
                        Musteri = r.Customer?.Username ?? "-",
                        Oda = r.Room?.RoomNumber ?? "-",
                        Giris = r.StartDate,
                        Cikis = r.EndDate,
                        Durum = r.Status.ToString(),
                        Ucret = r.TotalPrice
                    })
                    .ToList();

                gridControl1.DataSource = reservations;

                var snapshot = _reservationService.GetDashboardSnapshot();
                UpdateTitle(snapshot);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Veri yüklenirken hata: " + ex.Message);
            }
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadData();
        }

        private void btnChat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var chatForm = new ChatForm();
            chatForm.Show();
        }

        private void btnStaff_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var staffForm = new StaffForm();
            staffForm.ShowDialog();
        }

        private void btnRooms_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var roomForm = new RoomForm();
            roomForm.ShowDialog();
        }

        private void btnNewReservation_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var reservationForm = new ReservationForm();
            reservationForm.ShowDialog();
        }

        private void btnLogout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (XtraMessageBox.Show("Oturumu kapatmak istediğinize emin misiniz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                var loginForm = new LoginForm();
                loginForm.ShowDialog();
                this.Close();
            }
        }

        private void UpdateTitle(DashboardSnapshot snapshot)
        {
            this.Text = $"Yönetici Paneli - Gelir: {snapshot.DailyRevenue:C0} | Doluluk: {snapshot.OccupancyRate:P0} | Bekleyen: {snapshot.PendingReservations}";
        }
    }
}
