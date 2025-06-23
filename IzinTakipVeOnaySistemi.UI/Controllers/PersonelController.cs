using IzinTakipVeOnaySistemi.BLL.DTO;
using IzinTakipVeOnaySistemi.BLL.Services.Interfaces;
using IzinTakipVeOnaySistemi.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace IzinTakipVeOnaySistemi.UI.Controllers
{
    public class PersonelController : Controller
    {
        private readonly IPersonelIzinServisi _personelIzinServisi;

        public PersonelController(IPersonelIzinServisi personelIzinServisi)
        {
            _personelIzinServisi = personelIzinServisi;
        }

        public IActionResult Index()
        {
            //Giriş yapan çalışanı bulalım
            var girisYapanCalisanId = HttpContext.Session.GetInt32("CalisanId");

            //Oturum Kontrolü
            if (girisYapanCalisanId == null) { return RedirectToAction("Login", "Account"); }

            var izinTalepleri = _personelIzinServisi.IzinTalepleriListele(girisYapanCalisanId.Value)
                .Select(x => new PersonelIzinTalepViewModel
                {
                    Id = x.Id,
                    IzinBaslangicTarihi = x.IzinBaslangicTarihi,
                    IzinBitisTarihi = x.IzinBitisTarihi,
                    Aciklama = x.Aciklama,
                    TalepDurumu = x.TalepDurumu,
                    OnayTarihi = x.OnayTarihi,
                }).ToList();

            return View(izinTalepleri);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(IzinTalepCreateDTO dto)
        {
            var calisanId = HttpContext.Session.GetInt32("CalisanId");

            if (calisanId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            dto = dto with { CalisanId = calisanId.Value };

            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            _personelIzinServisi.IzinTalebiOlustur(dto);
            return RedirectToAction("Index");
        }
    }
}
