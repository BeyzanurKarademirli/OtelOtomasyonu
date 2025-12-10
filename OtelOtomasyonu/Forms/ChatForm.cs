using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using OtelOtomasyonu.Services;
using System.Threading.Tasks;

namespace OtelOtomasyonu.Forms
{
    public partial class ChatForm : XtraForm
    {
        private GeminiChatService _chatService;

        public ChatForm()
        {
            InitializeComponent();
            _chatService = new GeminiChatService();
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            await SendMessage();
        }

        private async void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !e.Shift)
            {
                e.SuppressKeyPress = true; // Prevent new line
                await SendMessage();
            }
        }

        private async Task SendMessage()
        {
            string message = txtInput.Text.Trim();
            if (string.IsNullOrEmpty(message)) return;

            AppendMessage("Siz", message);
            txtInput.Text = "";
            txtInput.Enabled = false;
            btnSend.Enabled = false;

            try
            {
                // Show typing indicator or similar if needed
                string response = await _chatService.AskAsync(message);
                AppendMessage("Asistan", response);
            }
            catch (Exception ex)
            {
                AppendMessage("Sistem", $"Hata: {ex.Message}");
            }
            finally
            {
                txtInput.Enabled = true;
                btnSend.Enabled = true;
                txtInput.Focus();
            }
        }

        private void AppendMessage(string sender, string message)
        {
            string timestamp = DateTime.Now.ToString("HH:mm");
            string formattedMessage = $"{sender} ({timestamp}):\r\n{message}\r\n\r\n";
            
            memoHistory.Text += formattedMessage;
            
            // Scroll to bottom
            memoHistory.SelectionStart = memoHistory.Text.Length;
            memoHistory.ScrollToCaret();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _chatService?.Dispose();
            base.OnFormClosing(e);
        }
    }
}
