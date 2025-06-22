using IzinTakipVeOnaySistemi.BLL.DTO;
using IzinTakipVeOnaySistemi.BLL.Services.Interfaces;
using IzinTakipVeOnaySistemi.DAL.Entities;
using IzinTakipVeOnaySistemi.DAL.Enums;
using IzinTakipVeOnaySistemi.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzinTakipVeOnaySistemi.BLL.Services.CRUDQueries
{
    public class CalisanServisi : ICalisanServisi
    {
        private readonly ICalisanRepository<Calisan> _calisanRepo;

        public CalisanServisi(ICalisanRepository<Calisan> calisanRepo)
        {
            _calisanRepo = calisanRepo;
        }

        public void CalisanGuncelle(int calisanId, CalisanCreateUpdateDTO dto)
        {
            var calisan = _calisanRepo.GetirById(calisanId);
            if (calisan != null)
            {
                calisan.Ad = dto.Ad;
                calisan.Soyad = dto.Soyad;
                calisan.EpostaAdresi = dto.Eposta;
                calisan.Sifre = dto.Sifre;
                calisan.IzinSayisi = dto.IzinSayisi;
                calisan.Rol = dto.Rol;
                calisan.DepartmanId = dto.DepartmanId;
            }

            _calisanRepo.Guncelle(calisan);
        }

        public void CalisanOlustur(CalisanCreateUpdateDTO dto)
        {
            var calisan = new Calisan
            {
                Ad = dto.Ad,
                Soyad = dto.Soyad,
                EpostaAdresi = dto.Eposta,
                Sifre = dto.Sifre,
                IzinSayisi = dto.IzinSayisi,
                Rol = dto.Rol,
                DepartmanId = dto.DepartmanId,
            };

            _calisanRepo.Ekle(calisan);
        }

        public void CalisanSil(int calisanId)
        {
            var calisan = _calisanRepo.GetirById(calisanId);
            if (calisan!=null)
            {
                _calisanRepo.SoftSil(calisanId);
            }
        }

        public IEnumerable<Calisan> TumCalisanlariGetir()
        {
            return _calisanRepo.HepsiniListele();
        }
    }
}
