using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneUygulamasi.Entities
{
    public enum Kategori
    {
        Roman,
        Hikaye,
        Tarih,
        Bilim,
        Felsefe
    }

    public class Kitap
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public Kategori Kategori { get; set; }
        public DateTime YayinTarihi { get; set; }
        public int StokMiktari { get; set; }

        // İlişkiler
        public int YazarId { get; set; }
        public Yazar Yazar { get; set; }

        public List<Odunc> OduncListesi { get; set; } = new ();
    }
}
