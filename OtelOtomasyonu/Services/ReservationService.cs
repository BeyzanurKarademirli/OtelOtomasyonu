using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using OtelOtomasyonu.Data;
using OtelOtomasyonu.Data.Entities;

namespace OtelOtomasyonu.Services
{
    public class ReservationService
    {
        public List<Room> GetAvailableRooms(DateTime startDate, DateTime endDate)
        {
            if (endDate <= startDate)
            {
                throw new ArgumentException("Çıkış tarihi giriş tarihinden sonra olmalıdır.");
            }

            using (var context = new HotelContext())
            {
                var allRooms = context.Rooms.ToList();
                
                // Find reserved room IDs in the given range
                var reservedRoomIds = context.Reservations
                    .Where(r => r.Status != ReservationStatus.Cancelled &&
                                r.Status != ReservationStatus.Completed &&
                                ((startDate >= r.StartDate && startDate < r.EndDate) ||
                                 (endDate > r.StartDate && endDate <= r.EndDate) ||
                                 (startDate <= r.StartDate && endDate >= r.EndDate)))
                    .Select(r => r.RoomId)
                    .ToList();

                // Return rooms that are NOT in the reserved list
                return allRooms.Where(r => !reservedRoomIds.Contains(r.Id)).ToList();
            }
        }

        public Reservation CreateReservation(int customerId, int roomId, DateTime startDate, DateTime endDate, GuestDetail guestDetail = null, decimal? customPrice = null)
        {
            if (endDate <= startDate)
            {
                throw new ArgumentException("Çıkış tarihi giriş tarihinden sonra olmalıdır.");
            }

            using (var context = new HotelContext())
            {
                var room = context.Rooms.FirstOrDefault(r => r.Id == roomId);
                if (room == null)
                {
                    throw new InvalidOperationException("Oda bulunamadı.");
                }

                bool overlaps = context.Reservations.Any(r =>
                    r.RoomId == roomId &&
                    r.Status != ReservationStatus.Cancelled &&
                    r.Status != ReservationStatus.Completed &&
                    ((startDate >= r.StartDate && startDate < r.EndDate) ||
                     (endDate > r.StartDate && endDate <= r.EndDate) ||
                     (startDate <= r.StartDate && endDate >= r.EndDate)));

                if (overlaps)
                {
                    throw new InvalidOperationException("Seçilen tarih aralığında oda dolu.");
                }

                var totalDays = (endDate - startDate).TotalDays;
                if (totalDays <= 0)
                {
                    totalDays = 1;
                }

                var reservation = new Reservation
                {
                    CustomerId = customerId,
                    RoomId = roomId,
                    StartDate = startDate,
                    EndDate = endDate,
                    Status = ReservationStatus.Pending,
                    TotalPrice = customPrice ?? room.Price * (decimal)totalDays
                };

                if (guestDetail != null)
                {
                    reservation.GuestDetail = guestDetail;
                }

                context.Reservations.Add(reservation);
                context.SaveChanges();

                return reservation;
            }
        }

        public void UpdateTemporaryExitStatus(int reservationId, bool isTemporaryExit)
        {
            using (var context = new HotelContext())
            {
                var reservation = context.Reservations.Include(r => r.GuestDetail).FirstOrDefault(r => r.Id == reservationId);
                if (reservation == null)
                {
                    throw new InvalidOperationException("Rezervasyon bulunamadı.");
                }

                if (reservation.GuestDetail == null)
                {
                    reservation.GuestDetail = new GuestDetail { ReservationId = reservation.Id };
                }

                reservation.GuestDetail.IsTemporaryExit = isTemporaryExit;
                context.SaveChanges();
            }
        }

        public void CancelReservation(int reservationId, decimal penaltyRate)
        {
            using (var context = new HotelContext())
            {
                var reservation = context.Reservations.FirstOrDefault(r => r.Id == reservationId);
                if (reservation == null)
                {
                    throw new InvalidOperationException("Rezervasyon bulunamadı.");
                }

                reservation.Status = ReservationStatus.Cancelled;

                if (penaltyRate > 0 && penaltyRate <= 1)
                {
                    var penaltyAmount = reservation.TotalPrice * penaltyRate;
                    reservation.TotalPrice -= penaltyAmount;
                }

                context.SaveChanges();
            }
        }

        public IEnumerable<Reservation> GetUpcomingReservations(int maxCount = 20)
        {
            using (var context = new HotelContext())
            {
                var today = DateTime.Today;

                return context.Reservations
                    .Include(r => r.Room)
                    .Include(r => r.Customer)
                    .Where(r => r.StartDate >= today && r.Status != ReservationStatus.Cancelled)
                    .OrderBy(r => r.StartDate)
                    .Take(maxCount)
                    .ToList();
            }
        }

        public DashboardSnapshot GetDashboardSnapshot(DateTime? forDate = null)
        {
            var targetDate = forDate ?? DateTime.Today;

            using (var context = new HotelContext())
            {
                var rooms = context.Rooms.ToList();
                var reservations = context.Reservations
                    .Where(r => DbFunctions.TruncateTime(r.StartDate) <= targetDate && DbFunctions.TruncateTime(r.EndDate) >= targetDate)
                    .ToList();

                var totalRooms = rooms.Count;
                var occupiedRooms = reservations.Count(r => r.Status == ReservationStatus.Confirmed || r.Status == ReservationStatus.Completed);
                var occupancyRate = totalRooms == 0 ? 0 : (decimal)occupiedRooms / totalRooms;

                var dailyRevenue = context.Reservations
                    .Where(r => DbFunctions.TruncateTime(r.StartDate) == targetDate && r.Status != ReservationStatus.Cancelled)
                    .Sum(r => (decimal?)r.TotalPrice) ?? 0;

                return new DashboardSnapshot
                {
                    Date = targetDate,
                    TotalRooms = totalRooms,
                    OccupiedRooms = occupiedRooms,
                    OccupancyRate = occupancyRate,
                    DailyRevenue = dailyRevenue,
                    PendingReservations = reservations.Count(r => r.Status == ReservationStatus.Pending)
                };
            }
        }
    }

    public class DashboardSnapshot
    {
        public DateTime Date { get; set; }
        public int TotalRooms { get; set; }
        public int OccupiedRooms { get; set; }
        public decimal OccupancyRate { get; set; }
        public decimal DailyRevenue { get; set; }
        public int PendingReservations { get; set; }
    }
}

