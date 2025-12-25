using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OtelOtomasyonuWeb.Data;
using System;
using System.Linq;
using System.Collections.Generic;

namespace OtelOtomasyonuWeb.Controllers
{
    public class RoomSelectionController : Controller
    {
        private readonly WebHotelContext _context;

        public RoomSelectionController(WebHotelContext context)
        {
            _context = context;
        }

        public IActionResult Index(string token)
        {
            if (string.IsNullOrEmpty(token) || !Guid.TryParse(token, out Guid dictToken))
            {
                return Content("Geçersiz Link");
            }

            var customer = _context.Users.FirstOrDefault(u => u.SelectionToken == dictToken);
            if (customer == null)
            {
                return Content("Link bulunamadı veya süresi dolmuş.");
            }

            // Eğer odalar yoksa, otomatik oluştur
            EnsureRoomsExist();

            // Grup bilgisini al (aynı RegistrationGroupId'ye sahip müşteriler)
            var groupMembers = new List<User>();
            if (customer.RegistrationGroupId.HasValue)
            {
                groupMembers = _context.Users
                    .Where(u => u.RegistrationGroupId == customer.RegistrationGroupId.Value)
                    .OrderBy(u => u.Email == null ? 1 : 0) // Önce ana müşteri (e-postası olan)
                    .ThenBy(u => u.Id)
                    .ToList();
            }
            else
            {
                // Tek başına kayıt olmuş, sadece kendisi
                groupMembers.Add(customer);
            }

            ViewBag.Token = token;
            ViewBag.CustomerName = $"{customer.Name} {customer.Surname}";
            ViewBag.GroupSize = groupMembers.Count;
            ViewBag.GroupMembers = groupMembers; // User nesnelerini direkt gönder

            // Müsait odaları göster (Status = 0 = Available VEYA kapasitesi dolmamış odalar)
            var availableRooms = new List<Room>();
            var allRooms = _context.Rooms.ToList();
            
            foreach (var room in allRooms)
            {
                if (room.Status == 0) // Available
                {
                    availableRooms.Add(room);
                }
                else if (room.Status == 1) // Occupied ama kapasitesi dolmamış olabilir
                {
                    // Bu odada kaç rezervasyon var?
                    var reservationCount = _context.Reservations
                        .Where(r => r.RoomId == room.Id && 
                            r.Status != 2 && // Cancelled değil
                            r.Status != 3) // Completed değil
                        .Count();
                    
                    int capacity = GetRoomCapacity(room.Type);
                    if (reservationCount < capacity)
                    {
                        // Hala yer var
                        availableRooms.Add(room);
                    }
                }
            }
            
            return View(availableRooms);
        }

        private int GetRoomCapacity(int roomType)
        {
            // RoomType enum: 0=Single, 1=Double, 2=Triple, 3=Quadruple, 4=Suite
            switch (roomType)
            {
                case 0: return 1; // Single
                case 1: return 2; // Double
                case 2: return 3; // Triple
                case 3: return 4; // Quadruple
                case 4: return 4; // Suite
                default: return 1;
            }
        }

