using System.Data.Entity;
using OtelOtomasyonu.Data.Entities;

namespace OtelOtomasyonu.Data
{
    public class HotelContext : DbContext
    {
        public HotelContext() : base("name=HotelContext")
        {
            // Database initialization strategy
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<HotelContext>());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<GuestDetail> GuestDetails { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<SystemLog> SystemLogs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Configure optional relationship
            modelBuilder.Entity<Reservation>()
                .HasOptional(r => r.GuestDetail)
                .WithRequired(g => g.Reservation);
        }
    }
}
