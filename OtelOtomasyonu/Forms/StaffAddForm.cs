using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using OtelOtomasyonu.Data.Entities;
using OtelOtomasyonu.Services;
using System.Linq;

namespace OtelOtomasyonu.Forms
{
    public partial class StaffAddForm : XtraForm
    {
        private int? _userId;

        public StaffAddForm(int? userId = null)
        {
            InitializeComponent();
            _userId = userId;
            
            LoadDepartments();
            
            // Wire up event to auto-fill jobs
            cmbDepartment.SelectedIndexChanged += CmbDepartment_SelectedIndexChanged;
            
            // Fill static lists
            LoadCommonData();

            if (_userId.HasValue)
            {
                this.Text = "Personel Düzenle";
                btnSave.Text = "Güncelle";
                LoadUserData(_userId.Value);
            }
        }

        private void LoadUserData(int id)
        {
            using (var context = new OtelOtomasyonu.Data.HotelContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Id == id);
                if (user != null)
                {
                    txtName.Text = user.Name;
                    txtSurname.Text = user.Surname;
                    txtUsername.Text = user.Username;
                    txtPassword.Text = user.Password;
                    txtPhone.Text = user.Phone;
                    txtEmail.Text = user.Email;
                    
                    // Enum mapping
                    var trDept = GetTurkishDepartment(user.Department);
                    cmbDepartment.SelectedItem = trDept;
                    
                    cmbJobTitle.SelectedItem = user.JobTitle;
                    
                    // Safe set for numeric/formatted values
                    if(user.Salary > 0) cmbSalary.SelectedItem = user.Salary.ToString("0"); 
                    cmbWorkHours.SelectedItem = user.WorkHours;
                }
            }
        }

        private string GetTurkishDepartment(Department dept)
        {
            switch (dept)
            {
                case Department.FrontOffice: return "Ön Büro";
                case Department.Housekeeping: return "Kat Hizmetleri";
                case Department.FoodAndBeverage: return "Yiyecek ve İçecek";
                case Department.BackOffice: return "Yönetim ve İdari";
                case Department.TechnicalAndSecurity: return "Teknik Servis ve Güvenlik";
                default: return "Ön Büro";
            }
        }

        private void LoadDepartments()
        {
            // Load Friendly Names manually
            cmbDepartment.Properties.Items.Clear();
            cmbDepartment.Properties.Items.AddRange(new object[] {
                "Ön Büro",
                "Kat Hizmetleri",
                "Yiyecek ve İçecek",
                "Yönetim ve İdari",
                "Teknik Servis ve Güvenlik"
            });
        }
        
        private void LoadCommonData()
        {
            // Salaries (Rich options - Genişletilmiş seçenekler)
            cmbSalary.Properties.Items.AddRange(new object[] { 
                "17002", "18000", "20000", "22500", "25000", "27500", "30000", "35000", "40000", 
                "45000", "50000", "55000", "60000", "65000", "70000", "75000", "80000", "90000", "100000" 
            });

            // Shifts (3-shift system)
            cmbWorkHours.Properties.Items.AddRange(new object[] {
                "08:00 - 16:00",
                "16:00 - 24:00",
                "24:00 - 08:00",
                "09:00 - 18:00 (Ofis)"
            });
        }

