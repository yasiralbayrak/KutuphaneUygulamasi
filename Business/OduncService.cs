using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KutuphaneUygulamasi.DataAccess;
using KutuphaneUygulamasi.Entities;
using Microsoft.EntityFrameworkCore;

namespace KutuphaneUygulamasi.Business
{
    public class OduncService : IOduncService
    {
        private readonly KutuphaneDbContext _context;

        public OduncService(KutuphaneDbContext context)
        {
            _context = context;
        }

        public void OduncVer(int kitapId, int kullaniciId)
        {
            var kitap = _context.Kitaplar.FirstOrDefault(k => k.Id == kitapId);
            if (kitap == null)
                throw new Exception("Kitap bulunamadı.");

            if (kitap.StokMiktari < 1)
                if (kitap.StokMiktari < 1)
                    throw new Exception("Kitap stokta yok. Ödünç verilemez.");
                if (kitap.StokMiktari < 1)
                    throw new InvalidOperationException("Kitap stokta yok. Ödünç verilemez.");
                if (kitap.StokMiktari < 1)
                    throw new InvalidOperationException($"'{kitap.Ad}' adlı kitap stokta yok. Ödünç verilemez.");
                throw new Exception("Kitap stokta yok. Ödünç verilemez.");

            kitap.StokMiktari--;

            var odunc = new Odunc
            {
                KitapId = kitapId,
                KullaniciId = kullaniciId,
                AlisTarihi = DateTime.Now,
                TeslimTarihi = null
            };

            _context.Oduncler.Add(odunc);
            _context.SaveChanges();
        }

        public void OduncIade(int oduncId)
        {
            var odunc = _context.Oduncler
                .Include(o => o.Kitap)
                .FirstOrDefault(o => o.Id == oduncId);

            if (odunc == null)
                throw new Exception("Ödünç kaydı bulunamadı.");

            if (odunc.TeslimTarihi != null)
                throw new Exception("Bu ödünç zaten iade edilmiş.");

            odunc.TeslimTarihi = DateTime.Now;
            odunc.Kitap.StokMiktari++;

            _context.SaveChanges();
        }

        public List<Odunc> TumOduncler()
        {
            return _context.Oduncler
                .Include(o => o.Kitap)
                .Include(o => o.Kullanici)
                .ToList();
        }
    }
}
