using IzinTakipVeOnaySistemi.UI.Filters;
using Microsoft.AspNetCore.Mvc;

namespace IzinTakipVeOnaySistemi.UI.Controllers
{
    [RolAuthorize("IK")]
    public class IKController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
