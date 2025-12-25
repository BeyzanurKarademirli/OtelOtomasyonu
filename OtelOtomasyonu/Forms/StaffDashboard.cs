using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using OtelOtomasyonu.Services;
using OtelOtomasyonu.Data.Entities;
using OtelOtomasyonu.Data;

namespace OtelOtomasyonu.Forms
{
    public partial class StaffDashboard : XtraForm
    {
        public StaffDashboard()
        {
            InitializeComponent();
            LoadAssets();
            SetupEvents();
            // Kullanıcı adını ve menüyü ayarla
            if (lblUserName != null)
            {
                lblUserName.Visible = true;
            }
            CenterMenu();
        }

        private void LoadAssets()
        {
            try
            {
                // Helper function to find file in StartupPath or Project Root (for dev convenience)
                string FindAsset(string fileName) {
                    string path = Path.Combine(Application.StartupPath, fileName);
                    if (File.Exists(path)) return path;
                    
                    // Check project root (up 2 levels from bin/Debug)
                    path = Path.Combine(Application.StartupPath, "..\\..", fileName);
                    if (File.Exists(path)) return path;
                    
                    return null;
                }

                // -- 1) Main Background --
                string mainBgPath = System.IO.Path.Combine(Application.StartupPath, "admin_bg_gold_framed_soft.png");
                if (System.IO.File.Exists(mainBgPath))
                {
                    this.BackgroundImage = Image.FromFile(mainBgPath);
                    this.BackgroundImageLayout = ImageLayout.Stretch;
                }
                else
                {
                    // Fallback
                     string altBgPath = System.IO.Path.Combine(Application.StartupPath, "admin_bg_gold_minimal.png");
                     if (System.IO.File.Exists(altBgPath))
                     {
                         this.BackgroundImage = Image.FromFile(altBgPath);
                         this.BackgroundImageLayout = ImageLayout.Stretch;
                     }
                     else
                     {
                         this.BackColor = Color.Black; 
                     }
                }

                // Load Logo
                string logoPath = FindAsset("header_logo.png");
                if (logoPath != null)
                {
                    originalLogoImage = Image.FromFile(logoPath);
                    picLogo.Image = null;
                    
                    picLogo.Dock = DockStyle.None;
                    picLogo.Size = new Size(500, 100);
                    picLogo.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
                    picLogo.BackColor = Color.Transparent;
                    picLogo.Location = new Point((this.ClientSize.Width - picLogo.Width) / 2, 40);

                    // -- SHINE ANIMATION --
                    if (shineTimer == null)
                    {
                        shineTimer = new System.Windows.Forms.Timer();
                        shineTimer.Interval = 40;
                        shineTimer.Tick += (s, e) => {
                            shinePos += 10;
                            if (shinePos > picLogo.Width + 100) 
                                shinePos = -100;
                            picLogo.Invalidate();
                        };
                        shineTimer.Start();
                    }

                    picLogo.Paint -= PicLogo_Paint; 
                    picLogo.Paint += PicLogo_Paint;

                    picLogo.Cursor = Cursors.Hand;
                    
                    picLogo.MouseEnter += (s, e) => {
                        isLogoHovered = true;
                        picLogo.Invalidate();
                    };
                    
                    picLogo.MouseLeave += (s, e) => {
                        isLogoHovered = false;
                        picLogo.Invalidate();
                    };

                    picLogo.Click += (s, e) => {
                        new SlideShowForm().ShowDialog();
                    };
                }

                // Load Button Texture (Vintage)
                string btnPath = FindAsset("gold_vintage_btn.png");
                Image btnTexture = null;
                if (btnPath != null)
                {
                    btnTexture = Image.FromFile(btnPath);
                }

                // Apply texture to buttons
                ApplyButtonStyle(btnNewCustomer, btnTexture);
                ApplyButtonStyle(btnCertificates, btnTexture);
                ApplyButtonStyle(btnCheckInOut, btnTexture);
                ApplyButtonStyle(btnFloorPlan, btnTexture);
                ApplyButtonStyle(btnCustomers, btnTexture);
                ApplyButtonStyle(btnProfile, btnTexture);
                ApplyButtonStyle(btnRoomInfo, btnTexture);
                ApplyButtonStyle(btnOccupancy, btnTexture);
                
                // Chatbot kaldırıldı - btnHelp gizli
                btnHelp.Visible = false;

                // Setup User Menu Dropdown
                SetupUserMenu();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Asset Load Error: " + ex.Message);
            }
        }

        private DevExpress.XtraEditors.PanelControl pnlUserMenu;

