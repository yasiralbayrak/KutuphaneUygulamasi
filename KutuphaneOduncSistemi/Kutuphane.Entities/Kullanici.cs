using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane.Entities
{
    public class Kullanici
    {
        public int Id { get; set; }
        public string Ad { get; set; } = null!;
        public string Soyad { get; set; } = null!;
        public string Eposta { get; set; } = null!;

        // Navigation: Kullanıcının ödünç aldığı kitaplar
        public ICollection<Odunc>? Oduncler { get; set; }
    }
}
