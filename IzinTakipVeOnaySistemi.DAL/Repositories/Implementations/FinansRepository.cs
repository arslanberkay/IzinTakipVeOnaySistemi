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
    public class FinansRepository<T> : IFinansRepository<T> where T : BaseEntity
    {
        private readonly IzinTakipOnayDbContext _db;

        public FinansRepository(IzinTakipOnayDbContext db)
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

        public IEnumerable<T> HepsiniListele()
        {
            return _db.Set<T>().Where(x => x.AktiflikDurumu).ToList();
        }
    }
}
