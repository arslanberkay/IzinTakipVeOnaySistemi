using IzinTakipVeOnaySistemi.BLL.DTO;
using IzinTakipVeOnaySistemi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzinTakipVeOnaySistemi.BLL.Services.Interfaces
{
    public interface IFinansServisi
    {
        IEnumerable<IzinTalep> OnaylanmisTalepleriGetir();

        void OdemeBilgisiOlustur(int izinTalepId, OdemeBilgisiCreateDTO dto);
    }
}
