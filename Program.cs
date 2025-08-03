using KutuphaneUygulamasi.Business;
using KutuphaneUygulamasi.DataAccess;
using KutuphaneUygulamasi.Entities;
using System;
using Microsoft.EntityFrameworkCore;

namespace KutuphaneUygulamasi
{
    class Program
    {
        static void Main(string[] args)
        {
            KutuphaneDbContext context = new KutuphaneDbContext();
            KullaniciService kullaniciService = new KullaniciService(context);
            KitapService kitapService = new KitapService(context);
            OduncService oduncService = new OduncService(context);
            using (var migrateContext = new KutuphaneDbContext())
            {
                migrateContext.Database.Migrate();
            }

            while (true)
            {
                Console.WriteLine("Kullanıcı İşlemleri:");
                Console.WriteLine("1 - Kullanıcı Ekle");
                Console.WriteLine("2 - Kullanıcı Listele");
                Console.WriteLine("3 - Kullanıcı Güncelle");
                Console.WriteLine("4 - Kullanıcı Sil");
                Console.WriteLine("Kitap/Yazar İşlemleri:");
                Console.WriteLine("8 - Kitap İşlemleri");
                Console.WriteLine("9 - Yazar İşlemleri");
                // Ödünç işlemleri menüsü
                Console.WriteLine("Ödünç İşlemleri:");
                Console.WriteLine("5 - Kitap Ödünç Al");
                Console.WriteLine("6 - Kitap Teslim Et (İade)");
                Console.WriteLine("7 - Ödünç Alınan Kitapları Listele");
                Console.WriteLine("0 - Çıkış");

                Console.Write("Seçiminiz: ");
                string secim = Console.ReadLine() ?? string.Empty;

                if (secim == "0") break;

                switch (secim)
                {
                    case "1":
                        Console.Write("Ad: ");
                        string ad = Console.ReadLine() ?? string.Empty;
                        Console.Write("Soyad: ");
                        string soyad = Console.ReadLine() ?? string.Empty;
                        Console.Write("Eposta: ");
                        string eposta = Console.ReadLine() ?? string.Empty;

                        Kullanici yeni = new Kullanici { Ad = ad, Soyad = soyad, Eposta = eposta };
                        kullaniciService.KullaniciEkle(yeni);
                        Console.WriteLine("Kullanıcı eklendi.\n");
                        break;

                    case "2":
                        var liste = kullaniciService.TumKullanicilariGetir();
                        foreach (var k in liste)
                        {
                            Console.WriteLine($"ID: {k.Id}, Ad: {k.Ad}, Soyad: {k.Soyad}");
                        }
                        Console.WriteLine();
                        break;

                    case "3":
                        Console.Write("Güncellenecek Kullanıcı ID: ");
                        string? idGInput = Console.ReadLine();
                        if (!int.TryParse(idGInput, out int idG))
                        {
                            Console.WriteLine("Geçersiz ID girdiniz.\n");
                            break;
                        }

                        var mevcut = kullaniciService.IdIleKullaniciGetir(idG);
                        if (mevcut == null)
                        {
                            Console.WriteLine("Kullanıcı bulunamadı.\n");
                            break;
                        }

                        Console.Write("Yeni Ad: ");
                        mevcut.Ad = Console.ReadLine() ?? string.Empty;
                        Console.Write("Yeni Soyad: ");
                        mevcut.Soyad = Console.ReadLine() ?? string.Empty;
                        Console.Write("Yeni Eposta: ");
                        mevcut.Eposta = Console.ReadLine() ?? string.Empty;

                        kullaniciService.KullaniciGuncelle(mevcut);
                        Console.WriteLine("Güncellendi.\n");
                        break;

                    case "4":
                        Console.Write("Silinecek Kullanıcı ID: ");
                        string? idSInput = Console.ReadLine();
                        if (!int.TryParse(idSInput, out int idS))
                        {
                            Console.WriteLine("Geçersiz ID girdiniz.\n");
                            break;
                        }

                        kullaniciService.KullaniciSil(idS);
                        Console.WriteLine("Silindi.\n");
                        break;

                    // Ödünç işlemleri case
                    case "5":
                        Console.Write("Kullanıcı ID: ");
                        if (!int.TryParse(Console.ReadLine(), out int kullaniciId))
                        {
                            Console.WriteLine("Geçersiz kullanıcı ID.\n");
                            break;
                        }

                        Console.Write("Kitap ID: ");
                        if (!int.TryParse(Console.ReadLine(), out int kitapId))
                        {
                            Console.WriteLine("Geçersiz kitap ID.\n");
                            break;
                        }

                        oduncService.OduncVer(kitapId, kullaniciId);
                        Console.WriteLine("Kitap ödünç verildi.\n");
                        break;

                    case "6":
                        Console.Write("İade edilecek kitap ID: ");
                        if (!int.TryParse(Console.ReadLine(), out int iadeKitapId))
                        {
                            Console.WriteLine("Geçersiz ID.\n");
                            break;
                        }

                        oduncService.OduncIade(iadeKitapId);
                        Console.WriteLine("Kitap iade edildi.\n");
                        break;

                    case "7":
                        var oduncListesi = oduncService.TumOduncler();
                        foreach (var odunc in oduncListesi)
                        {
                            string durum = odunc.TeslimTarihi == null ? "Teslim edilmedi" : $"İade Tarihi: {odunc.TeslimTarihi.Value.ToShortDateString()}";
                            Console.WriteLine($"ID: {odunc.Id}, Kitap: {odunc.Kitap?.Ad}, Kullanıcı: {odunc.Kullanici?.Ad} {odunc.Kullanici?.Soyad}, Alış Tarihi: {odunc.AlisTarihi.ToShortDateString()}, {durum}");
                        }
                        Console.WriteLine();
                        break;

                    case "8":
                        KitapIslemleri(new KitapService(context));
                        break;

                    case "9":
                        YazarIslemleri(new YazarService(context));
                        break;

                    default:
                        Console.WriteLine("Geçersiz seçim.\n");
                        break;
                }
            }
        }

