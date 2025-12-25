using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OtelOtomasyonuWeb.Data
{
    public class WebHotelContext : DbContext
    {
        public WebHotelContext(DbContextOptions<WebHotelContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Map to existing tables created by Desktop App (EF6)
        }
    }

    // --- REPLICATED ENTITIES (Simplified for Web Needs) ---
    
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public Guid? SelectionToken { get; set; } // The key field we need
        public Guid? RegistrationGroupId { get; set; } // Aynı kayıt ekranında kaydedilen müşterileri gruplamak için
        public int? StayDays { get; set; } // Kaç gün kalacakları bilgisi
    }

    public class Room
    {
        [Key]
        public int Id { get; set; }
        public string? RoomNumber { get; set; }
        public decimal Price { get; set; }
        public int Status { get; set; } // Enum int value (0=Available, 1=Occupied)
        public int Floor { get; set; }
        public int Type { get; set; } // RoomType enum (0=Single, 1=Double, 2=Triple, 3=Quadruple, 4=Suite)
        public string? Description { get; set; }
    }

    public class Reservation
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int RoomId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Status { get; set; }
        public decimal TotalPrice { get; set; }
        public bool IsOnlineSelection { get; set; } // Web'den seçilen rezervasyonlar için
    }
}
