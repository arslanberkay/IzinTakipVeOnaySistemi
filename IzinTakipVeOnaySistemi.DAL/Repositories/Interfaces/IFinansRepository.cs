using IzinTakipVeOnaySistemi.DAL.Entities;
using IzinTakipVeOnaySistemi.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzinTakipVeOnaySistemi.DAL.Repositories.Interfaces
{
    public interface IFinansRepository<T> : IListele<T>, IGuncelle<T> where T : BaseEntity
    {
    }
}
