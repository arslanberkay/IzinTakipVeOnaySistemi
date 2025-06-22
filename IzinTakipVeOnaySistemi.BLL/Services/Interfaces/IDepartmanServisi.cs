using IzinTakipVeOnaySistemi.BLL.DTO;
using IzinTakipVeOnaySistemi.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzinTakipVeOnaySistemi.BLL.Services.Interfaces
{
    public interface IDepartmanServisi
    {
        IEnumerable<Departman> DepartmanlariGetir();

        void DepartmanOlustur(DepartmanCreateUpdateDTO dto);

        void DepartmanGuncelle(int departmanId, DepartmanCreateUpdateDTO dto);

        void DepartmanSil(int departmanId);
    }
}