        private void EnsureRoomsExist()
        {
            // Eğer hiç oda yoksa veya eksik odalar varsa, tüm odaları oluştur/güncelle
            bool needsUpdate = false;
            
            // Floors 1-10, 10 rooms each (101-110, 201-210, etc.)
            for (int f = 1; f <= 10; f++)
            {
                for (int i = 0; i < 10; i++)
                {
                    string roomNum = $"{f * 100 + (i + 1)}";
                    
                    var existingRoom = _context.Rooms.FirstOrDefault(r => r.RoomNumber == roomNum);
                    
                    // Determine Type and Price based on Index (0-9)
                    int type = 0; // Single
                    decimal price = 0;
                    string desc = "";

                    // 1-4 (Indices 0,1,2,3) -> Single (1 Person) -> 8000 TL
                    if (i < 4)
                    {
                        type = 0; // Single
                        price = 8000;
                        desc = "Tek Kişilik Oda";
                    }
                    // 5-7 (Indices 4,5,6) -> Double (2 Person) -> 12000 TL
                    else if (i < 7)
                    {
                        type = 1; // Double
                        price = 12000;
                        desc = "Çift Kişilik Oda";
                    }
                    // 8 (Index 7) -> Triple (3 Person) -> 15000 TL
                    else if (i == 7)
                    {
                        type = 2; // Triple
                        price = 15000;
                        desc = "Üç Kişilik Oda";
                    }
                    // 9 (Index 8) -> Quadruple (4 Person) -> 18000 TL
                    else if (i == 8)
                    {
                        type = 3; // Quadruple
                        price = 18000;
                        desc = "Dört Kişilik Oda";
                    }
                    // 10 (Index 9) -> Suite (4 Person) -> 25000 TL
                    else
                    {
                        type = 4; // Suite
                        price = 25000;
                        desc = "Suit Oda";
                    }

                    if (existingRoom == null)
                    {
                        // Oda yoksa oluştur
                        var room = new Room
                        {
                            RoomNumber = roomNum,
                            Floor = f,
                            Type = type,
                            Price = price,
                            Status = 0, // Available
                            Description = desc
                        };
                        _context.Rooms.Add(room);
                        needsUpdate = true;
                    }
                    else
                    {
                        // Oda varsa ama bilgileri eksikse güncelle (Status'u değiştirme, sadece eksik alanları doldur)
                        if (existingRoom.Floor == 0 || existingRoom.Price == 0 || string.IsNullOrEmpty(existingRoom.Description))
                        {
                            existingRoom.Floor = f;
                            existingRoom.Type = type;
                            existingRoom.Price = price;
                            existingRoom.Description = desc;
                            // Status'u değiştirme, mevcut durumunu koru
                            needsUpdate = true;
                        }
                    }
                }
            }
            
            if (needsUpdate)
            {
                _context.SaveChanges();
            }
        }

