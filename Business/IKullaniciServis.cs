using KutuphaneUygulamasi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneUygulamasi.Business
{
    public interface IKullaniciService
    {
        void KullaniciEkle(Kullanici kullanici);
        void KullaniciGuncelle(Kullanici kullanici);
        void KullaniciSil(int id);
        List<Kullanici> TumKullanicilariGetir();
        Kullanici? IdIleKullaniciGetir(int id);
    }
}
