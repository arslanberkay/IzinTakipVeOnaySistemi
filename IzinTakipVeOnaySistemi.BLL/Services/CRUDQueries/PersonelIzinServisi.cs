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
    public class PersonelIzinServisi : IPersonelIzinServisi
    {
        private readonly IPersonelRepository<IzinTalep> _personelRepo;

        public PersonelIzinServisi(IPersonelRepository<IzinTalep> personelRepo)
        {
            _personelRepo = personelRepo;
        }

        public void IzinTalebiOlustur(IzinTalepCreateDTO dto)
        {
            var izinTalebi = new IzinTalep
            {
                CalisanId = dto.CalisanId,
                IzinBaslangicTarihi = dto.BaslangicTarihi,
                IzinBitisTarihi = dto.BitisTarihi,
                Aciklama = dto.Aciklama,
                TalepDurumu = TalepDurum.Bekliyor,
            };

            _personelRepo.Ekle(izinTalebi);
        }

        public void IzinTalepGuncelle(int izinTalepId, IzinTalepUpdateDTO dto)
        {
            var izinTalebi = _personelRepo.GetirById(izinTalepId);

            if (izinTalebi != null && izinTalebi.TalepDurumu == TalepDurum.Bekliyor)
            {
                izinTalebi.IzinBaslangicTarihi = dto.BaslangicTarihi;
                izinTalebi.IzinBitisTarihi = dto.BitisTarihi;
                izinTalebi.Aciklama = dto.Aciklama;

                _personelRepo.Guncelle(izinTalebi);
            }
        }

        public IEnumerable<IzinTalep> IzinTalepleriListele(int calisanId)
        {
            return _personelRepo.HepsiniListele().Where(x => x.CalisanId == calisanId);
        }

        public void IzinTalepSil(int izinTalepId)
        {
            var izinTalep = _personelRepo.GetirById(izinTalepId);

            if (izinTalep != null && izinTalep.TalepDurumu == TalepDurum.Bekliyor)
            {
                _personelRepo.SoftSil(izinTalepId);
            }
        }
    }
}
