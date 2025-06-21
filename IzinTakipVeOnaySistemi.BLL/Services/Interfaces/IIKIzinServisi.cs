using IzinTakipVeOnaySistemi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzinTakipVeOnaySistemi.BLL.Services.Interfaces
{
    public interface IIKIzinServisi
    {
        void IzinTalebiOnayla(int izinTalepId);

        void IzinTalebiReddet(int izinTalepId);

        IEnumerable<IzinTalep> TumIzinTalepleriniGetir();

    }
}
