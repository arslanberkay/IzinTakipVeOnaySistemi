using IzinTakipVeOnaySistemi.BLL.DTO;
using IzinTakipVeOnaySistemi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzinTakipVeOnaySistemi.BLL.Services.Interfaces
{
    public interface IPersonelIzinServisi
    {
        IEnumerable<IzinTalep> IzinTalepleriListele(int calisanId);

        void IzinTalebiOlustur(IzinTalepCreateDTO dto);

        void IzinTalepGuncelle(int izinTalepId, IzinTalepUpdateDTO dto);

        void IzinTalepSil(int izinTalepId);
    }
}
