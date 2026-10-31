<!-- Backend -->
![.NET](https://img.shields.io/badge/.NET-9.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-Web_API-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Entity Framework Core](https://img.shields.io/badge/EF_Core-9.0-6DB33F?style=for-the-badge)
![JWT](https://img.shields.io/badge/JWT-Authentication-orange?style=for-the-badge&logo=jsonwebtokens&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL_Server-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white)

<!-- Frontend -->
![Vue.js](https://img.shields.io/badge/Vue.js-4FC08D?style=for-the-badge&logo=vuedotjs&logoColor=white)
![Vite](https://img.shields.io/badge/Vite-646CFF?style=for-the-badge&logo=vite&logoColor=white)
![Pinia](https://img.shields.io/badge/Pinia-FFD859?style=for-the-badge&logo=pinia&logoColor=black)
![Vue Router](https://img.shields.io/badge/Vue_Router-4FC08D?style=for-the-badge&logo=vuedotjs&logoColor=white)
![Tailwind CSS](https://img.shields.io/badge/Tailwind_CSS-06B6D4?style=for-the-badge&logo=tailwindcss&logoColor=white)
![Axios](https://img.shields.io/badge/Axios-5A29E4?style=for-the-badge&logo=axios&logoColor=white)

<!-- Architecture -->
![Clean Architecture](https://img.shields.io/badge/Clean_Architecture-000000?style=for-the-badge)
![Repository Pattern](https://img.shields.io/badge/Repository_Pattern-4B5563?style=for-the-badge)
![Unit of Work](https://img.shields.io/badge/Unit_of_Work-6366F1?style=for-the-badge)
![AutoMapper](https://img.shields.io/badge/AutoMapper-DD0031?style=for-the-badge)

<!-- Tools -->
![Visual Studio 2022](https://img.shields.io/badge/Visual_Studio_2022-5C2D91?style=for-the-badge&logo=visualstudio&logoColor=white)
![VS Code](https://img.shields.io/badge/VS_Code-007ACC?style=for-the-badge&logo=visualstudiocode&logoColor=white)
![Git](https://img.shields.io/badge/Git-F05032?style=for-the-badge&logo=git&logoColor=white)
![GitHub](https://img.shields.io/badge/GitHub-181717?style=for-the-badge&logo=github&logoColor=white)

<!-- License -->
![License](https://img.shields.io/badge/License-MIT-success?style=for-the-badge)


# BirleşikERP

BirleşikERP, işletmelerin proje, ekip, müşteri ve görev süreçlerini tek bir platform üzerinden yönetebilmesini sağlayan, modern .NET mimarisi ile geliştirilmiş katmanlı bir ERP (Enterprise Resource Planning) uygulamasıdır.

Proje; ölçeklenebilir, sürdürülebilir ve temiz kod prensipleri gözetilerek geliştirilmiş olup, JWT tabanlı kimlik doğrulama, rol bazlı yetkilendirme ve merkezi hata yönetimi gibi modern backend yaklaşımlarını içermektedir.

Projeyi (geliştirme aşamasında) test edin -> https://erp.bilgiza.com/

---

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
