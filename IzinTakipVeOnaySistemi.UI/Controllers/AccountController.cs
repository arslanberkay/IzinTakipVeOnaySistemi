using Azure.Core.GeoJson;
using IzinTakipVeOnaySistemi.BLL.DTO;
using IzinTakipVeOnaySistemi.BLL.Services.Interfaces;
using IzinTakipVeOnaySistemi.DAL.Enums;
using IzinTakipVeOnaySistemi.UI.Filters;
using IzinTakipVeOnaySistemi.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Frozen;

namespace IzinTakipVeOnaySistemi.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly ICalisanServisi _calisanServisi;
        private readonly IDepartmanServisi _departmanServisi;

        public AccountController(ICalisanServisi calisanServisi, IDepartmanServisi departmanServisi)
        {
            _calisanServisi = calisanServisi;
            _departmanServisi = departmanServisi;
        }

        public IActionResult Index()
        {
            var calisanlar = _calisanServisi.TumCalisanlariGetir()
                .Select(x => new CalisanListViewModel
                {
                    Id = x.Id,
                    Ad = x.Ad,
                    Soyad = x.Soyad,
                    Eposta = x.EpostaAdresi,
                    Rol = x.Rol,
                    IzinSayisi = x.IzinSayisi,
                    DepartmanId = x.DepartmanId,
                    DepartmanAdi = x.Departman.Ad,

                }).ToList();

            return View(calisanlar);
        }

        [HttpGet]
        public IActionResult Create()
        {
            //Departmanları departman servisinden aldım
            var departmanlar = _departmanServisi.DepartmanlariGetir()
                .Select(d => new SelectListItem
                {
                    Value = d.Id.ToString(),
                    Text = d.Ad
                }).ToList();

            //Rolleri enum'dan aldım
            var roller = Enum.GetValues(typeof(Rol))
                .Cast<Rol>()
                .Select(r => new SelectListItem
                {
                    Value = r.ToString(),
                    Text = r.ToString()
                }).ToList();

            //ViewBag ile gönderelim
            ViewBag.Departmanlar = departmanlar;
            ViewBag.Roller = roller;

            return View();
        }

        [HttpPost]
        [ValidateUniqueEmail]
        public IActionResult Create(CalisanCreateUpdateDTO dto)
        {
            if (!ModelState.IsValid)
            {
                var departmanlar = _departmanServisi.DepartmanlariGetir()
                    .Select(d => new SelectListItem
                    {
                        Value = d.Id.ToString(),
                        Text = d.Ad
                    }).ToList();


                var roller = Enum.GetValues(typeof(Rol))
                    .Cast<Rol>()
                    .Select(r => new SelectListItem
                    {
                        Value = r.ToString(),
                        Text = r.ToString()
                    }).ToList();
                return View(dto);
            }
            _calisanServisi.CalisanOlustur(dto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int calisanId)
        {
            var guncellenecekCalisan = _calisanServisi.TumCalisanlariGetir()
                .FirstOrDefault(x => x.Id == calisanId);

            if (guncellenecekCalisan == null)
            {
                return NotFound();
            }

            var dto = new CalisanCreateUpdateDTO
            {
                Id = calisanId,
                Ad = guncellenecekCalisan.Ad,
                Soyad = guncellenecekCalisan.Soyad,
                Eposta = guncellenecekCalisan.EpostaAdresi,
                Sifre = guncellenecekCalisan.Sifre,
                Rol = guncellenecekCalisan.Rol,
                DepartmanId = guncellenecekCalisan.DepartmanId
            };

            var departmanlar = _departmanServisi.DepartmanlariGetir()
                .Select(d => new SelectListItem
                {
                    Value = d.Id.ToString(),
                    Text = d.Ad,
                }).ToList();

            var roller = Enum.GetValues(typeof(Rol)) //Enum'daki tüm değerleri bir dizi olarak döndürür.
                .Cast<Rol>() //Diziyi Rol türüne dönüştürürüz
                .Select(r => new SelectListItem
                {
                    Value = r.ToString(),
                    Text = r.ToString()
                }).ToList();

            ViewBag.Departmanlar = departmanlar;
            ViewBag.Roller = roller;

            return View(dto);
        }

        [HttpPost]
        [ValidateUniqueEmail]
        public IActionResult Edit(int calisanId, CalisanCreateUpdateDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            _calisanServisi.CalisanGuncelle(calisanId, dto);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int calisanId)
        {
            var silinecekCalisan = _calisanServisi.TumCalisanlariGetir()
                .FirstOrDefault(c => c.Id == calisanId);

            if (silinecekCalisan != null)
            {
                _calisanServisi.CalisanSil(calisanId);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            var girisYapanCalisan = _calisanServisi.TumCalisanlariGetir()
                .FirstOrDefault(c => c.EpostaAdresi == loginViewModel.Eposta && c.Sifre == loginViewModel.Sifre);

            if (girisYapanCalisan == null)
            {
                ViewBag.Hata = "E-posta veya şifre hatalı!";
                return View(loginViewModel);
            }

            //Bu bilgiler sayesinde sistem giriş yapan çalışanı sistem kapanana kadar tutar
            HttpContext.Session.SetInt32("CalisanId", girisYapanCalisan.Id);
            HttpContext.Session.SetString("AdSoyad", girisYapanCalisan.TamAd);
            HttpContext.Session.SetString("Rol", girisYapanCalisan.Rol.ToString());

            return girisYapanCalisan.Rol switch
            {
                Rol.Personel => RedirectToAction("Index", "Personel"),
                Rol.IK => RedirectToAction("Index", "IK"),
                Rol.Finans => RedirectToAction("Index", "Finans"),
                _ => RedirectToAction("Login", "Account")
            };
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Clear(); //Oturum bilgileri temizlenir.
            return RedirectToAction("Login");
        }

    }
}
