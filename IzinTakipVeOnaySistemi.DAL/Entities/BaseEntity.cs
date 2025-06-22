using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzinTakipVeOnaySistemi.DAL.Entities
{
    //Tüm Entity sınıfları bu sınıftan miras alarak ortak özellikleri tekrar yazmak zorunda kalmaz
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        public bool AktiflikDurumu { get; set; } = true; //Soft delete işlemi için yazıldı. Veriyi silmek yerine kayıt geçmişi korunur

        public DateTime OlusturmaTarihi { get; set; } = DateTime.Now;
    }
}
