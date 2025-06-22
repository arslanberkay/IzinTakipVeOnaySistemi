using IzinTakipVeOnaySistemi.BLL.DTO;
using IzinTakipVeOnaySistemi.BLL.Services.Interfaces;
using IzinTakipVeOnaySistemi.DAL.Entities;
using IzinTakipVeOnaySistemi.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzinTakipVeOnaySistemi.BLL.Services.CRUDQueries
{
    public class DepartmanServisi : IDepartmanServisi
    {
        private readonly IDepartmanRepository<Departman> _departmanRepo;

        public DepartmanServisi(IDepartmanRepository<Departman> departmanRepo)
        {
            _departmanRepo = departmanRepo;
        }

        public void DepartmanGuncelle(int departmanId, DepartmanCreateUpdateDTO dto)
        {
            var departman = _departmanRepo.GetirById(departmanId);
            if (departman != null)
            {
                departman.Ad = dto.Ad;
                _departmanRepo.Guncelle(departman);
            }
        }

        public IEnumerable<Departman> DepartmanlariGetir()
        {
            return _departmanRepo.HepsiniListele();
        }

        public void DepartmanOlustur(DepartmanCreateUpdateDTO dto)
        {
            var departman = new Departman
            {
                Ad = dto.Ad,
            };

            _departmanRepo.Ekle(departman);
        }

        public void DepartmanSil(int departmanId)
        {
            var departman = _departmanRepo.GetirById(departmanId);
            if (departman != null)
            {
                _departmanRepo.SoftSil(departmanId);
            }
        }
    }
}
