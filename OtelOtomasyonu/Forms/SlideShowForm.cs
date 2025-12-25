using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace OtelOtomasyonu.Forms
{
    public partial class SlideShowForm : XtraForm
    {
        private List<string> imagePaths = new List<string>();
        private int currentIndex = 0;

        public SlideShowForm()
        {
            InitializeComponent();
        }

        private void SlideShowForm_Load(object sender, EventArgs e)
        {
            LoadImages();
            if (imagePaths.Count > 0)
            {
                ShowSlide(0);
                slideTimer.Start();
            }
            else
            {
                XtraMessageBox.Show("Gösterilebilecek slayt bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void LoadImages()
        {
            // Load images from Resources/Slides folder
            string slidesDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Slides");
            
            // If running in VS, the path might be slightly different depending on build output, 
            // but we copied them to project root/Resources/Slides. 
            // However, the executing assembly is in bin/Debug.
            // We should check if the directory exists relative to executable or handle absolute path used in 'copy'
            
            // Let's try finding them.
            // Option 1: Try the path we just copied to (Project Source)
            string sourceDir = @"c:\Users\ASUS\source\repos\OtelOtomasyonu\OtelOtomasyonu\Resources\Slides";
            
            if (Directory.Exists(sourceDir))
            {
                 var files = Directory.GetFiles(sourceDir, "*.*")
                    .Where(f => f.EndsWith(".jpg") || f.EndsWith(".png") || f.EndsWith(".jpeg"))
                    .OrderBy(f => f) // Order by name (slide1, slide2...)
                    .ToList();
                 imagePaths.AddRange(files);
            }
        }

        private void ShowSlide(int index)
        {
            if (imagePaths.Count == 0) return;

            // Loop
            if (index >= imagePaths.Count) index = 0;
            if (index < 0) index = imagePaths.Count - 1;

            currentIndex = index;

            // Load Image
            try 
            {
                if (picSlide.Image != null) picSlide.Image.Dispose(); // Memory management
                picSlide.Image = Image.FromFile(imagePaths[currentIndex]);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading image: " + ex.Message);
            }
        }

        private void slideTimer_Tick(object sender, EventArgs e)
        {
            ShowSlide(currentIndex + 1);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            slideTimer.Stop();
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            slideTimer.Stop(); // Reset timer on manual interaction
            slideTimer.Start();
            ShowSlide(currentIndex + 1);
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            slideTimer.Stop();
            slideTimer.Start();
            ShowSlide(currentIndex - 1);
        }
    }
}
