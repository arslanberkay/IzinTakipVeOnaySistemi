using IzinTakipVeOnaySistemi.BLL.DTO;
using IzinTakipVeOnaySistemi.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace IzinTakipVeOnaySistemi.UI.Filters
{
    public class ValidateUniqueEmail : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //Servisi alalım 
            var calisanServisi = (ICalisanServisi)context.HttpContext.RequestServices.GetService(typeof(ICalisanServisi));

            var form = context.ActionArguments["dto"] as CalisanCreateUpdateDTO; //formdaki alanları belirtir

            if (form != null)
            {
                var ayniEmailVarMi = calisanServisi.TumCalisanlariGetir()
                    .Any(c => c.EpostaAdresi == form.Eposta);

                if (ayniEmailVarMi)
                {
                    var controller = context.Controller as Controller;
                    controller.ModelState.AddModelError("Eposta", "Girilen e-posta adresi zaten kayıtlı!");

                    context.Result = controller.View(form);
                }
            }

            base.OnActionExecuting(context);
        }
    }
}
