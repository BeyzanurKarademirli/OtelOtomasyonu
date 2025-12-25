using System;
using OtelOtomasyonu.Data.Entities;

namespace OtelOtomasyonu.Services
{
    public class AuthorizationService
    {
        /// <summary>
        /// Kullanıcının personel bilgilerine erişip erişemeyeceğini kontrol eder
        /// </summary>
        public static bool CanViewStaffInfo(User user)
        {
            if (user == null) return false;
            
            // Admin her şeye erişebilir
            if (user.Role == UserRole.Admin) return true;
            
            // Genel Müdür her şeye erişebilir
            if (user.Role == UserRole.Staff && user.JobTitle == "Genel Müdür") return true;
            
            // İdari taraf (BackOffice) personel bilgilerini görebilir
            if (user.Role == UserRole.Staff && user.Department == Department.BackOffice) return true;
            
            // Diğer personeller personel bilgilerine erişemez
            return false;
        }

        /// <summary>
        /// Kullanıcının gelir oranına erişip erişemeyeceğini kontrol eder
        /// </summary>
        public static bool CanViewRevenue(User user)
        {
            if (user == null) return false;
            
            // Admin her şeye erişebilir
            if (user.Role == UserRole.Admin) return true;
            
            // Genel Müdür her şeye erişebilir
            if (user.Role == UserRole.Staff && user.JobTitle == "Genel Müdür") return true;
            
            // İdari taraf (BackOffice) gelir/gideri görebilir
            if (user.Role == UserRole.Staff && user.Department == Department.BackOffice) return true;
            
            // Muhasebe gelir/gideri görebilir (JobTitle veya Department kontrolü)
            if (user.Role == UserRole.Staff && (user.JobTitle == "Muhasebe" || user.Department == Department.BackOffice)) return true;
            
            // Diğer personeller gelir oranına erişemez
            return false;
        }

        /// <summary>
        /// Kullanıcının personel ekleme/düzenleme yapıp yapamayacağını kontrol eder
        /// </summary>
        public static bool CanManageStaff(User user)
        {
            if (user == null) return false;
            
            // Sadece Admin ve Genel Müdür personel yönetebilir
            if (user.Role == UserRole.Admin) return true;
            if (user.Role == UserRole.Staff && user.JobTitle == "Genel Müdür") return true;
            
            return false;
        }

        /// <summary>
        /// Kullanıcının tam yetkili olup olmadığını kontrol eder (Admin veya Genel Müdür)
        /// </summary>
        public static bool IsFullAccess(User user)
        {
            if (user == null) return false;
            
            return user.Role == UserRole.Admin || 
                   (user.Role == UserRole.Staff && user.JobTitle == "Genel Müdür");
        }
    }
}

