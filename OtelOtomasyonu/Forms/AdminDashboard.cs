using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;

namespace OtelOtomasyonu.Forms
{
    public partial class AdminDashboard : XtraForm
    {
        public AdminDashboard()
        {
            InitializeComponent();
            LoadAssets();
            SetupEvents();
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
                // REVERT: Load "Framed Soft" background (User preferred previous direction)
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
                    // Use Owner Draw approach: Store image privately, don't let PictureEdit render it default
                    originalLogoImage = Image.FromFile(logoPath);
                    picLogo.Image = null; // Important! Prevent default drawing (which is opaque)
                    
                    // CRITICAL: Undock to constrain shine to image only, not full width
                    picLogo.Dock = DockStyle.None;
                    picLogo.Size = new Size(500, 100); // Fixed size for logo area
                    picLogo.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
                    picLogo.BackColor = Color.Transparent;
                    // Center it, moved down to 40
                    picLogo.Location = new Point((this.ClientSize.Width - picLogo.Width) / 2, 40);

                    // -- SHINE ANIMATION --
                    // 1. Setup Timer
                    if (shineTimer == null)
                    {
                        shineTimer = new System.Windows.Forms.Timer();
                        shineTimer.Interval = 40; // Slightly faster updates
                        shineTimer.Tick += (s, e) => {
                            shinePos += 10; // Slower movement for elegance
                            // Reset when it goes off the controlled logo width
                            if (shinePos > picLogo.Width + 100) 
                                shinePos = -100;
                            picLogo.Invalidate(); // Trigger Paint
                        };
                        shineTimer.Start();
                    }

                    // 2. Setup Paint Event
                    picLogo.Paint -= PicLogo_Paint; 
                    picLogo.Paint += PicLogo_Paint;

                    // 3. Setup Interaction (New Requirement)
                    picLogo.Cursor = Cursors.Hand;
                    
                    picLogo.MouseEnter += (s, e) => {
                        isLogoHovered = true;
                        picLogo.Invalidate(); // Redraw with brightness
                    };
                    
                    picLogo.MouseLeave += (s, e) => {
                        isLogoHovered = false;
                        picLogo.Invalidate(); // Redraw normal
                    };

                    picLogo.Click += (s, e) => {
                        OpenForm(new HotelInfoForm());
                    };
                }

                // -- 2) Hotel Name Label --
                // REMOVED as per user request ("Yazıyı sil")
                if (lblHotelName != null) 
                {
                    lblHotelName.Visible = false; 
                }

                // Load Button Texture (Vintage)
                string btnPath = FindAsset("gold_vintage_btn.png");
                Image btnTexture = null;
                if (btnPath != null)
                {
                    btnTexture = Image.FromFile(btnPath);
                }

                // Apply texture to buttons
                ApplyButtonStyle(btnOdaBilgisi, btnTexture);
                ApplyButtonStyle(btnPersonel, btnTexture);
                ApplyButtonStyle(btnGelir, btnTexture);
                ApplyButtonStyle(btnDoluluk, btnTexture);
                ApplyButtonStyle(btnRaporlar, btnTexture);
                ApplyButtonStyle(btnMusteri, btnTexture);
                
                // Load Robot Button (Final Round)
                string botPath = FindAsset("gold_bot_circle.png");
                string botHoverPath = FindAsset("gold_bot_hover.png");
                
                if (botPath != null)
                {
                    Image normalImg = Image.FromFile(botPath);
                    Image hoverImg = (botHoverPath != null) ? Image.FromFile(botHoverPath) : normalImg;

                    // Use BackgroundImage for the button texture to fill it
                    btnHelp.BackgroundImage = normalImg;
                    btnHelp.BackgroundImageLayout = ImageLayout.Zoom; 
                    
                    // Clear text 
                    btnHelp.Text = ""; 
                    btnHelp.ImageOptions.Image = null;
                    
                    // Transparent
                    btnHelp.Appearance.BackColor = Color.Transparent;
                    btnHelp.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
                    
                    // Reposition safely away from corner ornaments to avoid visual clash
                    // Inset by ~240px to ensure it floats clearly inside the black background
                    btnHelp.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                    btnHelp.Location = new Point(this.ClientSize.Width - 240, this.ClientSize.Height - 240);

                    // Hover Effects
                    btnHelp.MouseEnter += (s, e) => {
                        btnHelp.BackgroundImage = hoverImg;
                        // Optional: slight cursor change or effect
                        this.Cursor = Cursors.Hand;
                    };
                    btnHelp.MouseLeave += (s, e) => {
                        btnHelp.BackgroundImage = normalImg;
                        this.Cursor = Cursors.Default;
                    };
                }
                else
                {
                    btnHelp.Text = "YARDIM";
                }
                