        [HttpPost]
        public IActionResult Select(string token, string roomId, string? memberId = null)
        {
            if (string.IsNullOrEmpty(token) || !Guid.TryParse(token, out Guid dictToken))
                return Json(new { success = false, message = "Geçersiz Link" });

            var customer = _context.Users.FirstOrDefault(u => u.SelectionToken == dictToken);
            if (customer == null)
                 return Json(new { success = false, message = "Müşteri bulunamadı" });

            var room = _context.Rooms.FirstOrDefault(r => r.RoomNumber == roomId);
            if (room == null)
            {
                return Json(new { success = false, message = "Oda bulunamadı." });
            }

            // Hangi grup üyesi için oda seçiliyor?
            int targetCustomerId = customer.Id;
            if (!string.IsNullOrEmpty(memberId) && int.TryParse(memberId, out int parsedMemberId))
            {
                // Grup üyesi için oda seçiliyor
                var groupMember = _context.Users.FirstOrDefault(u => u.Id == parsedMemberId && 
                    u.RegistrationGroupId == customer.RegistrationGroupId);
                if (groupMember != null)
                {
                    targetCustomerId = groupMember.Id;
                }
            }

            // Bu müşteri için zaten oda seçilmiş mi kontrol et
            var existingReservation = _context.Reservations
                .FirstOrDefault(r => r.CustomerId == targetCustomerId && 
                    r.Status != 2 && // Cancelled değil
                    r.Status != 3); // Completed değil
            
            if (existingReservation != null)
            {
                return Json(new { success = false, message = "Bu kişi için zaten bir oda seçilmiş." });
            }

            // Oda kapasitesini hesapla (Type'dan)
            int roomCapacity = GetRoomCapacity(room.Type);

            // Bu odada kaç rezervasyon var? (Aktif rezervasyonlar)
            var existingReservationsInRoom = _context.Reservations
                .Where(r => r.RoomId == room.Id && 
                    r.Status != 2 && // Cancelled değil
                    r.Status != 3) // Completed değil
                .ToList();

            // Bu odada aynı gruptan kaç kişi var?
            int sameGroupCountInRoom = 0;
            bool hasSameGroupMember = false;
            if (customer.RegistrationGroupId.HasValue)
            {
                // Bu odadaki rezervasyonları kontrol et
                foreach (var res in existingReservationsInRoom)
                {
                    var resCustomer = _context.Users.FirstOrDefault(u => u.Id == res.CustomerId);
                    if (resCustomer != null && resCustomer.RegistrationGroupId == customer.RegistrationGroupId)
                    {
                        sameGroupCountInRoom++;
                        hasSameGroupMember = true;
                    }
                }
            }

            // Oda kapasitesi dolu mu kontrol et
            if (existingReservationsInRoom.Count >= roomCapacity)
            {
                // Oda kapasitesi dolu
                // Aynı gruptan kişiler varsa, onlar doldurmuş demektir
                if (hasSameGroupMember)
                {
                    room.Status = 1; // Occupied
                    _context.SaveChanges();
                    return Json(new { success = false, message = "Bu oda kapasitesi dolmuş. Başka bir oda seçiniz." });
                }
                else
                {
                    // Farklı gruptan kişiler doldurmuş
                    room.Status = 1; // Occupied
                    _context.SaveChanges();
                    return Json(new { success = false, message = "Bu oda zaten seçilmiş." });
                }
            }

            // Oda kapasitesi yeterli (existingReservationsInRoom.Count < roomCapacity)
            // Aynı gruptan kişiler aynı odayı seçebilir (kapasite yeterliyse)
            // Farklı gruptan kişiler de seçebilir (kapasite yeterliyse)
            // Her iki durumda da izin ver

            // Kaç gün kalacakları bilgisini al
            int stayDays = customer.StayDays ?? 1;

            // Oda müsait, rezervasyon oluştur
            var reservation = new Reservation
            {
                CustomerId = targetCustomerId,
                RoomId = room.Id,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(stayDays), // StayDays'e göre
                Status = 1, // 1 = Confirmed
                TotalPrice = room.Price * stayDays, // Günlük fiyat × gün sayısı
                IsOnlineSelection = true // Web'den seçildiği için true
            };
            _context.Reservations.Add(reservation);

            // Oda seçildi, Status'u güncelle (kapasite dolduysa Occupied, değilse Available kalabilir ama rezervasyon var)
            // Ancak doluluk oranı için rezervasyonları kontrol etmek daha doğru olacak
            // Şimdilik oda seçildiğinde Status'u güncelle
            if (existingReservationsInRoom.Count + 1 >= roomCapacity)
            {
                room.Status = 1; // Occupied - Kapasite dolu
            }
            else
            {
                // Kapasite dolmamış ama rezervasyon var, oda artık müsait değil
                room.Status = 1; // Occupied - Rezervasyon var
            }
            
            _context.SaveChanges();
            
            var targetCustomer = _context.Users.FirstOrDefault(u => u.Id == targetCustomerId);
            var customerName = targetCustomer != null ? $"{targetCustomer.Name ?? ""} {targetCustomer.Surname ?? ""}".Trim() : "Müşteri";
            if (string.IsNullOrEmpty(customerName))
            {
                customerName = "Müşteri";
            }
            
            return Json(new { success = true, message = $"{customerName} için {room.RoomNumber} numaralı oda seçildi!" });
        }

        [HttpPost]
        public IActionResult CompleteSelection(string token)
        {
            if (string.IsNullOrEmpty(token) || !Guid.TryParse(token, out Guid dictToken))
                return Json(new { success = false, message = "Geçersiz Link" });

            var customer = _context.Users.FirstOrDefault(u => u.SelectionToken == dictToken);
            if (customer == null)
                 return Json(new { success = false, message = "Müşteri bulunamadı" });

            // Grup üyelerini kontrol et - hepsi için oda seçilmiş mi?
            var groupMembers = new List<User>();
            if (customer.RegistrationGroupId.HasValue)
            {
                groupMembers = _context.Users
                    .Where(u => u.RegistrationGroupId == customer.RegistrationGroupId.Value)
                    .ToList();
            }
            else
            {
                groupMembers.Add(customer);
            }

            // Her grup üyesi için rezervasyon var mı kontrol et
            var reservations = new List<Reservation>();
            foreach (var member in groupMembers)
            {
                var reservation = _context.Reservations
                    .FirstOrDefault(r => r.CustomerId == member.Id && 
                        r.Status != 2 && // Cancelled değil
                        r.Status != 3); // Completed değil
                
                if (reservation == null)
                {
                    return Json(new { success = false, message = $"Tüm grup üyeleri için oda seçilmedi. {member.Name} {member.Surname} için henüz oda seçilmedi." });
                }
                reservations.Add(reservation);
            }

            // Tüm grup üyeleri için oda seçilmiş, ödeme sayfasına yönlendir
            // Token'ı şimdilik temizleme, ödeme tamamlandıktan sonra temizlenecek
            return Json(new { success = true, redirectUrl = $"/RoomSelection/Payment?token={token}" });
        }

