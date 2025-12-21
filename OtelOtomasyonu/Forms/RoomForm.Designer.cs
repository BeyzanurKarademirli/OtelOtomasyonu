namespace OtelOtomasyonu.Forms
{
    partial class RoomForm
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.txtRoomNumber = new DevExpress.XtraEditors.TextEdit();
            this.cmbRoomType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtPrice = new DevExpress.XtraEditors.TextEdit();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.lblNumber = new DevExpress.XtraEditors.LabelControl();
            this.lblType = new DevExpress.XtraEditors.LabelControl();
            this.lblPrice = new DevExpress.XtraEditors.LabelControl();

            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRoomNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbRoomType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice.Properties)).BeginInit();
            this.SuspendLayout();

            // GridControl
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gridView1 });

            // GridView
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;

            // PanelControl
            this.panelControl1.Controls.Add(this.lblPrice);
            this.panelControl1.Controls.Add(this.lblType);
            this.panelControl1.Controls.Add(this.lblNumber);
            this.panelControl1.Controls.Add(this.btnDelete);
            this.panelControl1.Controls.Add(this.btnAdd);
            this.panelControl1.Controls.Add(this.txtPrice);
            this.panelControl1.Controls.Add(this.cmbRoomType);
            this.panelControl1.Controls.Add(this.txtRoomNumber);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Height = 80;
            this.panelControl1.Name = "panelControl1";

            // Controls
            this.lblNumber.Text = "Oda No:";
            this.lblNumber.Location = new System.Drawing.Point(10, 15);
            
            this.txtRoomNumber.Location = new System.Drawing.Point(60, 12);
            this.txtRoomNumber.Size = new System.Drawing.Size(100, 20);

            this.lblType.Text = "Tip:";
            this.lblType.Location = new System.Drawing.Point(180, 15);

            this.cmbRoomType.Location = new System.Drawing.Point(210, 12);
            this.cmbRoomType.Size = new System.Drawing.Size(120, 20);

            this.lblPrice.Text = "Fiyat:";
            this.lblPrice.Location = new System.Drawing.Point(350, 15);

            this.txtPrice.Location = new System.Drawing.Point(390, 12);
            this.txtPrice.Size = new System.Drawing.Size(100, 20);

            this.btnAdd.Text = "Ekle";
            this.btnAdd.Location = new System.Drawing.Point(520, 10);
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.btnDelete.Text = "Seçiliyi Sil";
            this.btnDelete.Location = new System.Drawing.Point(610, 10);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // Form
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(770, 700);
            this.MaximumSize = new System.Drawing.Size(770, 700);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panelControl1);
            this.Name = "RoomForm";
            this.Text = "Ada Lovelady's Hotel - Oda Yönetimi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRoomNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbRoomType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice.Properties)).EndInit();
            this.ResumeLayout(false);
        }

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.TextEdit txtRoomNumber;
        private DevExpress.XtraEditors.ComboBoxEdit cmbRoomType;
        private DevExpress.XtraEditors.TextEdit txtPrice;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.LabelControl lblNumber;
        private DevExpress.XtraEditors.LabelControl lblType;
        private DevExpress.XtraEditors.LabelControl lblPrice;
    }
}
