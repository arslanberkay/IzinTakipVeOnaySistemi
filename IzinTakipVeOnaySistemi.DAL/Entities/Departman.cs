using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzinTakipVeOnaySistemi.DAL.Entities
{
    public class Departman :BaseEntity
    {
        public string Ad { get; set; }

        public ICollection<Calisan> Calisanlar { get; set; }
    }
}
