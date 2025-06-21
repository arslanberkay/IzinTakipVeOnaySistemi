using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzinTakipVeOnaySistemi.DAL.Interfaces
{
    public interface IEkle<T>
    {
        void Ekle(T entity); //Bu interface'i uygulayan sınıflar T türündeki nesneleri eklemekle yükümlü olur
    }
}
