using IzinTakipVeOnaySistemi.DAL.Enums;

namespace IzinTakipVeOnaySistemi.UI.ViewModels
{
    public class CalisanListViewModel
    {
        public int Id  { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Eposta { get; set; }
        public int IzinSayisi { get; set; }
        public Rol Rol { get; set; }
        public int DepartmanId { get; set; }
        public string DepartmanAdi { get; set; }
    }
}
