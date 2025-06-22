
using IzinTakipVeOnaySistemi.BLL.Services.CRUDQueries;
using IzinTakipVeOnaySistemi.BLL.Services.Interfaces;
using IzinTakipVeOnaySistemi.DAL.Context;
using IzinTakipVeOnaySistemi.DAL.Repositories.Implementations;
using IzinTakipVeOnaySistemi.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IzinTakipVeOnaySistemi.UI

{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<IzinTakipOnayDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Baglanti"))); //EF Core kullanýmý için DbContext sýnýfý projeye eklenir

            //Repo kayýtlarý
            builder.Services.AddScoped(typeof(ICalisanRepository<>), typeof(CalisanRepository<>));
            builder.Services.AddScoped(typeof(IFinansRepository<>), typeof(FinansRepository<>));
            builder.Services.AddScoped(typeof(IIKRepository<>), typeof(IKRepository<>));
            builder.Services.AddScoped(typeof(IOdemeBilgisiRepository<>), typeof(OdemeBilgisiRepository<>));
            builder.Services.AddScoped(typeof(IPersonelRepository<>), typeof(PersonelRepository<>));
            builder.Services.AddScoped(typeof(IDepartmanRepository<>), typeof(DepartmanRepository<>));

            //Service kayýtlarý
            builder.Services.AddScoped(typeof(ICalisanServisi), typeof(CalisanServisi));
            builder.Services.AddScoped(typeof(IFinansServisi), typeof(FinansServisi));
            builder.Services.AddScoped(typeof(IIKIzinServisi), typeof(IKIzinServisi));
            builder.Services.AddScoped(typeof(IPersonelIzinServisi), typeof(PersonelIzinServisi));
            builder.Services.AddScoped(typeof(IDepartmanServisi), typeof(DepartmanServisi));

            // Add services to the container.
            builder.Services.AddControllersWithViews();



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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