        static void KitapIslemleri(KitapService kitapService)
        {
            while (true)
            {
                Console.WriteLine("\n--- Kitap İşlemleri ---");
                Console.WriteLine("1 - Kitap Ekle");
                Console.WriteLine("2 - Kitap Listele");
                Console.WriteLine("3 - Kitap Güncelle");
                Console.WriteLine("4 - Kitap Sil");
                Console.WriteLine("0 - Geri Dön");


                Console.Write("Seçiminiz: ");
                string secim = Console.ReadLine() ?? string.Empty;

                if (secim == "0") break;

                switch (secim)
                {
                    case "1":
                        Console.Write("Kitap Adı: ");
                        string ad = Console.ReadLine() ?? string.Empty;
                        Console.Write("Kategori (0=Roman, 1=Bilim, 2=Tarih): ");
                        string? kategoriInput = Console.ReadLine();
                        if (!int.TryParse(kategoriInput, out int kategori))
                        {
                            Console.WriteLine("Geçersiz kategori girdiniz.");
                            break;
                        }
                        Console.Write("Yayın Tarihi (yyyy-aa-gg): ");
                        string? yayinTarihiInput = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(yayinTarihiInput) || !DateTime.TryParse(yayinTarihiInput, out DateTime yayinTarihi))
                        {
                            Console.WriteLine("Geçersiz yayın tarihi girdiniz.");
                            break;
                        }
                        Console.Write("Yazar ID: ");
                        string? yazarIdInput = Console.ReadLine();
                        if (!int.TryParse(yazarIdInput, out int yazarId))
                        {
                            Console.WriteLine("Geçersiz yazar ID girdiniz.");
                            break;
                        }

                        var kitap = new Kitap
                        {
                            Ad = ad,
                            Kategori = (Kategori)kategori,
                            YayinTarihi = yayinTarihi,
                            YazarId = yazarId
                        };
                        kitapService.KitapEkle(kitap);
                        Console.WriteLine("Kitap eklendi.\n");
                        break;

                    case "2":
                        var kitaplar = kitapService.TumKitaplariGetir();
                        foreach (var k in kitaplar)
                        {
                            string yazarBilgi = k.Yazar != null ? $"{k.Yazar.Ad} {k.Yazar.Soyad}" : "Yazar bilgisi yok";
                            Console.WriteLine($"ID: {k.Id}, Ad: {k.Ad}, Yazar: {k.Yazar?.Ad} {k.Yazar?.Soyad}, Yayın: {k.YayinTarihi:yyyy}");
                        }
                        break;

                    case "3":
                        Console.Write("Güncellenecek Kitap ID: ");
                        string? gidInput = Console.ReadLine();
                        if (!int.TryParse(gidInput, out int gid))
                        {
                            Console.WriteLine("Geçersiz Kitap ID girdiniz.");
                            break;
                        }
                        var gkitap = kitapService.IdIleKitapGetir(gid);
                        if (gkitap == null)
                        {
                            Console.WriteLine("Kitap bulunamadı.");
                            break;
                        }
                        Console.Write("Yeni Ad: ");
                        string yeniAd = Console.ReadLine() ?? string.Empty;
                        gkitap.Ad = yeniAd;
                        kitapService.KitapGuncelle(gkitap);
                        Console.WriteLine("Kitap güncellendi.");
                        break;

                    case "4":
                        Console.Write("Silinecek Kitap ID: ");
                        string? sidInput = Console.ReadLine();
                        if (!int.TryParse(sidInput, out int sid))
                        {
                            Console.WriteLine("Geçersiz Kitap ID girdiniz.");
                            break;
                        }
                        kitapService.KitapSil(sid);
                        Console.WriteLine("Kitap silindi.");
                        break;

                    default:
                        Console.WriteLine("Geçersiz seçim.");
                        break;
                }
            }
        }

        static void YazarIslemleri(YazarService yazarService)
        {
            while (true)
            {
                Console.WriteLine("\n--- Yazar İşlemleri ---");
                Console.WriteLine("1 - Yazar Ekle");
                Console.WriteLine("2 - Yazarları Listele");
                Console.WriteLine("0 - Geri Dön");

                Console.Write("Seçiminiz: ");
                string secim = Console.ReadLine() ?? "";

                if (secim == "0") break;

                switch (secim)
                {
                    case "1":
                        Console.Write("Yazar Adı: ");
                        string ad = Console.ReadLine() ?? "";
                        Console.Write("Yazar Soyadı: ");
                        string soyad = Console.ReadLine() ?? "";

                        var yazar = new Yazar { Ad = ad, Soyad = soyad };
                        yazarService.YazarEkle(yazar);
                        Console.WriteLine("Yazar eklendi.\n");
                        break;

                    case "2":
                        var yazarlar = yazarService.TumYazarlariGetir();
                        foreach (var y in yazarlar)
                        {
                            Console.WriteLine($"ID: {y.Id}, Ad: {y.Ad} {y.Soyad}");
                        }
                        break;

                    default:
                        Console.WriteLine("Geçersiz seçim.");
                        break;
                }
            }
        }
    }
}
