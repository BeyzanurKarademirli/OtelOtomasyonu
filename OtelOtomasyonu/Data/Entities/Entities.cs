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

    public enum Department
    {
        FrontOffice,        // Ön Büro
        Housekeeping,       // Kat Hizmetleri
        FoodAndBeverage,    // Yiyecek ve İçecek
        BackOffice,         // Yönetim ve İdari
        TechnicalAndSecurity // Teknik Servis ve Güvenlik
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

        // New Personnel Fields
        public Department Department { get; set; }

        [StringLength(100)]
        public string JobTitle { get; set; } // e.g. "Resepsiyonist", "Aşçıbaşı"

        public decimal Salary { get; set; }

        [StringLength(50)]
        public string WorkHours { get; set; } // e.g. "09:00 - 18:00"

        [StringLength(20)]
        public string LicensePlate { get; set; }

        public DateTime? LastLoginDate { get; set; }

        [StringLength(255)]
        public string ProfilePicturePath { get; set; }

        public Guid? SelectionToken { get; set; } // For Remote Room Selection

        public Guid? RegistrationGroupId { get; set; } // Aynı kayıt ekranında kaydedilen müşterileri gruplamak için

        public int? StayDays { get; set; } // Kaç gün kalacakları bilgisi
    }

    public enum RoomType
    {
        Single,
        Double,
        Triple,
        Quadruple,
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
        [StringLength(50)]
        public string RoomNumber { get; set; }
        
        public RoomType Type { get; set; }
        
        public decimal Price { get; set; }
        
        public RoomStatus Status { get; set; }

        public int Floor { get; set; } // 0=Zemin, 1=1.Kat...
        public string Description { get; set; } // Force DB Reset
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

        // Remote/Online Selection Fields
        public Guid? SelectionToken { get; set; } // Link identifier
        public DateTime? TokenExpiry { get; set; }
        public bool IsOnlineSelection { get; set; } // Flag to distinguish mail-based reservations
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
    public enum ExpenseCategory
    {
        Material,
        Bill,           // Fatura (Elektrik, Su, İnternet)
        Maintenance,    // Bakım Onarım
        Kitchen,        // Mutfak Masrafı
        Staff,          // Personel (Maaş harici anlık ödemeler vs)
        Other
    }

    public class Expense
    {
        [Key]
        public int Id { get; set; }

        public ExpenseCategory Category { get; set; }

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }

        [StringLength(200)]
        public string Description { get; set; }
    }
}
