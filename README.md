# 📦 Stok & Satış Takip Sistemi (WinForms)

Bu proje, C# ve Windows Forms kullanılarak geliştirilmiş katmanlı mimariye sahip bir **Stok ve Satış Takip Otomasyonudur**.  

Uygulama üzerinden müşteri, ürün ve sipariş yönetimi yapılabilmektedir.

---

## 🚀 Proje Özellikleri

### 👤 Müşteri İşlemleri
- Müşteri ekleme
- Müşteri güncelleme
- Müşteri silme
- Müşteri listeleme

### 📦 Ürün İşlemleri
- Ürün ekleme
- Ürün güncelleme
- Ürün silme
- Stok takibi
- Ürün listeleme

### 🛒 Satış İşlemleri
- Sepete ürün ekleme
- Aynı ürün sepette varsa miktar artırma
- Stok kontrolü
- Sipariş oluşturma
- Toplam tutar hesaplama
- Satış tamamlandığında stok düşürme

---

## 🏗️ Kullanılan Mimari

Proje **Katmanlı Mimari (Layered Architecture)** kullanılarak geliştirilmiştir:

- **EntityLayer** → Veri modelleri
- **DataAccessLayer** → Veritabanı işlemleri
- **LogicLayer** → İş kuralları
- **UI (WinForms)** → Kullanıcı arayüzü

Bu yapı sayesinde:
- Kod okunabilirliği artmıştır
- Sürdürülebilirlik sağlanmıştır
- Katmanlar arası bağımlılık azaltılmıştır

---

## 🧠 Kullanılan Teknolojiler

- C#
- .NET Framework
- Windows Forms
- SQL

---

## 📌 Öne Çıkan Teknik Özellikler

- DataGridView ile dinamik sepet yönetimi
- LINQ ile koleksiyon işlemleri
- Exception handling (Try-Catch yapısı)
- Stok validasyonu
- Para formatlama (`ToString("C2")`)
- Null kontrol ve güvenli veri erişimi

---

## 📷 Uygulama Akışı

1. Müşteri seçilir
2. Ürün seçilir
3. Adet belirlenir
4. Sepete eklenir
5. Satış tamamlanır
6. Stok otomatik güncellenir

---

## ⚙️ Kurulum

1. Projeyi klonlayın:
```bash
git clone https://github.com/kullaniciadi/projeadi.git
