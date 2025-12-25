
using System;
using System.Data.Entity;
using OtelOtomasyonu.Data.Entities;
using System.Collections.Generic;

namespace OtelOtomasyonu.Data
{
    public class HotelDbInitializer : DropCreateDatabaseIfModelChanges<HotelContext>
    {
        protected override void Seed(HotelContext context)
        {
            // Add Default Admin User
            var adminUser = new User
            {
                Username = "admin",
                Password = "123", 
                Role = UserRole.Admin,
                Name = "Beyzanur",
                Surname = "Karademirli",
                Department = Department.BackOffice, 
                JobTitle = "Otel Müdürü",
                Salary = 50000,
                WorkHours = "09:00 - 18:00"
            };

            context.Users.Add(adminUser);
            
            // Add Service Rooms for Zemin Kat (Matching uploaded plan)
            context.Rooms.Add(new Room { RoomNumber = "ANA MUTFAK", Floor = 0, Type = RoomType.Single, Price = 0, Status = RoomStatus.Available });
            context.Rooms.Add(new Room { RoomNumber = "TEKNİK SERVIS", Floor = 0, Type = RoomType.Single, Price = 0, Status = RoomStatus.Occupied });
            context.Rooms.Add(new Room { RoomNumber = "YÖNETİM", Floor = 0, Type = RoomType.Single, Price = 0, Status = RoomStatus.Available });
            context.Rooms.Add(new Room { RoomNumber = "RESTORAN", Floor = 0, Type = RoomType.Single, Price = 0, Status = RoomStatus.Available });
            context.Rooms.Add(new Room { RoomNumber = "BAGAJ ODASI", Floor = 0, Type = RoomType.Single, Price = 0, Status = RoomStatus.Available });
            context.Rooms.Add(new Room { RoomNumber = "RESEPSİYON", Floor = 0, Type = RoomType.Single, Price = 0, Status = RoomStatus.Available });
            context.Rooms.Add(new Room { RoomNumber = "LOBİ BAR", Floor = 0, Type = RoomType.Single, Price = 0, Status = RoomStatus.Available });
            
            // Guest Rooms for Upper Floors
             for (int i = 0; i < 10; i++)
            {
                context.Rooms.Add(new Room { RoomNumber = $"1-{101+i}", Floor = 1, Type = RoomType.Suite, Price = 1500, Status = RoomStatus.Available });
            }

            // Seed Financial Data (Payments) - Last 5 days
            var rnd = new System.Random();
            
            // Need a customer for reservations
            var customer = new User { 
                Username = "guest_payment", 
                Password = "123", 
                Role = UserRole.Customer, 
                Name = "Misafir", 
                Surname = "Müşteri" 
            };
            context.Users.Add(customer);

            // Fetch a room (using the local list since they aren't saved yet, we can create a dummy one or link to one of the ones added above correctly if we had variables)
            // Easier: Create a generic dummy room for these past payments
            var dummyRoom = new Room { RoomNumber = "999", Type = RoomType.Single, Price = 1000, Status = RoomStatus.Available, Floor = 1 };
            context.Rooms.Add(dummyRoom);

            for (int i = 0; i < 20; i++)
            {
                // Create a dummy completed reservation for this payment
                var res = new Reservation
                {
                    Customer = customer,
                    Room = dummyRoom,
                    StartDate = DateTime.Now.AddDays(-10),
                    EndDate = DateTime.Now.AddDays(-5),
                    TotalPrice = 5000,
                    Status = ReservationStatus.Completed
                };

                context.Payments.Add(new Payment
                {
                    Amount = rnd.Next(1000, 5000),
                    PaymentDate = DateTime.Now.AddDays(-rnd.Next(0, 30)), // Last 30 days
                    PaymentType = PaymentType.CreditCard,
                    Status = PaymentStatus.Completed,
                    TransactionId = Guid.NewGuid().ToString().Substring(0, 8),
                    Reservation = res // Link via navigation property
                });
            }

            // Seed Expenses
            context.Expenses.Add(new Expense { Category = ExpenseCategory.Kitchen, Amount = 5000, Date = DateTime.Now, Description = "Toptan Gıda Alımı" });
            context.Expenses.Add(new Expense { Category = ExpenseCategory.Bill, Amount = 1200, Date = DateTime.Now.AddDays(-2), Description = "Elektrik Faturası" });
            context.Expenses.Add(new Expense { Category = ExpenseCategory.Maintenance, Amount = 3000, Date = DateTime.Now.AddDays(-5), Description = "Asansör Bakımı" });
            context.Expenses.Add(new Expense { Category = ExpenseCategory.Material, Amount = 800, Date = DateTime.Now.AddDays(-1), Description = "Temizlik Malzemeleri" });

            base.Seed(context);
        }
    }
}
