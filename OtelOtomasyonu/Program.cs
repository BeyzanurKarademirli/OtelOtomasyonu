using System;
using System.Windows.Forms;
using OtelOtomasyonu.Forms;
using OtelOtomasyonu.Data;
using System.Linq;

namespace OtelOtomasyonu
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                // Ensure database is created
                using (var context = new HotelContext())
                {
                    // Check connection specifically
                    try
                    {
                        if (!context.Database.Exists())
                        {
                            context.Database.Create();
                        }
                        
                        // Seed specific admin user
                        if (!context.Users.Any(u => u.Username == "Beyzanur Karademirli"))
                        {
                            context.Users.Add(new Data.Entities.User 
                            { 
                                Username = "Beyzanur Karademirli", 
                                Password = "Beyzaa.642.", 
                                Role = Data.Entities.UserRole.Admin,
                                Name = "Beyzanur",
                                Surname = "Karademirli"
                            });
                            context.SaveChanges();
                        }
                        
                        // ... (Other seeds kept simple or removed for brevity if safely in Initializer)
                        // Actually, let's keep the existing logic but wrap the whole block properly
                    }
                    catch (Exception dbEx)
                    {
                        MessageBox.Show($"Veritabanı Erişim Hatası:\n{dbEx.Message}\n\nDetay:\n{dbEx.InnerException?.Message}", "Başlatma Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        // Don't modify code flow too much, just report
                    }
                }
                
                Application.Run(new LoginForm());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kritik Hata:\n{ex.Message}\n\nStack Trace:\n{ex.StackTrace}", "Uygulama Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            MessageBox.Show($"Beklenmeyen Hata (Thread):\n{e.Exception.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBox.Show($"Beklenmeyen Hata (Domain):\n{(e.ExceptionObject as Exception)?.Message}", "Kritik Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
