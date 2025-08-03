using Kutuphane.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Kutuphane.Entities.Enum;


namespace Kutuphane.Entities
{
    public class Kitap
    {
        public int Id { get; set; }
        public string Ad { get; set; } = null!;
        public Kategori Kategori { get; set; }
        public DateTime YayinTarihi { get; set; }

        // Foreign Key
        public int YazarId { get; set; }

        // Navigation Property
        public Yazar? Yazar { get; set; }

        // Kitap birden fazla kez ödünç verilebilir
        public ICollection<Odunc>? OduncListesi { get; set; }
    }
}
}
