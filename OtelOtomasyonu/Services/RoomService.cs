using System;
using System.Collections.Generic;
using System.Linq;
using OtelOtomasyonu.Data;
using OtelOtomasyonu.Data.Entities;

namespace OtelOtomasyonu.Services
{
    public class RoomService
    {
        public List<Room> GetAllRooms()
        {
            using (var context = new HotelContext())
            {
                return context.Rooms.ToList();
            }
        }

        public void AddRoom(string roomNumber, RoomType type, decimal price)
        {
            using (var context = new HotelContext())
            {
                if (context.Rooms.Any(r => r.RoomNumber == roomNumber))
                {
                    throw new Exception("Bu oda numarası zaten mevcut.");
                }

                var newRoom = new Room
                {
                    RoomNumber = roomNumber,
                    Type = type,
                    Price = price,
                    Status = RoomStatus.Available // Default status
                };

                context.Rooms.Add(newRoom);
                context.SaveChanges();
            }
        }

        public void UpdateRoomStatus(int roomId, RoomStatus status)
        {
            using (var context = new HotelContext())
            {
                var room = context.Rooms.FirstOrDefault(r => r.Id == roomId);
                if (room != null)
                {
                    room.Status = status;
                    context.SaveChanges();
                }
            }
        }

        public void DeleteRoom(int roomId)
        {
            using (var context = new HotelContext())
            {
                var room = context.Rooms.FirstOrDefault(r => r.Id == roomId);
                if (room != null)
                {
                    // Check for active reservations?
                    if (context.Reservations.Any(res => res.RoomId == roomId && res.Status == ReservationStatus.Confirmed))
                    {
                        throw new Exception("Bu odada aktif bir rezervasyon var, silinemez.");
                    }

                    context.Rooms.Remove(room);
                    context.SaveChanges();
                }
            }
        }
        public OccupancyStats GetOccupancyStats()
        {
            using (var context = new HotelContext())
            {
                // Filter out Floor 0 (Service/Ground floor) as requested by user
                var guestRooms = context.Rooms.Where(r => r.Floor > 0).ToList();
                
                // Aktif ve gelecekteki rezervasyonları kontrol et (bugün ve gelecek için)
                var today = DateTime.Today;
                var activeReservations = context.Reservations
                    .Where(r => r.Status != ReservationStatus.Cancelled && 
                               r.Status != ReservationStatus.Completed &&
                               r.EndDate >= today) // Bugün veya gelecekte biten rezervasyonlar
                    .ToList();
                
                // Her oda için rezervasyon var mı kontrol et
                var occupiedRoomIds = activeReservations.Select(r => r.RoomId).Distinct().ToList();
                
                var stats = new OccupancyStats
                {
                    TotalRooms = guestRooms.Count,
                    OccupiedRooms = guestRooms.Count(r => occupiedRoomIds.Contains(r.Id)),
                    FloorStats = new List<FloorOccupancy>(),
                    TypeStats = new List<TypeOccupancy>()
                };

                if (stats.TotalRooms > 0)
                    stats.OccupancyRate = (double)stats.OccupiedRooms / stats.TotalRooms * 100;

                // Group by Floor
                var floors = guestRooms.GroupBy(r => r.Floor).OrderBy(g => g.Key);
                foreach (var grp in floors)
                {
                    int total = grp.Count();
                    int occupied = grp.Count(r => occupiedRoomIds.Contains(r.Id));
                    stats.FloorStats.Add(new FloorOccupancy 
                    { 
                        FloorNumber = grp.Key, 
                        Total = total, 
                        Occupied = occupied,
                        Rate = total > 0 ? (double)occupied / total * 100 : 0
                    });
                }

                // Group by Type
                var types = guestRooms.GroupBy(r => r.Type);
                foreach (var grp in types)
                {
                     int total = grp.Count();
                    int occupied = grp.Count(r => occupiedRoomIds.Contains(r.Id));
                    stats.TypeStats.Add(new TypeOccupancy
                    {
                        Type = grp.Key,
                        Total = total,
                        Occupied = occupied,
                        Rate = total > 0 ? (double)occupied / total * 100 : 0
                    });
                }

                return stats;
            }
        }
    }

    public class OccupancyStats
    {
        public int TotalRooms { get; set; }
        public int OccupiedRooms { get; set; }
        public double OccupancyRate { get; set; }
        public List<FloorOccupancy> FloorStats { get; set; }
        public List<TypeOccupancy> TypeStats { get; set; }
    }

    public class FloorOccupancy
    {
        public int FloorNumber { get; set; }
        public int Total { get; set; }
        public int Occupied { get; set; }
        public double Rate { get; set; }
    }

    public class TypeOccupancy
    {
        public RoomType Type { get; set; }
        public int Total { get; set; }
        public int Occupied { get; set; }
        public double Rate { get; set; }
    }
}
