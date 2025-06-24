using IzinTakipVeOnaySistemi.BLL.DTO;
using IzinTakipVeOnaySistemi.BLL.Services.Interfaces;
using IzinTakipVeOnaySistemi.UI.Filters;
using IzinTakipVeOnaySistemi.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace IzinTakipVeOnaySistemi.UI.Controllers
{
    [RolAuthorize("Personel")]
    public class PersonelController : Controller
    {
        private readonly IPersonelIzinServisi _personelIzinServisi;

        public PersonelController(IPersonelIzinServisi personelIzinServisi)
        {
            _personelIzinServisi = personelIzinServisi;
        }

        //Giriş Yapan Çalışan Id parametresini döner
        private int? GetGirisYapanCalisanId()
        {
            return HttpContext.Session.GetInt32("CalisanId");
        }

        public IActionResult Index()
        {
            //Giriş yapan çalışanı bulalım
            var girisYapanCalisanId = GetGirisYapanCalisanId();

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
            var calisanId = GetGirisYapanCalisanId();

            dto.CalisanId = calisanId.Value;

            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            _personelIzinServisi.IzinTalebiOlustur(dto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var calisanId = GetGirisYapanCalisanId();

            var guncellenecekIzin = _personelIzinServisi.IzinTalepleriListele(calisanId.Value)
                .FirstOrDefault(t => t.Id == id);

            if (guncellenecekIzin == null)
            {
                return NotFound();
            }

            var dto = new IzinTalepUpdateDTO
            {
                BaslangicTarihi = guncellenecekIzin.IzinBaslangicTarihi,
                BitisTarihi = guncellenecekIzin.IzinBitisTarihi,
                Aciklama = guncellenecekIzin.Aciklama,
            };

            return View(dto);
        }

        [HttpPost]
        public IActionResult Edit(int id, IzinTalepUpdateDTO dto)
        {

            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            _personelIzinServisi.IzinTalepGuncelle(id, dto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var calisanId = GetGirisYapanCalisanId();
           
            var silinecekIzin = _personelIzinServisi
                .IzinTalepleriListele(GetGirisYapanCalisanId().Value)
                .FirstOrDefault(t => t.Id == id);

            if (silinecekIzin != null)
            {
                _personelIzinServisi.IzinTalepSil(id);
            }
            return RedirectToAction("Index");
        }


    }
}
