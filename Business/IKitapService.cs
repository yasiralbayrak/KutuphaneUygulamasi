using KutuphaneUygulamasi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneUygulamasi.Business
{
    public interface IKitapService
    {
        void KitapEkle(Kitap kitap);
        void KitapGuncelle(Kitap kitap);
        void KitapSil(int id);
        List<Kitap> TumKitaplariGetir();
        Kitap? IdIleKitapGetir(int id);
    }
}
