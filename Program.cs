using Microsoft.EntityFrameworkCore;
using Resturant_RES_MVC_ITI_PRJ.Models;
using Resturant_RES_MVC_ITI_PRJ.Models.RepoServices.Client;
using Resturant_RES_MVC_ITI_PRJ.Models.RepoServices.Management;
using Resturant_RES_MVC_ITI_PRJ.Models.Repositories;
using Resturant_RES_MVC_ITI_PRJ.Models.Repositories.Client;
using Resturant_RES_MVC_ITI_PRJ.Models.Repositories.Management;

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

            //Client
            builder.Services.AddScoped<ICustomerRepository, CustomerRepoService>();
            builder.Services.AddScoped<ICustomerAdderssesRepository, CustomerAdderssesRepoService>();
            builder.Services.AddScoped<IDishRepository, DishRepoService>();
            builder.Services.AddScoped<IDishCategoryRepository, DishCategoryRepoService>();
            builder.Services.AddScoped<IDishIngredientRelRepository, DishIngredientsRelRepoService>();
            builder.Services.AddScoped<IIngerdientRepository, IngerdientRepoService>();
            builder.Services.AddScoped<IOrderRepository, OrderRepoService>();
            builder.Services.AddScoped<IOrderTypesRepository, OrderTypesRepoService>();
            builder.Services.AddScoped<IOrderesDishesRelRepository, OrderesDishesRelRepoService>();
            builder.Services.AddScoped<IReservationRepository, ReservationRepoService>();
            builder.Services.AddScoped<ITableRepository, TableRepoService>();
            builder.Services.AddScoped<ITestimonialsRepository, TestimonialsRepoService>();

            //Management
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepoService>();
            builder.Services.AddScoped<IEmployeeAddressRepository, EmployeeAddressRepoService>();
            builder.Services.AddScoped<IEmployeesCategoriesRepository, EmployeesCategoriesRepoService>();
            builder.Services.AddScoped<IFranchiseRepository, FranchiseRepoService>();

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

            app.MapAreaControllerRoute(
               name: "ClientArea",
               areaName: "Client",
               pattern: "{area}/{controller=Client}/{action=index}/{id?}");

            app.MapAreaControllerRoute(
               name: "ManagementArea",
               areaName: "Management",
               pattern: "{area}/{controller=Management}/{action=index}/{id?}");

            app.Run();
        }
    }
}