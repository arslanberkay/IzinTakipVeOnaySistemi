using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzinTakipVeOnaySistemi.DAL.Interfaces
{
    public interface IListele<T>
    {
        T GetirById(int id); //id değeriyle veritabanındaki bir kaydı getirir.

        IEnumerable<T> HepsiniListele(T entity); //T türündeki tüm verileri getirir.
    }
}
