using KutuphaneUygulamasi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneUygulamasi.Business
{
    public interface IYazarService
    {
        void YazarEkle(Yazar yazar);
        List<Yazar> TumYazarlariGetir();
    }
}
