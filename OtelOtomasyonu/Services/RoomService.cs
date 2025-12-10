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
    }
}
