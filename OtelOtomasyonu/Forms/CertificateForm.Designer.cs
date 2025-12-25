
namespace OtelOtomasyonu.Forms
{
    partial class CertificateForm
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlHeader = new DevExpress.XtraEditors.PanelControl();
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.btnBack = new DevExpress.XtraEditors.SimpleButton();
            
            this.flowPanel = new System.Windows.Forms.FlowLayoutPanel();

            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.btnBack);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1200, 60);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Appearance.ForeColor = System.Drawing.Color.Gold;
            this.lblTitle.Location = new System.Drawing.Point(70, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(268, 30);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "SERTİFİKALAR VE BELGELER";
            // 
            // btnBack
            // 
            this.btnBack.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnBack.Appearance.Options.UseBackColor = true;
            this.btnBack.Appearance.Options.UseFont = true;
            this.btnBack.Location = new System.Drawing.Point(10, 10);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(40, 40);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "<";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // 
            // pnlContainer
            // 
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill; // Changed to Fill
            this.pnlContainer.Location = new System.Drawing.Point(0, 60);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(1200, 680);
            this.pnlContainer.TabIndex = 1;
            this.pnlContainer.Controls.Add(this.flowPanel);

            // 
            // flowPanel
            // 
            this.flowPanel.Dock = System.Windows.Forms.DockStyle.None; // Changed from Fill
            this.flowPanel.AutoScroll = true;
            this.flowPanel.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.flowPanel.WrapContents = false; 
            this.flowPanel.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
            this.flowPanel.Padding = new System.Windows.Forms.Padding(20);
            this.flowPanel.Location = new System.Drawing.Point(0, 0);
            this.flowPanel.Name = "flowPanel";
            this.flowPanel.Size = new System.Drawing.Size(1200, 720); // Height increased to hide scrollbar (680 + 40)
            this.flowPanel.TabIndex = 0;

            // 
            // pnlBottom
            // 
            this.pnlBottom = new DevExpress.XtraEditors.PanelControl();
            this.btnPrev = new DevExpress.XtraEditors.SimpleButton();
            this.btnNext = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).BeginInit();
            this.pnlBottom.SuspendLayout();
            
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnPrev);
            this.pnlBottom.Controls.Add(this.btnNext);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 740);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1200, 60);
            this.pnlBottom.TabIndex = 2;
            
            // 
            // btnPrev
            // 
            this.btnPrev.Anchor = System.Windows.Forms.AnchorStyles.Bottom; // Center
            this.btnPrev.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.btnPrev.Appearance.ForeColor = System.Drawing.Color.Gold;
            this.btnPrev.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btnPrev.Appearance.Options.UseFont = true;
            this.btnPrev.Appearance.Options.UseForeColor = true;
            this.btnPrev.Appearance.Options.UseBackColor = true;
            this.btnPrev.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnPrev.Location = new System.Drawing.Point(540, 10); // Center - offset
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(50, 40);
            this.btnPrev.TabIndex = 0;
            this.btnPrev.Text = "<";
            this.btnPrev.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);

            // 
            // btnNext
            // 
            this.btnNext.Anchor = System.Windows.Forms.AnchorStyles.Bottom; // Center
            this.btnNext.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.btnNext.Appearance.ForeColor = System.Drawing.Color.Gold;
            this.btnNext.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btnNext.Appearance.Options.UseFont = true;
            this.btnNext.Appearance.Options.UseForeColor = true;
            this.btnNext.Appearance.Options.UseBackColor = true;
            this.btnNext.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnNext.Location = new System.Drawing.Point(610, 10); // Center + offset
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(50, 40);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = ">";
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);

            // 
            // CertificateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.Controls.Add(this.pnlContainer); // Add Container
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlHeader);
            this.Name = "CertificateForm";
            this.Text = "Sertifikalar";
            this.Load += new System.EventHandler(this.CertificateForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlBottom)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlContainer.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlHeader;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.SimpleButton btnBack;
        
        private System.Windows.Forms.Panel pnlContainer; // Added Wrapper
        private System.Windows.Forms.FlowLayoutPanel flowPanel;
        
        private DevExpress.XtraEditors.PanelControl pnlBottom;
        private DevExpress.XtraEditors.SimpleButton btnPrev;
        private DevExpress.XtraEditors.SimpleButton btnNext;
    }
}
