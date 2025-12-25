
namespace OtelOtomasyonu.Forms.Controls
{
    partial class RoomControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblRoomNumber = new DevExpress.XtraEditors.LabelControl();
            this.pnlBadge = new System.Windows.Forms.Panel();
            this.lblStatus = new DevExpress.XtraEditors.LabelControl();
            this.pnlBadge.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblRoomNumber removed (Drawn in OnPaint)
            //
            // 
            // pnlBadge
            // 
            this.pnlBadge.Controls.Add(this.lblStatus);
            this.pnlBadge.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBadge.Location = new System.Drawing.Point(0, 35);
            this.pnlBadge.Name = "pnlBadge";
            this.pnlBadge.Size = new System.Drawing.Size(120, 25);
            this.pnlBadge.TabIndex = 1;
            // 
            // lblStatus
            // 
            this.lblStatus.Appearance.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblStatus.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblStatus.Appearance.Options.UseFont = true;
            this.lblStatus.Appearance.Options.UseForeColor = true;
            this.lblStatus.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblStatus.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatus.Location = new System.Drawing.Point(0, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(120, 25);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "BOŞ";
            // 
            // RoomControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBackColor = true;
            this.Controls.Add(this.pnlBadge);

            this.Name = "RoomControl";
            this.Size = new System.Drawing.Size(120, 60);
            this.pnlBadge.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblRoomNumber;
        private System.Windows.Forms.Panel pnlBadge;
        private DevExpress.XtraEditors.LabelControl lblStatus;
    }
}
