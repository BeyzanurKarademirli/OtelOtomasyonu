namespace OtelOtomasyonu.Forms
{
    partial class SlideShowForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SlideShowForm));
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.picSlide = new System.Windows.Forms.PictureBox();
            this.slideTimer = new System.Windows.Forms.Timer(this.components);
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrev = new DevExpress.XtraEditors.SimpleButton();
            this.btnNext = new DevExpress.XtraEditors.SimpleButton();
            this.pnlContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSlide)).BeginInit();
            this.SuspendLayout();
            
            // 
            // pnlContainer (Black Inner Area)
            // 
            this.pnlContainer.BackColor = System.Drawing.Color.Black;
            this.pnlContainer.Controls.Add(this.btnNext);
            this.pnlContainer.Controls.Add(this.btnPrev);
            this.pnlContainer.Controls.Add(this.btnClose);
            this.pnlContainer.Controls.Add(this.picSlide);
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(10, 10); // Respect Form Padding
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(780, 430);
            this.pnlContainer.TabIndex = 0;

            // 
            // picSlide
            // 
            this.picSlide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picSlide.Location = new System.Drawing.Point(0, 0);
            this.picSlide.Name = "picSlide";
            this.picSlide.Size = new System.Drawing.Size(780, 430);
            this.picSlide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSlide.TabIndex = 0;
            this.picSlide.TabStop = false;
            
            // 
            // slideTimer
            // 
            this.slideTimer.Interval = 3000;
            this.slideTimer.Tick += new System.EventHandler(this.slideTimer_Tick);
            
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnClose.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnClose.Appearance.BackColor = System.Drawing.Color.Red;
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Appearance.Options.UseForeColor = true;
            this.btnClose.Appearance.Options.UseBackColor = true;
            this.btnClose.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.btnClose.Location = new System.Drawing.Point(730, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(40, 40);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "X";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.BringToFront();

            // 
            // btnPrev
            // 
            this.btnPrev.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnPrev.Appearance.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold);
            this.btnPrev.Appearance.ForeColor = System.Drawing.Color.Gold;
            this.btnPrev.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btnPrev.Appearance.Options.UseFont = true;
            this.btnPrev.Appearance.Options.UseForeColor = true;
            this.btnPrev.Appearance.Options.UseBackColor = true;
            this.btnPrev.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnPrev.Location = new System.Drawing.Point(10, 190);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(50, 60);
            this.btnPrev.TabIndex = 2;
            this.btnPrev.Text = "<";
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            this.btnPrev.BringToFront();

            // 
            // btnNext
            // 
            this.btnNext.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnNext.Appearance.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold);
            this.btnNext.Appearance.ForeColor = System.Drawing.Color.Gold;
            this.btnNext.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btnNext.Appearance.Options.UseFont = true;
            this.btnNext.Appearance.Options.UseForeColor = true;
            this.btnNext.Appearance.Options.UseBackColor = true;
            this.btnNext.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnNext.Location = new System.Drawing.Point(720, 190);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(50, 60);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = ">";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            this.btnNext.BringToFront();

            // 
            // SlideShowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(175)))), ((int)(((byte)(55))))); // Gold Border
            this.Padding = new System.Windows.Forms.Padding(10); // Thickness of the frame
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SlideShowForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.SlideShowForm_Load);
            this.pnlContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picSlide)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.PictureBox picSlide;
        private System.Windows.Forms.Timer slideTimer;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnPrev;
        private DevExpress.XtraEditors.SimpleButton btnNext;
    }
}
