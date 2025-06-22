using IzinTakipVeOnaySistemi.BLL.DTO;
using IzinTakipVeOnaySistemi.BLL.Services.Interfaces;
using IzinTakipVeOnaySistemi.DAL.Enums;
using IzinTakipVeOnaySistemi.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
    }
}
