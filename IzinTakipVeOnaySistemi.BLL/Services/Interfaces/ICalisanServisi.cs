using IzinTakipVeOnaySistemi.BLL.DTO;
using IzinTakipVeOnaySistemi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzinTakipVeOnaySistemi.BLL.Services.Interfaces
{
    public interface ICalisanServisi
    {
        IEnumerable<Calisan> TumCalisanlariGetir();

        void CalisanOlustur(CalisanCreateUpdateDTO dto);

        void CalisanGuncelle(int calisanId, CalisanCreateUpdateDTO dto);

        void CalisanSil(int calisanId);
    }
}