                // Style Help Button specifically
                btnHelp.Appearance.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
                btnHelp.Appearance.ForeColor = Color.Gold;
                btnHelp.Appearance.BorderColor = Color.Gold;
                btnHelp.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
                btnHelp.Appearance.BackColor = Color.Transparent;

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
            // 1. Style the Username Label to look interactive
            lblUserName.Cursor = Cursors.Hand;
            lblUserName.MouseEnter += (s, e) => {
                lblUserName.Appearance.ForeColor = Color.White; // Highlight on hover
            };
            lblUserName.MouseLeave += (s, e) => {
                lblUserName.Appearance.ForeColor = Color.FromArgb(198, 168, 105); // Back to Gold
            };
            lblUserName.Click += (s, e) => {
                // Toggle Menu
                if (pnlUserMenu != null)
                {
                    pnlUserMenu.Visible = !pnlUserMenu.Visible;
                    pnlUserMenu.BringToFront();
                }
            };

            // 2. Create the Dropdown Panel
            pnlUserMenu = new DevExpress.XtraEditors.PanelControl();
            pnlUserMenu.Visible = false;
            pnlUserMenu.Size = new Size(200, 100);
            pnlUserMenu.Appearance.BackColor = Color.Black;
            pnlUserMenu.Appearance.Options.UseBackColor = true;
            pnlUserMenu.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            pnlUserMenu.Appearance.BorderColor = Color.Gold;
            
            // Position it right below the username label (Center-ish)
            pnlUserMenu.Location = new Point((this.Width - pnlUserMenu.Width) / 2, lblUserName.Bottom + 5);
            this.Controls.Add(pnlUserMenu);
            pnlUserMenu.BringToFront();

            // 3. Create Buttons
            SimpleButton btnProfile = CreateMenuButton("PROFİL", 0);
            SimpleButton btnLogout = CreateMenuButton("ÇIKIŞ", 50);

            // 4. Button Logic
            btnProfile.Click += (s, e) => {
                pnlUserMenu.Visible = false;
                // Open Profile Form
                new ProfileForm().ShowDialog();
            };

            btnLogout.Click += (s, e) => {
                pnlUserMenu.Visible = false;
                // Logout Logic
                this.Hide();
                LoginForm login = new LoginForm();
                login.ShowDialog();
                this.Close();
            };

            pnlUserMenu.Controls.Add(btnProfile);
            pnlUserMenu.Controls.Add(btnLogout);
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
            btn.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder; // Clean look
            
            // Custom Hover for list item feel
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
            // Default styling (Visible even without image)
            btn.Appearance.Font = new Font("Segoe UI", 14f, FontStyle.Bold);
            btn.Appearance.ForeColor = Color.Gold; // Gold text by default for dark background

            if (texture != null)
            {
                // SimpleButton background setup
                btn.BackgroundImage = texture;
                btn.BackgroundImageLayout = ImageLayout.Stretch;
                
                // With gold button background, Black text usually looks better
                btn.Appearance.ForeColor = Color.Black; 
                btn.Appearance.Font = new Font("Segoe UI", 12f, FontStyle.Bold);
                
                // Make the button control itself transparent to show the rounded/ornate texture corners if any
                btn.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
                btn.BackColor = Color.Transparent;
            }
            else
            {
                // Fallback Gold Boarder
                btn.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
                btn.Appearance.BorderColor = Color.Gold;
            }
            
            // Hover effects
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
            btnOdaBilgisi.Click += (s, e) => OpenForm(new RoomForm());
            btnPersonel.Click += (s, e) => OpenForm(new StaffForm());
            btnMusteri.Click += (s, e) => OpenForm(new CustomerRegistrationForm()); // Assuming this is the customer form
            
            // Analytics - Placeholders or future forms
            btnGelir.Click += (s, e) => ShowInfo("Gelir Oranı Raporu yakında eklenecek.");
            btnDoluluk.Click += (s, e) => ShowInfo("Oda Doluluk Oranı Raporu yakında eklenecek.");
            btnRaporlar.Click += (s, e) => ShowInfo("Detaylı Raporlar modülü yakında eklenecek.");

            // Help / Chat
            btnHelp.Click += (s, e) => {
                // Check if ChatForm exists or open simple help
                try {
                    var chatForm = new ChatForm();
                    chatForm.Show();
                } catch {
                    ShowInfo("Yapay Zeka Asistanı başlatılıyor...");
                }
            };

            // Resize handling for centering
            this.Resize += AdminDashboard_Resize;
            CenterMenu();
        }

        private void AdminDashboard_Resize(object sender, EventArgs e)
        {
            CenterMenu();
        }

