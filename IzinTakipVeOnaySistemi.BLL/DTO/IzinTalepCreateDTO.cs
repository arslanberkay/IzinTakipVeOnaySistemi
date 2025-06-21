using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzinTakipVeOnaySistemi.BLL.DTO
{
    //Çalışanın izin talebi oluştururken gönderilecek veriyi temsil eder
    public record IzinTalepCreateDTO
    {
        public int CalisanId { get; set; }

        public DateTime BaslangicTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }

        public string Aciklama { get; set; }

        //NOT : DTO'lar veri transferinde güvenlik ve doğrulama açısından çok önemlidir. Entity gönderilmez.
    }
}
