using IzinTakipVeOnaySistemi.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzinTakipVeOnaySistemi.DAL.Repositories.Interfaces
{
    public interface IOdemeBilgisiRepository<T> : IEkle<T>, IGuncelle<T>, IListele<T>, ISoftSil<T> where T : class
    {

    }
}
