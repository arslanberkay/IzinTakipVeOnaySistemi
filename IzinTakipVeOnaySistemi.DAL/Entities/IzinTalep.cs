using IzinTakipVeOnaySistemi.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzinTakipVeOnaySistemi.DAL.Entities
{
    public class IzinTalep : BaseEntity
    {
        public DateTime IzinBaslangicTarihi { get; set; }

        public DateTime IzinBitisTarihi { get; set; }

        public string Aciklama { get; set; }

        public int CalisanId { get; set; }
        public Calisan Calisan { get; set; }

        public TalepDurum TalepDurumu { get; set; }

        public DateTime? OnayTarihi { get; set; }

        public int OdemeBilgisiId { get; set; }
        public OdemeBilgisi OdemeBilgisi { get; set; }

    }
}
