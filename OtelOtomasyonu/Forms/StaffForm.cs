using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using OtelOtomasyonu.Services;

namespace OtelOtomasyonu.Forms
{
    public partial class StaffForm : XtraForm
    {
        private readonly StaffService _staffService;

        public StaffForm()
        {
            InitializeComponent();
            _staffService = new StaffService();
            gridView1.FocusedRowChanged += gridView1_FocusedRowChanged;
            LoadStaff();
        }

        private void LoadStaff()
        {
            try
            {
                gridControl1.DataSource = _staffService.GetAllStaff();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Personel listesi yüklenirken hata: " + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                XtraMessageBox.Show("Kullanıcı adı ve şifre boş olamaz.");
                return;
            }

            try
            {
                _staffService.AddStaff(username, password);
                XtraMessageBox.Show("Personel eklendi.");
                txtUsername.Text = "";
                txtPassword.Text = "";
                LoadStaff();
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
            string username = (string)view.GetRowCellValue(view.FocusedRowHandle, "Username");

            if (XtraMessageBox.Show($"{username} adlı personeli silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    _staffService.DeleteStaff(id);
                    LoadStaff();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var view = gridView1;
            if (view.FocusedRowHandle < 0)
            {
                XtraMessageBox.Show("Lütfen güncellenecek personeli seçiniz.");
                return;
            }

            int id = (int)view.GetRowCellValue(view.FocusedRowHandle, "Id");
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username))
            {
                XtraMessageBox.Show("Kullanıcı adı boş olamaz.");
                return;
            }

            try
            {
                _staffService.UpdateStaff(id, username, password);
                XtraMessageBox.Show("Personel güncellendi.");
                txtUsername.Text = "";
                txtPassword.Text = "";
                LoadStaff();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var view = gridView1;
            if (view.FocusedRowHandle >= 0)
            {
                txtUsername.Text = (string)view.GetRowCellValue(view.FocusedRowHandle, "Username");
                // Password is not loaded for security, user enters new one if they want to change it
                txtPassword.Text = ""; 
            }
        }
    }
}
