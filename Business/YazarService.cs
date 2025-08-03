using KutuphaneUygulamasi.DataAccess;
using KutuphaneUygulamasi.Entities;
using System.Collections.Generic;
using System.Linq;

namespace KutuphaneUygulamasi.Business
{
    public class YazarService : IYazarService
    {
        private readonly KutuphaneDbContext _context;

        public YazarService(KutuphaneDbContext context)
        {
            _context = context;
        }

        public void YazarEkle(Yazar yazar)
        {
            _context.Yazarlar.Add(yazar);
            _context.SaveChanges();
        }

        public List<Yazar> TumYazarlariGetir()
        {
            return _context.Yazarlar.ToList();
        }
    }
}