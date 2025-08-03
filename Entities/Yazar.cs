using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneUygulamasi.Entities
{
    public class Yazar
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }

        // Kitaplarla ilişki
        public ICollection<Kitap> Kitaplar { get; set; }
    }
}
