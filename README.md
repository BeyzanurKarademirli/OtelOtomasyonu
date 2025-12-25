# Ada Lovelady's Hotel - Otel Otomasyon Sistemi

Modern ve kapsamlı bir otel yönetim sistemi. Hem masaüstü (WinForms) hem de web tabanlı (ASP.NET Core MVC) uygulamalar içeren hibrit bir çözümdür.

## 🏨 Proje Hakkında

Ada Lovelady's Hotel Otomasyon Sistemi, otel yönetimi için geliştirilmiş profesyonel bir yazılımdır. Sistem, müşteri kayıtları, oda yönetimi, rezervasyon takibi, ödeme işlemleri, personel yönetimi ve finansal raporlama gibi tüm otel operasyonlarını tek bir platformda toplar.

## ✨ Özellikler

### 🖥️ Masaüstü Uygulama (WinForms)

#### Yönetici Paneli
- **Oda Yönetimi**: Oda bilgileri, durum takibi, kat planı görüntüleme
- **Müşteri Kayıtları**: Çoklu kişi kayıt sistemi (1-4 kişi)
- **Rezervasyon Yönetimi**: Check-in/Check-out işlemleri
- **Personel Yönetimi**: Personel ekleme, düzenleme, yetkilendirme
- **Finansal Raporlama**: Gelir-gider takibi, doluluk oranları
- **Sertifika Yönetimi**: Personel sertifikaları takibi

#### Personel Paneli
- **Yetki Bazlı Erişim**: Departman ve pozisyona göre kısıtlı erişim
- **Müşteri Bilgileri**: Müşteri görüntüleme ve düzenleme
- **Check-in/Check-out**: Müşteri giriş-çıkış işlemleri
- **Kat Planı**: Oda durumlarını görsel olarak görüntüleme
- **Profil Yönetimi**: Personel kendi profil bilgilerini görüntüleme

### 🌐 Web Uygulaması (ASP.NET Core MVC)

#### Müşteri Özellikleri
- **Online Oda Seçimi**: E-posta ile gönderilen token ile oda seçimi
- **Çoklu Kişi Rezervasyonu**: Grup halinde oda seçimi
- **Ödeme Simülasyonu**: Güvenli ödeme işlemi
- **E-posta Bildirimleri**: 
  - Oda seçim linki
  - Ödeme başarı bildirimi
  - Rezervasyon detayları
  - Yemek saatleri ve temizlik bilgileri
  - İletişim bilgileri

## 🛠️ Teknolojiler

### Backend
- **.NET Framework 4.8** (Masaüstü uygulama)
- **.NET 8.0** (Web uygulaması)
- **Entity Framework Core** (ORM)
- **SQL Server** (Veritabanı)

### Frontend
- **DevExpress WinForms Controls** (Masaüstü UI)
- **ASP.NET Core MVC** (Web UI)
- **Razor Pages** (Web görünümleri)
- **JavaScript/jQuery** (İstemci tarafı işlemler)

### Diğer
- **SMTP** (E-posta gönderimi)
- **LINQ** (Veri sorgulama)

## 📋 Gereksinimler

### Sistem Gereksinimleri
- Windows 10/11 veya Windows Server 2016+
- .NET Framework 4.8
- .NET 8.0 Runtime
- SQL Server 2019 veya üzeri
- Visual Studio 2022 (geliştirme için)

### Geliştirme Gereksinimleri
- Visual Studio 2022 Community veya üzeri
- DevExpress WinForms Components (lisanslı)
- SQL Server Management Studio (SSMS)

## 🚀 Kurulum

### 1. Projeyi İndirin
git clone https://github.com/kullaniciadi/otel-otomasyonu.git
cd otel-otomasyonu### 2. Veritabanı Kurulumu
1. SQL Server Management Studio'yu açın
2. Yeni bir veritabanı oluşturun: `OtelOtomasyonuDb`
3. `appsettings.json` dosyasında bağlantı string'ini güncelleyin:
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=OtelOtomasyonuDb;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}### 3. Masaüstü Uygulamasını Çalıştırma
1. Visual Studio 2022'de `OtelOtomasyonu.sln` dosyasını açın
2. `OtelOtomasyonu` projesini başlangıç projesi olarak ayarlayın
3. F5 ile çalıştırın
4. İlk açılışta veritabanı otomatik olarak oluşturulacaktır

### 4. Web Uygulamasını Çalıştırma
1. `OtelOtomasyonuWeb` projesini başlangıç projesi olarak ayarlayın
2. F5 ile çalıştırın
3. Tarayıcıda `https://localhost:5001` adresine gidin

## 👥 Kullanıcı Rolleri

### Yönetici (Admin)
- Tüm özelliklere tam erişim
- Personel ekleme/düzenleme
- Finansal raporlara erişim
- Sistem ayarları

### Personel

#### İdari Yönetim (BackOffice)
- Yöneticiye eşit erişim
- Personel bilgilerini görüntüleme
- Finansal raporlara erişim

#### Ön Büro (FrontOffice)
- Müşteri kayıtları
- Check-in/Check-out
- Kat planı görüntüleme
- Müşteri bilgileri

#### Muhasebe
- Gelir-gider raporları
- Finansal analizler

## 📧 E-posta Yapılandırması

Web uygulamasında e-posta gönderimi için `appsettings.json` dosyasını yapılandırın:

{
  "EmailSettings": {
    "SmtpServer": "smtp.gmail.com",
    "SmtpPort": 587,
    "SenderEmail": "your-email@gmail.com",
    "SenderPassword": "your-app-password",
    "EnableSsl": true
  }
}**Not:** Gmail kullanıyorsanız, "Uygulama Şifresi" oluşturmanız gerekebilir.

## 🗂️ Proje Yapısı
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=OtelOtomasyonuDb;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}ekilde oluşturulur
- Rol tabanlı yetkilendirme sistemi
- Departman bazlı erişim kontrolü

## 📝 Önemli Notlar

### Veritabanı
- İlk çalıştırmada veritabanı otomatik oluşturulur
- Örnek veriler için `HotelDbInitializer` sınıfını kullanabilirsiniz

### E-posta Gönderimi
- E-posta gönderimi için SMTP ayarlarının doğru yapılandırılması gerekir
- Gmail kullanıyorsanız 2FA aktif olmalı ve uygulama şifresi kullanılmalıdır

### DevExpress Lisansı
- Proje DevExpress kontrolleri kullanmaktadır
- Lisanslı bir DevExpress lisansı gereklidir

## 🐛 Bilinen Sorunlar

- Şifreler hash'lenmemiş durumda (üretim için güvenlik güncellemesi gerekli)
- Chatbot özelliği kaldırılmıştır

## 📞 İletişim

**Ada Lovelady's Hotel**
- 📧 E-posta: adaloveladysho***@gmail.com
- 📱 Telefon: 0551000****
- 📍 Adres: İZMİR, TÜRKİYE

## 📄 Lisans

Bu proje özel bir projedir ve tüm hakları saklıdır.

## 🙏 Teşekkürler

Projeyi kullandığınız için teşekkür ederiz. Sorularınız veya önerileriniz için iletişime geçebilirsiniz.

---

**Not:** Bu proje eğitim ve ticari amaçlarla geliştirilmiştir. Üretim ortamında kullanmadan önce güvenlik ve performans testlerinden geçirilmelidir.
