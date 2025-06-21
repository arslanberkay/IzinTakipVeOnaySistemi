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
    public class IKIzinServisi : IIKIzinServisi
    {
        private readonly IIKRepository<IzinTalep> _ikRepo;

        public IKIzinServisi(IIKRepository<IzinTalep> ikRepo)
        {
            _ikRepo = ikRepo;
        }

        public void IzinTalebiOnayla(int izinTalepId)
        {
            var izinTalebi = _ikRepo.GetirById(izinTalepId);

            if (izinTalebi != null && izinTalebi.TalepDurumu == TalepDurum.Bekliyor)
            {
                izinTalebi.TalepDurumu = TalepDurum.Onaylandı;
                izinTalebi.OnayTarihi = DateTime.Now;
                _ikRepo.Guncelle(izinTalebi);
            }
        }

        public void IzinTalebiReddet(int izinTalepId)
        {
            var izinTalebi = _ikRepo.GetirById(izinTalepId);

            if (izinTalebi != null && izinTalebi.TalepDurumu == TalepDurum.Bekliyor)
            {
                izinTalebi.TalepDurumu = TalepDurum.Reddedildi;
                _ikRepo.Guncelle(izinTalebi);
            }
        }

        public IEnumerable<IzinTalep> TumIzinTalepleriniGetir()
        {
            return _ikRepo.HepsiniListele();
        }
    }
}
