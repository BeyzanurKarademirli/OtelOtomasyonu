using System;
using System.Linq;
using OtelOtomasyonu.Data;
using OtelOtomasyonu.Data.Entities;

namespace OtelOtomasyonu.Services
{
    public class AuthService
    {
        public User Login(string username, string password)
        {
            using (var context = new HotelContext())
            {
                // In a real app, password should be hashed!
                var user = context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
                return user;
            }
        }

        public void Register(string username, string password, UserRole role)
        {
            using (var context = new HotelContext())
            {
                if (context.Users.Any(u => u.Username == username))
                {
                    throw new Exception("Bu kullanıcı adı zaten alınmış.");
                }

                var newUser = new User
                {
                    Username = username,
                    Password = password,
                    Role = role
                };

                context.Users.Add(newUser);
                context.SaveChanges();
            }
        }
    }
}