        public IActionResult Payment(string token)
        {
            if (string.IsNullOrEmpty(token) || !Guid.TryParse(token, out Guid dictToken))
            {
                return Content("Geçersiz Link");
            }

            var customer = _context.Users.FirstOrDefault(u => u.SelectionToken == dictToken);
            if (customer == null)
            {
                return Content("Link bulunamadı veya süresi dolmuş.");
            }

            // Grup üyelerini ve rezervasyonlarını al
            var groupMembers = new List<User>();
            if (customer.RegistrationGroupId.HasValue)
            {
                groupMembers = _context.Users
                    .Where(u => u.RegistrationGroupId == customer.RegistrationGroupId.Value)
                    .ToList();
            }
            else
            {
                groupMembers.Add(customer);
            }

            var reservations = new List<Reservation>();
            var rooms = new List<Room>();
            decimal totalAmount = 0;
            int stayDays = customer.StayDays ?? 1;

            foreach (var member in groupMembers)
            {
                var reservation = _context.Reservations
                    .FirstOrDefault(r => r.CustomerId == member.Id && 
                        r.Status != 2 && // Cancelled değil
                        r.Status != 3); // Completed değil
                
                if (reservation != null)
                {
                    var room = _context.Rooms.FirstOrDefault(r => r.Id == reservation.RoomId);
                    if (room != null)
                    {
                        reservations.Add(reservation);
                        rooms.Add(room);
                        // Toplam tutar = oda günlük fiyatı × kalacağı gün sayısı
                        totalAmount += room.Price * stayDays;
                    }
                }
            }

            ViewBag.Token = token;
            ViewBag.CustomerName = $"{customer.Name} {customer.Surname}";
            ViewBag.TotalAmount = totalAmount;
            ViewBag.StayDays = stayDays;
            ViewBag.Reservations = reservations;
            ViewBag.Rooms = rooms;

            return View();
        }

        [HttpPost]
        public IActionResult ProcessPayment(string token)
        {
            if (string.IsNullOrEmpty(token) || !Guid.TryParse(token, out Guid dictToken))
                return Json(new { success = false, message = "Geçersiz Link" });

            var customer = _context.Users.FirstOrDefault(u => u.SelectionToken == dictToken);
            if (customer == null)
                 return Json(new { success = false, message = "Müşteri bulunamadı" });

            // Ödeme simülasyonu - her zaman başarılı
            // Gerçek ödeme entegrasyonu burada yapılacak

            // Rezervasyonları güncelle (StayDays'e göre TotalPrice ve EndDate)
            var groupMembers = new List<User>();
            if (customer.RegistrationGroupId.HasValue)
            {
                groupMembers = _context.Users
                    .Where(u => u.RegistrationGroupId == customer.RegistrationGroupId.Value)
                    .ToList();
            }
            else
            {
                groupMembers.Add(customer);
            }

            int stayDays = customer.StayDays ?? 1;
            var reservations = new List<Reservation>();

            foreach (var member in groupMembers)
            {
                var reservation = _context.Reservations
                    .FirstOrDefault(r => r.CustomerId == member.Id && 
                        r.Status != 2 && // Cancelled değil
                        r.Status != 3); // Completed değil
                
                if (reservation != null)
                {
                    var room = _context.Rooms.FirstOrDefault(r => r.Id == reservation.RoomId);
                    if (room != null)
                    {
                        // TotalPrice ve EndDate'i güncelle
                        reservation.TotalPrice = room.Price * stayDays;
                        reservation.EndDate = reservation.StartDate.AddDays(stayDays);
                        reservations.Add(reservation);
                    }
                }
            }

            _context.SaveChanges();

            // Token'ı temizle
            customer.SelectionToken = null;
            _context.SaveChanges();

            // Başarılı ödeme maili gönder
            if (!string.IsNullOrEmpty(customer.Email))
            {
                try
                {
                    var mailService = new OtelOtomasyonuWeb.Services.WebMailService();
                    var emailContent = BuildPaymentSuccessEmail(customer, reservations, stayDays);
                    mailService.SendEmail(customer.Email!, "Ödeme Başarılı - Ada Lovelady's Hotel", emailContent);
                }
                catch (Exception ex)
                {
                    // Mail gönderim hatası önemli değil, log'la
                    System.Diagnostics.Debug.WriteLine($"Mail gönderim hatası: {ex.Message}");
                }
            }

            return Json(new { success = true, message = "Ödeme başarıyla tamamlandı!", redirectUrl = "/RoomSelection/PaymentSuccess" });
        }

