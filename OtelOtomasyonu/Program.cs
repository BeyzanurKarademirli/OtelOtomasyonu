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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Ensure database is created
            try 
            {
                using (var context = new HotelContext())
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

                    // Seed staff members
                    if (!context.Users.Any(u => u.Username == "Derya Acerce"))
                    {
                        context.Users.Add(new Data.Entities.User
                        {
                            Username = "Derya Acerce",
                            Password = "Deryaa.642.",
                            Role = Data.Entities.UserRole.Staff,
                            Name = "Derya",
                            Surname = "Acerce"
                        });
                        context.SaveChanges();
                    }

                    if (!context.Users.Any(u => u.Username == "Büşra Yeşilbulut"))
                    {
                        context.Users.Add(new Data.Entities.User
                        {
                            Username = "Büşra Yeşilbulut",
                            Password = "Büşraa.642.",
                            Role = Data.Entities.UserRole.Staff,
                            Name = "Büşra",
                            Surname = "Yeşilbulut"
                        });
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı başlatılamadı: " + ex.Message);
            }

            Application.Run(new LoginForm());
        }
    }
}
