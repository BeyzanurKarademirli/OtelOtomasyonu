using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using OtelOtomasyonu.Data.Entities;
using OtelOtomasyonu.Services;

namespace OtelOtomasyonu.Forms
{
    public partial class RoomForm : XtraForm
    {
        private readonly RoomService _roomService;

        public RoomForm()
        {
            InitializeComponent();
            _roomService = new RoomService();
            
            // Fill ComboBox
            cmbRoomType.Properties.Items.AddRange(Enum.GetValues(typeof(RoomType)));
            
            LoadRooms();
        }

        private void LoadRooms()
        {
            try
            {
                gridControl1.DataSource = _roomService.GetAllRooms();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Oda listesi yüklenirken hata: " + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string number = txtRoomNumber.Text.Trim();
            string priceStr = txtPrice.Text.Trim();
            
            if (string.IsNullOrEmpty(number) || string.IsNullOrEmpty(priceStr) || cmbRoomType.SelectedItem == null)
            {
                XtraMessageBox.Show("Lütfen tüm alanları doldurunuz.");
                return;
            }

            if (!decimal.TryParse(priceStr, out decimal price))
            {
                XtraMessageBox.Show("Geçerli bir fiyat giriniz.");
                return;
            }

            try
            {
                RoomType type = (RoomType)cmbRoomType.SelectedItem;
                _roomService.AddRoom(number, type, price);
                XtraMessageBox.Show("Oda eklendi.");
                
                txtRoomNumber.Text = "";
                txtPrice.Text = "";
                LoadRooms();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var view = gridView1;
            if (view.FocusedRowHandle < 0) return;

            int id = (int)view.GetRowCellValue(view.FocusedRowHandle, "Id");
            string number = (string)view.GetRowCellValue(view.FocusedRowHandle, "RoomNumber");

            if (XtraMessageBox.Show($"{number} numaralı odayı silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    _roomService.DeleteRoom(id);
                    LoadRooms();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Hata: " + ex.Message);
                }
            }
        }
    }
}
