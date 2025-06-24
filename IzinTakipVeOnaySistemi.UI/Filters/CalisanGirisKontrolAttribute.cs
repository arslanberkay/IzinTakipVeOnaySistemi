using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace IzinTakipVeOnaySistemi.UI.Filters
{
    public class CalisanGirisKontrolAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //Kullanıcının hangi controller ve action'a gittiği bilgisini alırız
            var controller = context.RouteData.Values["controller"]?.ToString();
            var action = context.RouteData.Values["action"]?.ToString();

            //Login ve Account sayfalarında filtre devre dışı bırakılır
            if (controller == "Account" && (action == "Login" || action == "AccessDenied"))
            {
                return;
            }

            var calisanId = context.HttpContext.Session.GetInt32("CalisanId");

            if (calisanId == null)
            {
                context.Result = new RedirectToActionResult("Login", "Account", null);
            }
        }
    }
}
