using IzinTakipVeOnaySistemi.BLL.DTO;
using IzinTakipVeOnaySistemi.BLL.Services.Interfaces;
using IzinTakipVeOnaySistemi.DAL.Entities;
using IzinTakipVeOnaySistemi.DAL.Enums;
using IzinTakipVeOnaySistemi.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzinTakipVeOnaySistemi.BLL.Services.CRUDQueries
{
    public class FinansServisi : IFinansServisi
    {
        private readonly IFinansRepository<IzinTalep> _finansRepo;

        public FinansServisi(IFinansRepository<IzinTalep> finansRepo)
        {
            _finansRepo = finansRepo;
        }


        public void OdemeBilgisiOlustur(int izinTalepId, OdemeBilgisiCreateDTO dto)
        {
            var odemeBilgisi = new OdemeBilgisi
            {
                OdenecekTutar = dto.OdenecekTutar,
                OdemeTarihi = DateTime.Now,
                IzinTalepId = izinTalepId
            };

            
        }

        public IEnumerable<IzinTalep> OnaylanmisTalepleriGetir()
        {
            return _finansRepo.HepsiniListele().Where(x => x.TalepDurumu == TalepDurum.Onaylandı).ToList();
        }
    }
}
