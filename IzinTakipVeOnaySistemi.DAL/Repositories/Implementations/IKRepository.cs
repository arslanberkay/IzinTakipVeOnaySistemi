using IzinTakipVeOnaySistemi.DAL.Context;
using IzinTakipVeOnaySistemi.DAL.Entities;
using IzinTakipVeOnaySistemi.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzinTakipVeOnaySistemi.DAL.Repositories.Implementations
{
    public class IKRepository<T> : IIKRepository<T> where T : BaseEntity
    {
        private readonly IzinTakipOnayDbContext _db;

        public IKRepository(IzinTakipOnayDbContext db)
        {
            _db = db;
        }

        public T GetirById(int id)
        {
            return _db.Set<T>().Find(id);
        }

        public void Guncelle(T entity)
        {
            _db.Set<T>().Update(entity);
            _db.SaveChanges();
        }

        public IEnumerable<T> HepsiniListele(T entity)
        {
            return _db.Set<T>().Where(x => x.AktiflikDurumu).ToList();
        }

        public void Sil(int id)
        {
            var entity = _db.Set<T>().Find(id);
            if (entity != null)
            {
                _db.Set<T>().Remove(entity);
                _db.SaveChanges();
            }
        }

        public void SoftSil(int id)
        {
            var entity = _db.Set<T>().Find(id);
            if (entity != null)
            {
                entity.AktiflikDurumu = false;
                _db.SaveChanges();
            }
        }
    }
}
