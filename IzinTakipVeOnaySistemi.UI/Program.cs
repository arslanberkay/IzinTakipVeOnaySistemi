
using IzinTakipVeOnaySistemi.BLL.Services.CRUDQueries;
using IzinTakipVeOnaySistemi.BLL.Services.Interfaces;
using IzinTakipVeOnaySistemi.DAL.Context;
using IzinTakipVeOnaySistemi.DAL.Repositories.Implementations;
using IzinTakipVeOnaySistemi.DAL.Repositories.Interfaces;
using IzinTakipVeOnaySistemi.UI.Filters;
using IzinTakipVeOnaySistemi.UI.Middlewares;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace IzinTakipVeOnaySistemi.UI

{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)
                .CreateLogger();

            builder.Services.AddDbContext<IzinTakipOnayDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Baglanti"))); //EF Core kullan�m� i�in DbContext s�n�f� projeye eklenir

            //Global filter
            builder.Services.AddControllersWithViews(options =>
            {
                options.Filters.Add<CalisanGirisKontrolAttribute>();
            });

            //Repo kay�tlar�
            builder.Services.AddScoped(typeof(ICalisanRepository<>), typeof(CalisanRepository<>));
            builder.Services.AddScoped(typeof(IFinansRepository<>), typeof(FinansRepository<>));
            builder.Services.AddScoped(typeof(IIKRepository<>), typeof(IKRepository<>));
            builder.Services.AddScoped(typeof(IOdemeBilgisiRepository<>), typeof(OdemeBilgisiRepository<>));
            builder.Services.AddScoped(typeof(IPersonelRepository<>), typeof(PersonelRepository<>));
            builder.Services.AddScoped(typeof(IDepartmanRepository<>), typeof(DepartmanRepository<>));

            //Service kay�tlar�
            builder.Services.AddScoped(typeof(ICalisanServisi), typeof(CalisanServisi));
            builder.Services.AddScoped(typeof(IFinansServisi), typeof(FinansServisi));
            builder.Services.AddScoped(typeof(IIKIzinServisi), typeof(IKIzinServisi));
            builder.Services.AddScoped(typeof(IPersonelIzinServisi), typeof(PersonelIzinServisi));
            builder.Services.AddScoped(typeof(IDepartmanServisi), typeof(DepartmanServisi));

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //Her controller'a [CalisanGirisKontrol] yazmak yerine global filter olarak tan�mlad�m. 
           

            builder.Services.AddSession();

            var app = builder.Build();

            

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseSession();

            app.UseMiddleware<RequestLogMiddleware>(); //Gelen her HTTP iste�inde �al��acak �ekilde araya girer.

            app.UseMiddleware<CalisanGirisKontrolAuthenticationMiddleware>();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Account}/{action=Login}/{id?}");

            app.Run();
        }
    }
}
