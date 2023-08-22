using Microsoft.EntityFrameworkCore;
using Resturant_RES_MVC_ITI_PRJ.Models;
using Resturant_RES_MVC_ITI_PRJ.Models.RepoServices.Client;
using Resturant_RES_MVC_ITI_PRJ.Models.Repositories.Client;

namespace Resturant_RES_MVC_ITI_PRJ
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<ResturantDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            //builder.Services.Configure<MinDateOptions>(builder.Configuration.GetSection("MinimumDate"));

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
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapAreaControllerRoute(
                   name: "ClientArea",
                   areaName: "Client",
                   pattern: "{area}/{controller=HrHome}/{action=index}/{id?}"
               );
                endpoints.MapAreaControllerRoute(
                   name: "ManagementArea",
                   areaName: "Management",
                   pattern: "{area}/{controller=HrHome}/{action=index}/{id?}"
               );


            });

            app.Run();
        }
    }
}