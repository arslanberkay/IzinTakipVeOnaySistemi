using IzinTakipVeOnaySistemi.DAL.Entities;
using IzinTakipVeOnaySistemi.DAL.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace IzinTakipVeOnaySistemi.DAL.Context
{
    public class IzinTakipOnayDbContext : DbContext
    {
        public IzinTakipOnayDbContext(DbContextOptions<IzinTakipOnayDbContext> options) : base(options) { }

        public DbSet<Calisan> Calisanlar { get; set; }
        public DbSet<IzinTalep> IzinTalepler { get; set; }
        public DbSet<Departman> Departmanlar { get; set; }
        public DbSet<OdemeBilgisi> OdemeBilgileri { get; set; }
    }
}