        private void CenterMenu()
        {
            if (picLogo != null)
            {
                // Re-center undocked logo, moved down to 40
                picLogo.Location = new Point((this.ClientSize.Width - picLogo.Width) / 2, 40);
            }
            
            if (pnlMenu != null)
            {
                // Slightly larger buttons as requested
                pnlMenu.Size = new Size(960, 360); 
                
                pnlMenu.Location = new Point(
                    (this.ClientSize.Width - pnlMenu.Width) / 2,
                    (this.ClientSize.Height - pnlMenu.Height) / 2 + 50 
                );
            }

            if (lblUserName != null)
            {
                // CRITICAL FIX: Disable Docking to allow manual positioning
                lblUserName.Dock = DockStyle.None; 
                lblUserName.AutoSize = true; 
                
                // Fix Label Position: Slightly Up as requested (Y=240)
                int centerX = (this.Width - lblUserName.Width) / 2;
                lblUserName.Location = new Point(centerX, 240);
                
                // Keep Popup aligned
                if (pnlUserMenu != null)
                {
                     pnlUserMenu.Location = new Point(
                        lblUserName.Location.X + (lblUserName.Width - pnlUserMenu.Width) / 2,
                        lblUserName.Bottom + 5
                    );
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
        private bool isLogoHovered = false; // Hover effect state // Store the source image here

        private void PicLogo_Paint(object sender, PaintEventArgs e)
        {
            // Use locally stored image, NOT the control's Image property
            // because we want to REPLACE the rendering, not draw over it.
            if (originalLogoImage == null) return;

            // 1. Calculate Draw Rect
            Size imgSize = originalLogoImage.Size;
            Size ctrlSize = picLogo.ClientSize;
            float ratio = Math.Min((float)ctrlSize.Width / imgSize.Width, (float)ctrlSize.Height / imgSize.Height);

            int w = (int)(imgSize.Width * ratio);
            int h = (int)(imgSize.Height * ratio);
            if (w <= 0 || h <= 0) return;

            int x = (ctrlSize.Width - w) / 2;
            int y = (ctrlSize.Height - h) / 2;

            // 2. Create Buffer to manipulate pixels
            using (Bitmap buffer = new Bitmap(w, h))
            {
                using (Graphics g = Graphics.FromImage(buffer))
                {
                    g.Clear(Color.Transparent); // Ensure buffer starts clear
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    g.DrawImage(originalLogoImage, 0, 0, w, h);
                }

                // 3. Lock Bits for Pixel Manipulation
                System.Drawing.Imaging.BitmapData data = buffer.LockBits(
                    new Rectangle(0, 0, w, h),
                    System.Drawing.Imaging.ImageLockMode.ReadWrite,
                    System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                int bytes = Math.Abs(data.Stride) * h;
                byte[] rgbValues = new byte[bytes];
                System.Runtime.InteropServices.Marshal.Copy(data.Scan0, rgbValues, 0, bytes);

                // Shine Parameters
                float beamWidth = 40f; 
                float localShineX = shinePos - x;
                float tilt = 0.5f; 

                // 4. Iterate Pixels
                for (int r = 0; r < h; r++)
                {
                    int rowOffset = r * data.Stride;
                    for (int c = 0; c < w; c++)
                    {
                        int idx = rowOffset + (c * 4);
                        byte alpha = rgbValues[idx + 3];

                        // optimization
                        if (alpha < 10) continue;

                        byte b_in = rgbValues[idx];
                        byte g_in = rgbValues[idx + 1];
                        byte r_in = rgbValues[idx + 2];

                        // CRITICAL FIX: Make Dark Pixels Transparent
                        // Increased threshold to 50 to be aggressive against compression artifacts
                        if (r_in < 50 && g_in < 50 && b_in < 50) 
                        {
                            rgbValues[idx + 3] = 0; // Transparent
                            continue;
                        }

                        // HOVER EFFECT: Brighten pixels
                        if (isLogoHovered)
                        {
                            // Increase brightness by scaling RGB
                            int b_hover = Math.Min(255, (int)(b_in * 1.5));
                            int g_hover = Math.Min(255, (int)(g_in * 1.5));
                            int r_hover = Math.Min(255, (int)(r_in * 1.5));

                            b_in = (byte)b_hover;
                            g_in = (byte)g_hover;
                            r_in = (byte)r_hover;
                            
                            // Write back base brighter color (so beam adds on top of this)
                            rgbValues[idx] = b_in;
                            rgbValues[idx + 1] = g_in;
                            rgbValues[idx + 2] = r_in;
                        }

                        // Beam logic
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

                // 5. Copy back & Draw
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
