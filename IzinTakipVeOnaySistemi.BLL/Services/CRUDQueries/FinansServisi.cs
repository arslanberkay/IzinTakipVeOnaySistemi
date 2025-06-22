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
        private readonly IOdemeBilgisiRepository<OdemeBilgisi> _odemeRepo;

        public FinansServisi(IFinansRepository<IzinTalep> finansRepo, IOdemeBilgisiRepository<OdemeBilgisi> odemeRepo)
        {
            _finansRepo = finansRepo;
            _odemeRepo = odemeRepo;
        }

        public IEnumerable<IzinTalep> OnaylanmisTalepleriGetir()
        {
            return _finansRepo.HepsiniListele().Where(x => x.TalepDurumu == TalepDurum.Onaylandı).ToList();
        }

        public IEnumerable<OdemeBilgisi> OdemeBilgileriniGetir()
        {
            return _odemeRepo.HepsiniListele().ToList();
        }

        public void OdemeBilgisiGuncelle(int odemeBilgisiId, OdemeBilgisiUpdateDTO dto)
        {
            var odemeBilgisi = _odemeRepo.GetirById(odemeBilgisiId);

            if (odemeBilgisi != null)
            {
                odemeBilgisi.OdenecekTutar = dto.OdenecekTutar;
                _odemeRepo.Guncelle(odemeBilgisi);
            }
        }

        public void OdemeBilgisiOlustur(int izinTalepId, OdemeBilgisiCreateDTO dto)
        {
            var odemeBilgisi = new OdemeBilgisi
            {
                OdenecekTutar = dto.OdenecekTutar,
                OdemeTarihi = DateTime.Now,
                IzinTalepId = izinTalepId
            };

            _odemeRepo.Ekle(odemeBilgisi);

        }

        public void OdemeBilgisiSil(int odemeBilgisiId)
        {
            var odemeBilgisi = _odemeRepo.GetirById(odemeBilgisiId);
            if (odemeBilgisi != null)
            {
                _odemeRepo.SoftSil(odemeBilgisiId);
            }
        }

        
    }
}
