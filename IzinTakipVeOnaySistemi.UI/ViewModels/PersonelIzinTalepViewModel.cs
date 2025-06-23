using IzinTakipVeOnaySistemi.DAL.Enums;

namespace IzinTakipVeOnaySistemi.UI.ViewModels
{
    public class PersonelIzinTalepViewModel
    {
        public int Id { get; set; }
        public DateTime IzinBaslangicTarihi { get; set; }
        public DateTime IzinBitisTarihi { get; set; }
        public string Aciklama { get; set; }
        public TalepDurum TalepDurumu { get; set; }
        public DateTime? OnayTarihi { get; set; }
    }
}
