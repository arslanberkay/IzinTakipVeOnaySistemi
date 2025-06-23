using Serilog;

namespace IzinTakipVeOnaySistemi.UI.Middlewares
{
    //Uygulamada yapılan her isteği loglamak için yazılmıştır.
    //Kullanıcı tarayıcıdan istekte bulunduğunda bu middleware çalışır isteği kim yapmış, IP'si ne, hangi yolla erişmiş gibi bilgileri Serilog aracılığıyla dosyaya yazar
    public class RequestLogMiddleware
    {
        private readonly RequestDelegate _next; //Pipeline'daki bir sonraki middleware
        private readonly ILogger<RequestLogMiddleware> _logger; //Microsoft'un ILogger servisi

        public RequestLogMiddleware(RequestDelegate next, ILogger<RequestLogMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var kullanici = context.Session.GetString("AdSoyad") ?? "Bilinmeyen Kullanıcı";
            var rol = context.Session.GetString("Rol") ?? string.Empty;

            var ip = context.Connection.RemoteIpAddress;

            var yol = context.Request.Path;

            var zaman = DateTime.Now.ToString("yyyy.MM.dd  HH:mm:ss");

            var bilgi = $"Kullanıcı:{kullanici}| Rol:{rol}| IP:{ip}| Yol:{yol}| Zaman:{zaman} \n";

            Log.Information(bilgi); //Log dosyasına kayıt atılır.

            await _next(context); //Bu middleware görevi bittikten sonra isteği pipeline'daki sıradaki middleware'e devreder.
        }


    }
}
