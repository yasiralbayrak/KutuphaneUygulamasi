using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane.Entities
{
    public class Yazar
    {
        public int Id { get; set; }
        public string Ad { get; set; } = null!;
        public string Soyad { get; set; } = null!;

        // Navigation: Bir yazarın birden çok kitabı olabilir
        public ICollection<Kitap>? Kitaplar { get; set; }
    }
}
