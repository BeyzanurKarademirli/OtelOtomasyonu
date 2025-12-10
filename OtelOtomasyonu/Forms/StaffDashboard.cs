using System;
using System.Windows.Forms;
using DevExpress.XtraBars.Ribbon;

namespace OtelOtomasyonu.Forms
{
    public partial class StaffDashboard : RibbonForm
    {
        public StaffDashboard()
        {
            InitializeComponent();
        }

        private void btnNewCustomer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var registrationForm = new CustomerRegistrationForm();
            registrationForm.ShowDialog();
        }

        private void btnNewReservation_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var reservationForm = new ReservationForm();
            reservationForm.ShowDialog();
        }
    }
}
