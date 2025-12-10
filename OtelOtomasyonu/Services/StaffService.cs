using System;
using System.Collections.Generic;
using System.Linq;
using OtelOtomasyonu.Data;
using OtelOtomasyonu.Data.Entities;

namespace OtelOtomasyonu.Services
{
    public class StaffService
    {
        public List<User> GetAllStaff()
        {
            using (var context = new HotelContext())
            {
                return context.Users
                    .Where(u => u.Role == UserRole.Staff)
                    .ToList();
            }
        }

        public void AddStaff(string username, string password)
        {
            using (var context = new HotelContext())
            {
                if (context.Users.Any(u => u.Username == username))
                {
                    throw new Exception("Bu kullanıcı adı zaten kullanımda.");
                }

                var newStaff = new User
                {
                    Username = username,
                    Password = password,
                    Role = UserRole.Staff
                };

                context.Users.Add(newStaff);
                context.SaveChanges();
            }
        }

        public void UpdateStaff(int userId, string username, string password)
        {
            using (var context = new HotelContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Id == userId);
                if (user != null)
                {
                    if (user.Role != UserRole.Staff)
                    {
                        throw new Exception("Sadece personel güncellenebilir.");
                    }

                    // Check if new username is taken by another user
                    if (context.Users.Any(u => u.Username == username && u.Id != userId))
                    {
                        throw new Exception("Bu kullanıcı adı zaten kullanımda.");
                    }

                    user.Username = username;
                    if (!string.IsNullOrWhiteSpace(password))
                    {
                        user.Password = password;
                    }
                    context.SaveChanges();
                }
            }
        }

        public void DeleteStaff(int userId)
        {
            using (var context = new HotelContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Id == userId);
                if (user != null)
                {
                    if (user.Role != UserRole.Staff)
                    {
                        throw new Exception("Sadece personel silinebilir.");
                    }

                    context.Users.Remove(user);
                    context.SaveChanges();
                }
            }
        }
    }
}