        private string BuildPaymentSuccessEmail(User customer, List<Reservation> reservations, int stayDays)
        {
            decimal totalAmount = reservations.Sum(r => r.TotalPrice);
            
            var email = $@"
<html>
<body style='background-color: #000; color: #D4AF37; font-family: Segoe UI, sans-serif; padding: 20px;'>
    <div style='border: 2px solid #D4AF37; padding: 40px; max-width: 600px; margin: auto; border-radius: 10px; background-color: #1a1a1a;'>
        <h2 style='color: #D4AF37;'>Sayın {customer.Name} {customer.Surname},</h2>
        <p style='color: #fff; font-size: 16px;'>Ödemeniz başarıyla tamamlanmıştır!</p>

        <h3 style='color: #D4AF37; border-bottom: 1px solid #D4AF37; padding-bottom: 10px;'>Rezervasyon Detayları:</h3>
        <ul style='color: #fff;'>";
            
            foreach (var res in reservations)
            {
                var room = _context.Rooms.FirstOrDefault(r => r.Id == res.RoomId);
                if (room != null)
                {
                    email += $@"<li style='margin-bottom: 10px;'>Oda {room.RoomNumber} - {res.TotalPrice:N2} TL</li>";
                }
            }
            
            email += $@"
        </ul>
        <p style='color: #fff; font-size: 18px;'><strong style='color: #D4AF37;'>Toplam Tutar: {totalAmount:N2} TL</strong></p>
        <p style='color: #fff;'><strong style='color: #D4AF37;'>Kalış Süresi: {stayDays} Gün</strong></p>

        <h3 style='color: #D4AF37; border-bottom: 1px solid #D4AF37; padding-bottom: 10px; margin-top: 30px;'>Önemli Bilgiler:</h3>
        <ul style='color: #fff; line-height: 2;'>
            <li><strong style='color: #D4AF37;'>Oda Anahtarı:</strong> Anahtarınızı resepsiyondan alabilirsiniz.</li>
            <li><strong style='color: #D4AF37;'>Yemek Saatleri:</strong>
                <ul>
                    <li>Kahvaltı: 07:00 - 10:00</li>
                    <li>Öğle Yemeği: 12:00 - 14:00</li>
                    <li>Akşam Yemeği: 19:00 - 21:00</li>
                </ul>
            </li>
            <li><strong style='color: #D4AF37;'>Oda Temizlik Saatleri:</strong> 10:00 - 14:00</li>
        </ul>

        <h3 style='color: #D4AF37; border-bottom: 1px solid #D4AF37; padding-bottom: 10px; margin-top: 30px;'>İletişim Bilgileri:</h3>
        <ul style='color: #fff; line-height: 2;'>
            <li><strong style='color: #D4AF37;'>E-posta:</strong> adaloveladyshotel@gmail.com</li>
            <li><strong style='color: #D4AF37;'>Telefon:</strong> 05510002179</li>
            <li><strong style='color: #D4AF37;'>Adres:</strong> Ada Lovelady's Hotel<br>
                Alsancak Mahallesi, Atatürk Caddesi (Kordonboyu), No: 142<br>
                35220 Konak / İZMİR TÜRKİYE</li>
        </ul>

        <p style='color: #fff; margin-top: 30px;'>İyi tatiller dileriz!</p>
        <p style='color: #D4AF37; font-size: 18px; font-weight: bold;'>Ada Lovelady's Hotel</p>
    </div>
</body>
</html>";
            return email;
        }

        public IActionResult PaymentSuccess()
        {
            return View();
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
