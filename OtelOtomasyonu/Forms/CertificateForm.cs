using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;

namespace OtelOtomasyonu.Forms
{
    public partial class CertificateForm : XtraForm
    {
        public CertificateForm()
        {
            InitializeComponent();
        }

        // Carousel Logic
        private Timer scrollTimer;
        private Timer animationTimer;
        private int currentScrollTarget = 0;
        private int itemWidthWithMargin = 640; // 600 width + 20 left + 20 right
        private int totalItems = 0;
        private int currentItemIndex = 0;

        private void CertificateForm_Load(object sender, EventArgs e)
        {
            ApplyTheme();
            LoadCertificates();
            SetupCarousel();

            // Handle Resizing to keep scrollbar hidden and fill width
            this.pnlContainer.SizeChanged += (s, ev) => {
                flowPanel.Size = new Size(pnlContainer.Width, pnlContainer.Height + 40);
            };
            // Trigger once
            flowPanel.Size = new Size(pnlContainer.Width, pnlContainer.Height + 40);
        }

        private void SetupCarousel()
        {
            // Timer to trigger the slide (every 3 seconds)
            scrollTimer = new Timer();
            scrollTimer.Interval = 3000;
            scrollTimer.Tick += ScrollTimer_Tick;
            scrollTimer.Start();

            // Timer for smooth animation
            animationTimer = new Timer();
            animationTimer.Interval = 15;
            animationTimer.Tick += AnimationTimer_Tick;
        }

        private void ScrollTimer_Tick(object sender, EventArgs e)
        {
            if (totalItems == 0) return;

            // Move to next item
            currentItemIndex++;
            
            // Loop back to start if at end
            if (currentItemIndex >= totalItems)
            {
                currentItemIndex = 0;
            }

            // Calculate target scroll position
            // Note: HorizontalScroll value is technically pixels, but AutoScrollPosition uses negative values internally or positive for assignment
            currentScrollTarget = currentItemIndex * itemWidthWithMargin;
            
            animationTimer.Start();
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            int current = flowPanel.HorizontalScroll.Value;
            
            // Smooth step (lerp-ish)
            int direction = currentScrollTarget > current ? 1 : -1;
            int step = Math.Abs(currentScrollTarget - current) / 10;
            if (step < 5) step = 5; // Minimum speed

            int nextPos = current + (step * direction);

            // Check if reached (or passed)
            if ((direction == 1 && nextPos >= currentScrollTarget) || 
                (direction == -1 && nextPos <= currentScrollTarget))
            {
                nextPos = currentScrollTarget;
                animationTimer.Stop();
            }

            // Apply scroll
            flowPanel.AutoScrollPosition = new Point(nextPos, 0);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (totalItems == 0) return;

            // Reset Timer to prevent interference
            scrollTimer.Stop();
            scrollTimer.Start();

            currentItemIndex++;
            if (currentItemIndex >= totalItems) currentItemIndex = 0;
            
            currentScrollTarget = currentItemIndex * itemWidthWithMargin;
            animationTimer.Start();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (totalItems == 0) return;

            // Reset Timer
            scrollTimer.Stop();
            scrollTimer.Start();

            currentItemIndex--;
            if (currentItemIndex < 0) currentItemIndex = totalItems - 1;
             
            currentScrollTarget = currentItemIndex * itemWidthWithMargin;
            animationTimer.Start();
        }
        
        private void ApplyTheme()
        {
            Color darkBg = Color.FromArgb(30, 30, 30);
            
            this.Appearance.BackColor = darkBg;
            pnlHeader.Appearance.BackColor = darkBg;
            pnlHeader.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            flowPanel.BackColor = darkBg;
            
            // Container Panel Styling
            if (pnlContainer != null)
            {
                pnlContainer.BackColor = darkBg;
            }
            
            // New Bottom Panel
            if (pnlBottom != null)
            {
                pnlBottom.Appearance.BackColor = darkBg;
                pnlBottom.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            }
        }

        private void LoadCertificates()
        {
            try
            {
                // Find Resources/Certificates folder
                string certPath = Path.Combine(Application.StartupPath, "..\\..\\Resources\\Certificates");
                
                if (!Directory.Exists(certPath))
                {
                    // Try looking in bin/Debug if copied (optional, but for now we rely on source path for dev)
                    certPath = Path.Combine(Application.StartupPath, "Resources\\Certificates"); 
                }

                if (Directory.Exists(certPath))
                {
                    string[] files = Directory.GetFiles(certPath, "*.jpg"); // Assuming jpg as copied
                    totalItems = files.Length;
                    
                    if (files.Length == 0)
                    {
                        Console.WriteLine("No certificates found in " + certPath);
                    }

                    foreach (string file in files)
                    {
                        AddCertificateImage(file);
                    }
                }
                else
                {
                    // Fallback or error logging
                    Console.WriteLine("Certificate path not found: " + certPath);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Sertifikalar yüklenirken hata oluştu: " + ex.Message);
            }
        }

        private void AddCertificateImage(string imagePath)
        {
            if (!File.Exists(imagePath)) return;

            // Container Panel for each image (to add spacing/border/caption if needed)
            Panel pnlItem = new Panel();
            pnlItem.Size = new Size(600, 650); // Fixed size for item
            pnlItem.Margin = new Padding(20, 10, 20, 10);
            pnlItem.BackColor = Color.FromArgb(40, 40, 40);

            // PictureBox
            PictureBox pb = new PictureBox();
            pb.Image = Image.FromFile(imagePath);
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            pb.Dock = DockStyle.Fill;
            pb.BackColor = Color.Transparent;

            pnlItem.Controls.Add(pb);
            flowPanel.Controls.Add(pnlItem);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
