using KutuphaneUygulamasi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneUygulamasi.Business
{
    public interface IOduncService
    {
        void OduncVer(int kitapId, int kullaniciId);
        void OduncIade(int oduncId);
        List<Odunc> TumOduncler();
    }
}
