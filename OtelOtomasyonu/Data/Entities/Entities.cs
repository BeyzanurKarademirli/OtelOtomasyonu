using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OtelOtomasyonu.Data.Entities
{
    public enum UserRole
    {
        Admin,
        Staff,
        Customer
    }

    public class User
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Username { get; set; }
        
        [Required]
        public string Password { get; set; } // In production, hash this!
        
        public UserRole Role { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Surname { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        [StringLength(20)]
        public string LicensePlate { get; set; }
    }

    public enum RoomType
    {
        Single,
        Double,
        Suite
    }

    public enum RoomStatus
    {
        Available,
        Occupied,
        Cleaning,
        Maintenance
    }

    public class Room
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(10)]
        public string RoomNumber { get; set; }
        
        public RoomType Type { get; set; }
        
        public decimal Price { get; set; }
        
        public RoomStatus Status { get; set; }
    }

    public enum ReservationStatus
    {
        Pending,
        Confirmed,
        Cancelled,
        Completed
    }

    public class Reservation
    {
        [Key]
        public int Id { get; set; }
        
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual User Customer { get; set; }
        
        public int RoomId { get; set; }
        [ForeignKey("RoomId")]
        public virtual Room Room { get; set; }
        
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        
        public decimal TotalPrice { get; set; }
        
        public ReservationStatus Status { get; set; }

        public virtual GuestDetail GuestDetail { get; set; }
    }

    public class GuestDetail
    {
        [Key, ForeignKey("Reservation")]
        public int ReservationId { get; set; }
        
        public virtual Reservation Reservation { get; set; }

        [StringLength(20)]
        public string LicensePlate { get; set; }
        
        [StringLength(20)]
        public string SecondContactNumber { get; set; }
        
        public bool BreakfastIncluded { get; set; }
        public bool LunchIncluded { get; set; }
        public bool DinnerIncluded { get; set; }
        
        public bool IsTemporaryExit { get; set; } // Eşyalar otelde ama kendisi yok
    }
}