        private void SetupUserMenu()
        {
            var currentUser = Session.CurrentUser;
            if (currentUser == null)
            {
                // Eğer kullanıcı yoksa, label'ı gizle
                if (lblUserName != null)
                {
                    lblUserName.Visible = false;
                }
                return;
            }

            // Update username label
            string userName = "";
            if (!string.IsNullOrEmpty(currentUser.Name) || !string.IsNullOrEmpty(currentUser.Surname))
            {
                userName = $"{currentUser.Name ?? ""} {currentUser.Surname ?? ""}".Trim().ToUpper();
            }
            else if (!string.IsNullOrEmpty(currentUser.Username))
            {
                userName = currentUser.Username.ToUpper();
            }
            else
            {
                userName = "PERSONEL";
            }

            if (lblUserName != null)
            {
                lblUserName.Text = userName;
                lblUserName.Visible = true;
                lblUserName.BringToFront();
            }

            // Style the Username Label to look interactive
            if (lblUserName != null)
            {
                lblUserName.Cursor = Cursors.Hand;
                lblUserName.MouseEnter += (s, e) => {
                    lblUserName.Appearance.ForeColor = Color.White;
                };
                lblUserName.MouseLeave += (s, e) => {
                    lblUserName.Appearance.ForeColor = Color.FromArgb(198, 168, 105);
                };
                lblUserName.Click += (s, e) => {
                    if (pnlUserMenu != null)
                    {
                        pnlUserMenu.Visible = !pnlUserMenu.Visible;
                        pnlUserMenu.BringToFront();
                    }
                };
            }

            // Create the Dropdown Panel (eğer daha önce oluşturulmadıysa)
            if (pnlUserMenu == null)
            {
                pnlUserMenu = new DevExpress.XtraEditors.PanelControl();
                pnlUserMenu.Visible = false;
                pnlUserMenu.Size = new Size(200, 100);
                pnlUserMenu.Appearance.BackColor = Color.Black;
                pnlUserMenu.Appearance.Options.UseBackColor = true;
                pnlUserMenu.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
                pnlUserMenu.Appearance.BorderColor = Color.Gold;
                this.Controls.Add(pnlUserMenu);
            }
            
            // Konum CenterMenu() içinde ayarlanacak
            pnlUserMenu.BringToFront();

            // Create Buttons (eğer daha önce oluşturulmadıysa)
            if (pnlUserMenu.Controls.Count == 0)
            {
                SimpleButton btnProfileMenu = CreateMenuButton("PROFİL", 0);
                SimpleButton btnLogoutMenu = CreateMenuButton("ÇIKIŞ", 50);

                btnProfileMenu.Click += (s, e) => {
                    pnlUserMenu.Visible = false;
                    new ProfileForm().ShowDialog();
                };

                btnLogoutMenu.Click += (s, e) => {
                    pnlUserMenu.Visible = false;
                    if (XtraMessageBox.Show("Çıkış yapmak istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Session.CurrentUser = null;
                        this.Hide();
                        LoginForm login = new LoginForm();
                        login.ShowDialog();
                        this.Close();
                    }
                };

                pnlUserMenu.Controls.Add(btnProfileMenu);
                pnlUserMenu.Controls.Add(btnLogoutMenu);
            }
        }

        private SimpleButton CreateMenuButton(string text, int topY)
        {
            SimpleButton btn = new SimpleButton();
            btn.Text = text;
            btn.Size = new Size(200, 50);
            btn.Location = new Point(0, topY);
            btn.Appearance.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            btn.Appearance.ForeColor = Color.Gold;
            btn.Appearance.BackColor = Color.Black;
            btn.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            
            btn.MouseEnter += (s, e) => {
                btn.Appearance.BackColor = Color.FromArgb(50, 50, 50);
                btn.Appearance.ForeColor = Color.White;
            };
            btn.MouseLeave += (s, e) => {
                btn.Appearance.BackColor = Color.Black;
                btn.Appearance.ForeColor = Color.Gold;
            };

            return btn;
        }

        private void ApplyButtonStyle(SimpleButton btn, Image texture)
        {
            btn.Appearance.Font = new Font("Segoe UI", 14f, FontStyle.Bold);
            btn.Appearance.ForeColor = Color.Gold;

            if (texture != null)
            {
                btn.BackgroundImage = texture;
                btn.BackgroundImageLayout = ImageLayout.Stretch;
                
                btn.Appearance.ForeColor = Color.Black; 
                btn.Appearance.Font = new Font("Segoe UI", 12f, FontStyle.Bold);
                
                btn.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
                btn.BackColor = Color.Transparent;
            }
            else
            {
                btn.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
                btn.Appearance.BorderColor = Color.Gold;
            }
            
            btn.MouseEnter += (s, e) => {
                if (texture != null) btn.Appearance.ForeColor = Color.White;
                else btn.Appearance.BackColor = Color.FromArgb(50, 50, 50);
            };
            btn.MouseLeave += (s, e) => {
                if (texture != null) btn.Appearance.ForeColor = Color.Black;
                else btn.Appearance.BackColor = Color.Transparent;
            };
        }

        private void SetupEvents()
        {
            var currentUser = Session.CurrentUser;
            
            btnNewCustomer.Click += (s, e) => OpenForm(new CustomerRegistrationForm());
            btnCertificates.Click += (s, e) => OpenForm(new CertificateForm());
            btnCheckInOut.Click += (s, e) => OpenForm(new CheckInOutForm());
            btnFloorPlan.Click += (s, e) => OpenForm(new FloorPlanForm());
            btnProfile.Click += (s, e) => OpenForm(new ProfileForm());
            
            // Müşteri bilgileri - tüm personeller görebilir ve düzenleyebilir
            // BackOffice için tam erişim (personel sekmesi dahil)
            if (currentUser != null && (currentUser.Role == UserRole.Admin || 
                (currentUser.Role == UserRole.Staff && currentUser.Department == Department.BackOffice)))
            {
                btnCustomers.Click += (s, e) => OpenForm(new UsersForm(isStaffMode: false)); // Full access
            }
            else
            {
                btnCustomers.Click += (s, e) => OpenForm(new UsersForm(isStaffMode: true)); // Staff mode
            }
            
            // Gelir oranı - sadece yetkili olanlar görebilir
            if (currentUser != null && AuthorizationService.CanViewRevenue(currentUser))
            {
                btnRevenue.Visible = true;
                btnRevenue.Click += (s, e) => {
                    IncomeForm incomeForm = new IncomeForm();
                    incomeForm.Show();
                };
            }
            else
            {
                btnRevenue.Visible = false;
            }
            
            // BackOffice ve Genel Müdür için ekstra butonlar (yöneticinin gördüğü her şey)
            if (currentUser != null && (currentUser.Role == UserRole.Admin || 
                (currentUser.Role == UserRole.Staff && currentUser.Department == Department.BackOffice) ||
                (currentUser.Role == UserRole.Staff && currentUser.JobTitle == "Genel Müdür")))
            {
                btnRoomInfo.Visible = true;
                btnRoomInfo.Click += (s, e) => OpenForm(new RoomForm());
                
                btnOccupancy.Visible = true;
                btnOccupancy.Click += (s, e) => {
                    OccupancyForm occupancyForm = new OccupancyForm();
                    occupancyForm.Show();
                };
            }
            else
            {
                btnRoomInfo.Visible = false;
                btnOccupancy.Visible = false;
            }

            // Help / Chat - Kaldırıldı
            btnHelp.Visible = false;

            // Resize handling for centering
            this.Resize += StaffDashboard_Resize;
            CenterMenu();
        }

        private void StaffDashboard_Resize(object sender, EventArgs e)
        {
            CenterMenu();
        }

        private void CenterMenu()
        {
            if (picLogo != null)
            {
                picLogo.Location = new Point((this.ClientSize.Width - picLogo.Width) / 2, 40);
            }
            
            if (pnlMenu != null)
            {
                // BackOffice için daha fazla buton varsa boyutu artır
                var currentUser = Session.CurrentUser;
                if (currentUser != null && (currentUser.Role == UserRole.Admin || 
                    (currentUser.Role == UserRole.Staff && currentUser.Department == Department.BackOffice) ||
                    (currentUser.Role == UserRole.Staff && currentUser.JobTitle == "Genel Müdür")))
                {
                    pnlMenu.Size = new Size(960, 480); // 4 satır için
                }
                else
                {
                    pnlMenu.Size = new Size(960, 360); // 3 satır için
                }

                int baseY = (this.ClientSize.Height - pnlMenu.Height) / 2 + 50;

                pnlMenu.Location = new Point(
                    (this.ClientSize.Width - pnlMenu.Width) / 2,
                    baseY
                );
            }

            if (lblUserName != null)
            {
                // Önce Dock'u kaldır
                if (lblUserName.Dock != DockStyle.None)
                {
                    lblUserName.Dock = DockStyle.None;
                }
                
                lblUserName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
                
                // Label'ın genişliğini hesapla
                if (!string.IsNullOrEmpty(lblUserName.Text))
                {
                    using (Graphics g = this.CreateGraphics())
                    {
                        SizeF textSize = g.MeasureString(lblUserName.Text, lblUserName.Appearance.Font);
                        lblUserName.Size = new Size((int)textSize.Width + 20, (int)textSize.Height + 10);
                    }
                }
                else
                {
                    lblUserName.Size = new Size(200, 50);
                }
                
                int centerX = (this.Width - lblUserName.Width) / 2;
                lblUserName.Location = new Point(centerX, 180); // Daha yukarı taşındı
                lblUserName.Visible = true;
                lblUserName.BringToFront();
                
                if (pnlUserMenu != null)
                {
                     pnlUserMenu.Location = new Point(
                        lblUserName.Location.X + (lblUserName.Width - pnlUserMenu.Width) / 2,
                        lblUserName.Bottom + 5
                    );
                    pnlUserMenu.BringToFront();
                }
            }
        }

        private void OpenForm(Form form)
        {
            this.Hide();
            form.ShowDialog();
            this.Show();
        }

        // Animation Fields
        private System.Windows.Forms.Timer shineTimer;
        private float shinePos = -100;
        private Image originalLogoImage;
        private bool isLogoHovered = false;

        private void PicLogo_Paint(object sender, PaintEventArgs e)
        {
            if (originalLogoImage == null) return;

            Size imgSize = originalLogoImage.Size;
            Size ctrlSize = picLogo.ClientSize;
            float ratio = Math.Min((float)ctrlSize.Width / imgSize.Width, (float)ctrlSize.Height / imgSize.Height);

            int w = (int)(imgSize.Width * ratio);
            int h = (int)(imgSize.Height * ratio);
            if (w <= 0 || h <= 0) return;

            int x = (ctrlSize.Width - w) / 2;
            int y = (ctrlSize.Height - h) / 2;

            using (Bitmap buffer = new Bitmap(w, h))
            {
                using (Graphics g = Graphics.FromImage(buffer))
                {
                    g.Clear(Color.Transparent);
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    g.DrawImage(originalLogoImage, 0, 0, w, h);
                }

                System.Drawing.Imaging.BitmapData data = buffer.LockBits(
                    new Rectangle(0, 0, w, h),
                    System.Drawing.Imaging.ImageLockMode.ReadWrite,
                    System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                int bytes = Math.Abs(data.Stride) * h;
                byte[] rgbValues = new byte[bytes];
                System.Runtime.InteropServices.Marshal.Copy(data.Scan0, rgbValues, 0, bytes);

                float beamWidth = 40f; 
                float localShineX = shinePos - x;
                float tilt = 0.5f; 

                for (int r = 0; r < h; r++)
                {
                    int rowOffset = r * data.Stride;
                    for (int c = 0; c < w; c++)
                    {
                        int idx = rowOffset + (c * 4);
                        byte alpha = rgbValues[idx + 3];

                        if (alpha < 10) continue;

                        byte b_in = rgbValues[idx];
                        byte g_in = rgbValues[idx + 1];
                        byte r_in = rgbValues[idx + 2];

                        if (r_in < 50 && g_in < 50 && b_in < 50) 
                        {
                            rgbValues[idx + 3] = 0;
                            continue;
                        }

                        if (isLogoHovered)
                        {
                            int b_hover = Math.Min(255, (int)(b_in * 1.5));
                            int g_hover = Math.Min(255, (int)(g_in * 1.5));
                            int r_hover = Math.Min(255, (int)(r_in * 1.5));

                            b_in = (byte)b_hover;
                            g_in = (byte)g_hover;
                            r_in = (byte)r_hover;
                            
                            rgbValues[idx] = b_in;
                            rgbValues[idx + 1] = g_in;
                            rgbValues[idx + 2] = r_in;
                        }

                        float beamCenterForThisRow = localShineX - (r * tilt); 
                        float dist = Math.Abs(c - beamCenterForThisRow);

                        if (dist < beamWidth / 2)
                        {
                            float intensity = 1.0f - (dist / (beamWidth / 2));
                            if (intensity > 0)
                            {
                                int shineVal = (int)(120 * intensity); 
                                int b_out = b_in + shineVal;
                                rgbValues[idx] = (byte)Math.Min(255, b_out);
                                int g_out = g_in + shineVal;
                                rgbValues[idx + 1] = (byte)Math.Min(255, g_out);
                                int r_out = r_in + shineVal;
                                rgbValues[idx + 2] = (byte)Math.Min(255, r_out);
                            }
                        }
                    }
                }

                System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, data.Scan0, bytes);
                buffer.UnlockBits(data);

                e.Graphics.DrawImage(buffer, x, y, w, h);
            }
        }

        private void ShowInfo(string message)
        {
            XtraMessageBox.Show(message, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
