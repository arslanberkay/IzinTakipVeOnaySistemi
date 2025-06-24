using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace IzinTakipVeOnaySistemi.UI.Filters
{
    //Projedeki her rol sadece kendi controllerına girebilmeli
    public class RolAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string _gerekliRol;

        public RolAuthorizeAttribute(string gerekliRol)
        {
            _gerekliRol = gerekliRol;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var rol = context.HttpContext.Session.GetString("Rol");

            if (rol == null || rol != _gerekliRol)
            {
                context.Result = new RedirectToActionResult("AccessDenied", "Account", null);
            }
        }
    }
}
