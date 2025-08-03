using KutuphaneUygulamasi.DataAccess;
using KutuphaneUygulamasi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneUygulamasi.Business
{
    public class KitapService : IKitapService
    {
        private readonly KutuphaneDbContext _context;

        public KitapService(KutuphaneDbContext context)
        {
            _context = context;
        }

        public void KitapEkle(Kitap kitap)
        {
            _context.Kitaplar.Add(kitap);
            _context.SaveChanges();
        }

        public void KitapGuncelle(Kitap kitap)
        {
            _context.Kitaplar.Update(kitap);
            _context.SaveChanges();
        }

        public void KitapSil(int id)
        {
            var kitap = _context.Kitaplar.Find(id);
            if (kitap != null)
            {
                _context.Kitaplar.Remove(kitap);
                _context.SaveChanges();
            }
        }

        public List<Kitap> TumKitaplariGetir()
        {
            return _context.Kitaplar
                .Include(k => k.Yazar)
                .ToList();
        }

        public Kitap? IdIleKitapGetir(int id)
        {
            return _context.Kitaplar
                .Include(k => k.Yazar)
                .FirstOrDefault(k => k.Id == id);
        }
    }
}
