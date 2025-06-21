using IzinTakipVeOnaySistemi.DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzinTakipVeOnaySistemi.DAL.Entities
{
    public class Calisan : BaseEntity
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }

        [NotMapped]
        public string TamAd => $"{Ad} {Soyad}";

        public string EpostaAdresi { get; set; }
        public string Sifre { get; set; }
        public int IzinSayisi { get; set; } = 20;

        public Rol Rol { get; set; } //Çalışana atanan rol bilgisi

        public int DepartmanId { get; set; }
        public Departman Departman { get; set; }

        public ICollection<IzinTalep> IzinTalepleri { get; set; }
    }
}
