using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzinTakipVeOnaySistemi.DAL.Entities
{
    public class OdemeBilgisi :BaseEntity
    {
        public decimal OdenecekTutar { get; set; }

        public DateTime OdemeTarihi { get; set; }

        public IzinTalep IzinTalep { get; set; }

    }
}
