namespace OtelOtomasyonu.Forms
{
    partial class ChatForm
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
            this.memoHistory = new DevExpress.XtraEditors.MemoEdit();
            this.txtInput = new DevExpress.XtraEditors.MemoEdit();
            this.btnSend = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.memoHistory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInput.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // memoHistory
            // 
            this.memoHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.memoHistory.Location = new System.Drawing.Point(0, 0);
            this.memoHistory.Name = "memoHistory";
            this.memoHistory.Properties.ReadOnly = true;
            this.memoHistory.Properties.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.memoHistory.Size = new System.Drawing.Size(484, 361);
            this.memoHistory.TabIndex = 0;
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(5, 5);
            this.txtInput.Name = "txtInput";
            this.txtInput.Properties.NullValuePrompt = "Mesajınızı yazın...";
            this.txtInput.Size = new System.Drawing.Size(380, 50);
            this.txtInput.TabIndex = 1;
            this.txtInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInput_KeyDown);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(391, 5);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(88, 50);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Gönder";
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.txtInput);
            this.panelControl1.Controls.Add(this.btnSend);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 361);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(484, 60);
            this.panelControl1.TabIndex = 1;
            // 
            // ChatForm
            // 
            this.AutoScroll = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 700);
            this.MaximumSize = new System.Drawing.Size(770, 700);
            this.Controls.Add(this.memoHistory);
            this.Controls.Add(this.panelControl1);
            this.Name = "ChatForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ada Lovelady's Hotel - AI Asistan";
            ((System.ComponentModel.ISupportInitialize)(this.memoHistory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInput.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.MemoEdit memoHistory;
        private DevExpress.XtraEditors.MemoEdit txtInput;
        private DevExpress.XtraEditors.SimpleButton btnSend;
        private DevExpress.XtraEditors.PanelControl panelControl1;
    }
}
