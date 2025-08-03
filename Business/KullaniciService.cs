using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KutuphaneUygulamasi.DataAccess;
using KutuphaneUygulamasi.Entities;

namespace KutuphaneUygulamasi.Business
{
    public class KullaniciService : IKullaniciService
    {
        private readonly KutuphaneDbContext _context;

        public KullaniciService(KutuphaneDbContext context)
        {
            _context = context;
        }

        public void KullaniciEkle(Kullanici kullanici)
        {
            _context.Kullanicilar.Add(kullanici);
            _context.SaveChanges();
        }

        public void KullaniciGuncelle(Kullanici kullanici)
        {
            _context.Kullanicilar.Update(kullanici);
            _context.SaveChanges();
        }

        public void KullaniciSil(int id)
        {
            var k = _context.Kullanicilar.Find(id);
            if (k != null)
            {
                _context.Kullanicilar.Remove(k);
                _context.SaveChanges();
            }
        }

        public List<Kullanici> TumKullanicilariGetir()
        {
            return _context.Kullanicilar.ToList();
        }

        public Kullanici? IdIleKullaniciGetir(int id)
        {
            return _context.Kullanicilar.FirstOrDefault(k => k.Id == id);
        }

        public void OrnekMetod(string? ad, string? soyad)
        {
            Console.Write("Ad: ");
            string adInput = Console.ReadLine() ?? string.Empty;
            Console.Write("Soyad: ");
            string soyadInput = Console.ReadLine() ?? string.Empty;
            Console.Write("Eposta: ");
            string eposta = Console.ReadLine() ?? string.Empty;
            Kullanici yeni = new Kullanici { Ad = ad, Soyad = soyad, Eposta = eposta };
            KullaniciEkle(yeni);
        }
    }
}
