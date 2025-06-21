using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzinTakipVeOnaySistemi.BLL.DTO
{
    public record IzinTalepUpdateDTO
    {
        public DateTime BaslangicTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }
        public string Aciklama { get; set; }

    }
}
