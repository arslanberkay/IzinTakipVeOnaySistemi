using IzinTakipVeOnaySistemi.UI.Filters;
using Microsoft.AspNetCore.Mvc;

namespace IzinTakipVeOnaySistemi.UI.Controllers
{
    [RolAuthorize("Finans")]
    public class FinansController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
