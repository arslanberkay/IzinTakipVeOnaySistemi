namespace IzinTakipVeOnaySistemi.UI.Middlewares
{
    //Amaç : Kullanıcının giriş yapıp yapmadığını kontrol etmek
    public class CalisanGirisKontrolAuthenticationMiddleware
    {
        private readonly RequestDelegate _next; //Sıradaki middleware'e geçişi temsil eder. 
        //Her middleware zincirde bir sonrakine isteği aktarır.
        //_next bu aktarımı sağlar

        //Her middleware bu yapıya sahip olmalıdır
        public CalisanGirisKontrolAuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        //Bu metodun içinde middleware'in çalışacağı kodlar yer alır
        //Tüm middleware'lerde Invoke veya InvokeAsync metodu olmak zorundadır.
        public async Task Invoke(HttpContext context) //HttpContext : Gelen HTTP isteği temsil eder
        {
            var path = context.Request.Path.Value.ToLower(); //İsteğin geldiği yol (/personel/index) alınır

            //Giriş yapılmadan da erişilebilecek sayfalar filtrelenir. Buralara gelen istekler kontrol edilmeden doğrudan sıradaki middleware'e gönderilir.
            if (path.StartsWith("/account/login") || path.StartsWith("/css") || path.StartsWith("/js"))
            {
                await _next(context);
                return;
            }

            if (context.Session.GetInt32("CalisanId") == null) //Oturumdaki CalisanId bilgisi yoksa kullanıcı login olmamıitır.
            {
                context.Response.Redirect("/Account/Login"); //Bu durumda login sayfasına yönlendirilir.
                return;
            }

            await _next(context);
        }
    }
}