        private void CmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDepartment.SelectedItem == null) return;

            string deptName = cmbDepartment.SelectedItem.ToString();
            cmbJobTitle.Properties.Items.Clear();

            // Populate Jobs based on Dept (Checking Turkish Names)
            if (deptName == "Ön Büro")
            {
                cmbJobTitle.Properties.Items.AddRange(new object[] { 
                    "Resepsiyonist", 
                    "Bellboy (Bagaj Taşıyıcı)", 
                    "Concierge (Konsiyerj)", 
                    "Misafir İlişkileri", 
                    "Vale" 
                });
            }
            else if (deptName == "Kat Hizmetleri")
            {
                cmbJobTitle.Properties.Items.AddRange(new object[] { 
                    "Kat Hizmetleri Müdürü", 
                    "Kat Görevlisi", 
                    "Meydancı", 
                    "Çamaşırhane Personeli" 
                });
            }
            else if (deptName == "Yiyecek ve İçecek")
            {
                cmbJobTitle.Properties.Items.AddRange(new object[] { 
                    "Aşçıbaşı", 
                    "Aşçı", 
                    "Aşçı Yardımcısı", 
                    "Garson", 
                    "Komi", 
                    "Barmen", 
                    "Barmaid", 
                    "Maitre d'Hotel" 
                });
            }
            else if (deptName == "Yönetim ve İdari")
            {
                cmbJobTitle.Properties.Items.AddRange(new object[] { 
                    "Genel Müdür", 
                    "Satış ve Pazarlama", 
                    "İnsan Kaynakları", 
                    "Muhasebe", 
                    "Satın Alma" 
                });
            }
            else if (deptName == "Teknik Servis ve Güvenlik")
            {
                cmbJobTitle.Properties.Items.AddRange(new object[] { 
                    "Teknisyen", 
                    "Güvenlik Görevlisi" 
                });
            }
            
            // Auto-select first if available
            if (cmbJobTitle.Properties.Items.Count > 0)
                cmbJobTitle.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation (Ensure selections are made)
                if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtSurname.Text) ||
                    string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    XtraMessageBox.Show("Lütfen zorunlu alanları doldurunuz (Ad, Soyad, Kullanıcı Adı, Şifre).", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cmbDepartment.SelectedItem == null || cmbJobTitle.SelectedItem == null || 
                    cmbSalary.SelectedItem == null || cmbWorkHours.SelectedItem == null)
                {
                    XtraMessageBox.Show("Lütfen tüm seçimleri yapınız (Departman, Görev, Maaş, Saat).", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var context = new OtelOtomasyonu.Data.HotelContext())
                {
                    // Map Turkish Name back to Enum
                    Department deptEnum = Department.FrontOffice; // default
                    string selectedDept = cmbDepartment.SelectedItem.ToString();
                    
                    if (selectedDept == "Ön Büro") deptEnum = Department.FrontOffice;
                    else if (selectedDept == "Kat Hizmetleri") deptEnum = Department.Housekeeping;
                    else if (selectedDept == "Yiyecek ve İçecek") deptEnum = Department.FoodAndBeverage;
                    else if (selectedDept == "Yönetim ve İdari") deptEnum = Department.BackOffice;
                    else if (selectedDept == "Teknik Servis ve Güvenlik") deptEnum = Department.TechnicalAndSecurity;

                    User userParams;
                    if (_userId.HasValue)
                    {
                        // Update Mode
                         var existingUser = context.Users.FirstOrDefault(u => u.Id == _userId.Value);
                         if (existingUser != null)
                         {
                             userParams = existingUser; // Modify tracked entity
                         }
                         else return;
                    }
                    else
                    {
                        // Add Mode
                        userParams = new User();
                        userParams.Role = UserRole.Staff;
                        userParams.LastLoginDate = null;
                        context.Users.Add(userParams);
                    }

                    // Common Property Set
                    userParams.Name = txtName.Text.Trim();
                    userParams.Surname = txtSurname.Text.Trim();
                    userParams.Username = txtUsername.Text.Trim();
                    userParams.Password = txtPassword.Text.Trim();
                    userParams.Department = deptEnum;
                    userParams.JobTitle = cmbJobTitle.SelectedItem.ToString();
                    userParams.Phone = txtPhone.Text.Trim();
                    userParams.Email = txtEmail.Text.Trim();
                    userParams.WorkHours = cmbWorkHours.SelectedItem.ToString();
                    userParams.Salary = decimal.Parse(cmbSalary.SelectedItem.ToString());

                    context.SaveChanges();
                }

                XtraMessageBox.Show(_userId.HasValue ? "Personel güncellendi." : "Personel başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
