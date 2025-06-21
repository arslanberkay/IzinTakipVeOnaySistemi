using IzinTakipVeOnaySistemi.DAL.Entities;
using IzinTakipVeOnaySistemi.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzinTakipVeOnaySistemi.DAL.Repositories.Interfaces
{
    //Interfaces klasöründe tanımladığımı küçük interfacelerin birleştirilmiş hali (İhtiyaca göre)
    public interface IPersonelRepository<T> : IEkle<T>, IListele<T>, IGuncelle<T>, ISil<T>, ISoftSil<T> where T : BaseEntity
    {
    //T türünde entity alır ve Ekle,Guncelle,Sil,SoftSil,GetirById,HepsiniListele işlemlerini tek bir interface üzerinden yapmamızı sağlar
    }


}
