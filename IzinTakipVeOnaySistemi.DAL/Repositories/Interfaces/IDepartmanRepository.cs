using IzinTakipVeOnaySistemi.DAL.Entities;
using IzinTakipVeOnaySistemi.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzinTakipVeOnaySistemi.DAL.Repositories.Interfaces
{
    public interface IDepartmanRepository<T> : IEkle<T>, IGuncelle<T>, ISil<T>, ISoftSil<T>, IListele<T> where T : BaseEntity
    {
    }
}
