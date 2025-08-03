using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneUygulamasi.Entities
{
    public class Odunc
    {
        public int Id { get; set; }

        public int KitapId { get; set; }
        public Kitap Kitap { get; set; }

        public int KullaniciId { get; set; }
        public Kullanici Kullanici { get; set; }

        public DateTime AlisTarihi { get; set; }
        public DateTime? TeslimTarihi { get; set; }
    }
}

