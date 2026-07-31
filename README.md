![.NET](https://img.shields.io/badge/.NET-9.0-blueviolet)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-Web_API-blue)
![EF Core](https://img.shields.io/badge/EF_Core-9.0-green)
![JWT](https://img.shields.io/badge/Auth-JWT-orange)
![License](https://img.shields.io/badge/License-MIT-success)


# BirleşikERP

BirleşikERP, işletmelerin proje, ekip, müşteri ve görev süreçlerini tek bir platform üzerinden yönetebilmesini sağlayan, modern .NET mimarisi ile geliştirilmiş katmanlı bir ERP (Enterprise Resource Planning) uygulamasıdır.

Proje; ölçeklenebilir, sürdürülebilir ve temiz kod prensipleri gözetilerek geliştirilmiş olup, JWT tabanlı kimlik doğrulama, rol bazlı yetkilendirme ve merkezi hata yönetimi gibi modern backend yaklaşımlarını içermektedir.

---

## 🎯 Amaç

BirleşikERP'nin amacı;

- Proje yönetimini tek merkezden gerçekleştirmek,
- Departman ve ekip yönetimini kolaylaştırmak,
- Görev süreçlerini takip edebilmek,
- Müşteri bilgilerini merkezi olarak yönetebilmek,
- Güvenli kullanıcı yönetimi ve yetkilendirme sunmak,
- Modüler yapısı sayesinde yeni modüllerin kolayca eklenebilmesini sağlamaktır.

---

## 🏗️ Mimari

Proje, **Katmanlı Mimari (Layered Architecture)** prensibine uygun olarak geliştirilmiştir.

```
Presentation (API)
        │
Application
        │
Domain
        │
Infrastructure
        │
Database (MSSQL)
```

Her katman yalnızca ihtiyaç duyduğu katman ile iletişim kurmaktadır. Böylece bağımlılıklar minimum seviyede tutulmuş ve sürdürülebilir bir yapı oluşturulmuştur.

---

## 🚀 Kullanılan Teknolojiler

- ASP.NET Core Web API
- ASP.NET Core Identity
- Entity Framework Core
- MSSQL
- JWT Authentication & Authorization
- Generic Repository Pattern
- AutoMapper
- FluentValidation
- FluentAPI
- Global Exception Middleware

---

## 🔐 Kimlik Doğrulama ve Yetkilendirme

Projede kullanıcı yönetimi **ASP.NET Core Identity** ile sağlanmaktadır.

Özellikler:

- JWT Authentication
- Role Based Authorization
- Secure Password Hashing
- Refresh Token altyapısına uygun yapı
- Yetki bazlı endpoint koruması

---

## ✅ Doğrulama

Tüm Request modellerinin doğrulanması için **FluentValidation** kullanılmaktadır.

Avantajları:

- Controller içerisinde gereksiz kontrol yazılmaması
- Temiz ve okunabilir kod
- Merkezi doğrulama kuralları

---

## ⚙️ Veritabanı

Veritabanı işlemleri **Entity Framework Core** ile gerçekleştirilmektedir.

Yapıda;

- Code First yaklaşımı
- Fluent API Konfigürasyonları
- Migration desteği
- Navigation Property ilişkileri

kullanılmıştır.

---

## 📦 Repository Yapısı

Projede veri erişim katmanında **Generic Repository Pattern** uygulanmıştır.

Bu sayede;

- Kod tekrarının azaltılması
- Test edilebilirliğin artırılması
- Veri erişim işlemlerinin merkezi hale getirilmesi

amaçlanmıştır.

---

## 🗺️ AutoMapper

DTO ve Entity dönüşümleri AutoMapper ile gerçekleştirilmektedir.

Böylece;

- Gereksiz manuel mapping işlemleri ortadan kaldırılmıştır.
- Daha okunabilir servis katmanı oluşturulmuştur.

---

## 🚨 Global Exception Middleware

Projede oluşabilecek beklenmeyen hatalar merkezi olarak **GlobalExceptionMiddleware** üzerinden yönetilmektedir.

Avantajları:

- Tüm hataların tek noktadan yakalanması
- Standart hata dönüşleri
- Daha temiz Controller yapısı
- Loglama sistemleriyle kolay entegrasyon

---

## 📂 Proje Yapısı

```
BirlesikERP
│
├── API
├── Application
├── Domain
├── Infrastructure
└── Persistence
```

---

## 📌 Geliştirme Yaklaşımı

Projede aşağıdaki prensipler benimsenmiştir.

- Clean Code
- SOLID Principles
- Separation of Concerns
- Dependency Injection
- Layered Architecture
- Repository Pattern

---

## 🚀 Gelecek Planları

Eklenmesi planlanan bazı özellikler:

- Refresh Token
- Serilog ile Loglama
- Caching (Redis)
- Docker Desteği
- Unit Test
- Integration Test
- Swagger Authorization
- CI/CD Pipeline

---

## 👨‍💻 Geliştirici

**Abdullah Bozdağ**

Backend Developer (.NET)

Bu proje, modern .NET backend geliştirme yaklaşımlarını öğrenmek, uygulamak ve gerçek hayattaki ERP senaryolarını modellemek amacıyla geliştirilmektedir.