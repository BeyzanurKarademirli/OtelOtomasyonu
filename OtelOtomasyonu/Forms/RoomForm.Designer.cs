
namespace OtelOtomasyonu.Forms
{
    partial class RoomForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlSidebar = new DevExpress.XtraEditors.PanelControl();
            this.lstFloors = new DevExpress.XtraEditors.ListBoxControl();
            this.lblFloorsTitle = new DevExpress.XtraEditors.LabelControl();
            this.pnlMap = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSidebar)).BeginInit();
            this.pnlSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstFloors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMap)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.pnlSidebar.Appearance.Options.UseBackColor = true;
            this.pnlSidebar.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlSidebar.Controls.Add(this.lstFloors);
            this.pnlSidebar.Controls.Add(this.lblFloorsTitle);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Padding = new System.Windows.Forms.Padding(10);
            this.pnlSidebar.Size = new System.Drawing.Size(200, 700);
            this.pnlSidebar.TabIndex = 0;
            // 
            // lstFloors
            // 
            this.lstFloors.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lstFloors.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lstFloors.Appearance.ForeColor = System.Drawing.Color.Gold;
            this.lstFloors.Appearance.Options.UseBackColor = true;
            this.lstFloors.Appearance.Options.UseFont = true;
            this.lstFloors.Appearance.Options.UseForeColor = true;
            this.lstFloors.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lstFloors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstFloors.ItemHeight = 50;
            this.lstFloors.Location = new System.Drawing.Point(10, 50);
            this.lstFloors.Name = "lstFloors";
            this.lstFloors.Size = new System.Drawing.Size(180, 640);
            this.lstFloors.TabIndex = 1;
            this.lstFloors.SelectedIndexChanged += new System.EventHandler(this.LstFloors_SelectedIndexChanged);
            // 
            // lblFloorsTitle
            // 
            this.lblFloorsTitle.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblFloorsTitle.Appearance.ForeColor = System.Drawing.Color.Gold;
            this.lblFloorsTitle.Appearance.Options.UseFont = true;
            this.lblFloorsTitle.Appearance.Options.UseForeColor = true;
            this.lblFloorsTitle.Appearance.Options.UseTextOptions = true;
            this.lblFloorsTitle.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblFloorsTitle.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblFloorsTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblFloorsTitle.Location = new System.Drawing.Point(10, 10);
            this.lblFloorsTitle.Name = "lblFloorsTitle";
            this.lblFloorsTitle.Size = new System.Drawing.Size(180, 40);
            this.lblFloorsTitle.TabIndex = 0;
            this.lblFloorsTitle.Text = "KATLAR";
            // 
            // pnlMap
            // 
            this.pnlMap.Appearance.BackColor = System.Drawing.Color.Black;
            this.pnlMap.Appearance.Options.UseBackColor = true;
            this.pnlMap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlMap.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMap.Location = new System.Drawing.Point(200, 0);
            this.pnlMap.Name = "pnlMap";
            this.pnlMap.Size = new System.Drawing.Size(1000, 700);
            this.pnlMap.TabIndex = 1;
            // 
            // RoomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.pnlMap);
            this.Controls.Add(this.pnlSidebar);
            this.Name = "RoomForm";
            this.Text = "Ada Lovelady's Hotel - Oda Yönetimi";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.RoomForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlSidebar)).EndInit();
            this.pnlSidebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lstFloors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlSidebar;
        private DevExpress.XtraEditors.ListBoxControl lstFloors;
        private DevExpress.XtraEditors.LabelControl lblFloorsTitle;
        private DevExpress.XtraEditors.PanelControl pnlMap;
    }
}
