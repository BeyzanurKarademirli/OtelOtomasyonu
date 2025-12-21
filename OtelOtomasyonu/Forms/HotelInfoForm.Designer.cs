namespace OtelOtomasyonu.Forms
{
    partial class HotelInfoForm
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
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Text = "Hotel Info";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Size = new System.Drawing.Size(800, 600);
        }
    }
}
