using IzinTakipVeOnaySistemi.BLL.DTO;
using IzinTakipVeOnaySistemi.BLL.Services.Interfaces;
using IzinTakipVeOnaySistemi.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace IzinTakipVeOnaySistemi.UI.Controllers
{
    public class DepartmanController : Controller
    {
        private readonly IDepartmanServisi _departmanServisi;

        public DepartmanController(IDepartmanServisi departmanServisi)
        {
            _departmanServisi = departmanServisi;
        }

        public IActionResult Index()
        {
            var departmanlar = _departmanServisi.DepartmanlariGetir()
                .Select(d => new DepartmanListViewModel
                {
                    Id = d.Id,
                    Ad = d.Ad,
                }).ToList();

            return View(departmanlar);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DepartmanCreateUpdateDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            _departmanServisi.DepartmanOlustur(dto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {

            var duzenlenecekDepartman = _departmanServisi.DepartmanlariGetir()
                .Where(d => d.Id == id)
                .FirstOrDefault();

            if (duzenlenecekDepartman == null)
            {
                return NotFound();
            }

            var dto = new DepartmanCreateUpdateDTO
            {
                Ad = duzenlenecekDepartman.Ad,
            };

            return View(dto);
        }

        [HttpPost]
        public IActionResult Edit(int id, DepartmanCreateUpdateDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            _departmanServisi.DepartmanGuncelle(id, dto);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var silinecekDepartman = _departmanServisi.DepartmanlariGetir()
                .FirstOrDefault(d => d.Id == id);

            if (silinecekDepartman != null)
            {
                _departmanServisi.DepartmanSil(id);

            }

            return RedirectToAction(nameof(Index));
        }
    }
}
