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

        public DateTime? LastLoginDate { get; set; }

        [StringLength(255)]
        public string ProfilePicturePath { get; set; }
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

    public enum PaymentType
    {
        Cash,
        CreditCard,
        BankTransfer,
        Online
    }

    public enum PaymentStatus
    {
        Pending,
        Completed,
        Failed,
        Refunded
    }

    public class Payment
    {
        [Key]
        public int Id { get; set; }

        public int ReservationId { get; set; }
        [ForeignKey("ReservationId")]
        public virtual Reservation Reservation { get; set; }

        public decimal Amount { get; set; }

        public PaymentType PaymentType { get; set; }

        public PaymentStatus Status { get; set; }

        public DateTime PaymentDate { get; set; }

        [StringLength(500)]
        public string Notes { get; set; }

        [StringLength(100)]
        public string TransactionId { get; set; }
    }

    public enum LogLevel
    {
        Info,
        Warning,
        Error,
        Critical
    }

    public class SystemLog
    {
        [Key]
        public int Id { get; set; }

        public DateTime LogDate { get; set; }

        public LogLevel Level { get; set; }

        [Required]
        [StringLength(100)]
        public string Action { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [StringLength(50)]
        public string IpAddress { get; set; }
    }
}
