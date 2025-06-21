using IzinTakipVeOnaySistemi.DAL.Entities;
using IzinTakipVeOnaySistemi.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzinTakipVeOnaySistemi.DAL.Repositories.Interfaces
{
    public interface IIKRepository<T> : IListele<T>,  IGuncelle<T> where T : BaseEntity
    {
        //where T : BaseEntity demek bu generic yapı sadece BaseEntity sınıfından miras alan sınıflarla çalışabilir demektir
    }
}
