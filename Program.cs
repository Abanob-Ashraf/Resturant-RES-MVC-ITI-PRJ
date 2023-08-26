using Resturant_RES_MVC_ITI_PRJ.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Resturant_RES_MVC_ITI_PRJ.Models.RepoServices.Client;
using Resturant_RES_MVC_ITI_PRJ.Models.RepoServices.Management;
using Resturant_RES_MVC_ITI_PRJ.Models.Repositories;
using Resturant_RES_MVC_ITI_PRJ.Models.Repositories.Client;
using Resturant_RES_MVC_ITI_PRJ.Models.Repositories.Management;
using Resturant_RES_MVC_ITI_PRJ.Services;
using Resturant_RES_MVC_ITI_PRJ.Models.RepoServices.Analysis;
using Resturant_RES_MVC_ITI_PRJ.Models.Repositories.Analysis;

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

            builder.Services.AddAuthentication()
             .AddGoogle("google", opt =>
             {
                 var googleAuth = builder.Configuration.GetSection("Authentication:Google");
                 opt.ClientId = googleAuth["ClientId"];
                 opt.ClientSecret = googleAuth["ClientSecret"];
                 opt.SignInScheme = IdentityConstants.ExternalScheme;
             });

            // Identity
            builder.Services.AddIdentity<AppUser, IdentityRole>(opt =>
            {
                opt.Password.RequiredLength = 8;
                opt.Password.RequireDigit = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireNonAlphanumeric=false;
               // opt.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<ResturantDbContext>().AddDefaultTokenProviders();

            builder.Services.Configure<DataProtectionTokenProviderOptions>(opt => opt.TokenLifespan = TimeSpan.FromHours(2));

            var emailConfig = builder.Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>();

            builder.Services.AddSingleton(emailConfig);
            builder.Services.AddScoped<IEmailSender, EmailSender>();


            // Client
            builder.Services.AddScoped<ICustomerRepository, CustomerRepoService>();
            builder.Services.AddScoped<ICustomerAdderssesRepository, CustomerAdderssesRepoService>();
            builder.Services.AddScoped<IDishRepository, DishRepoService>();
            builder.Services.AddScoped<IDishCategoryRepository, DishCategoryRepoService>();
            builder.Services.AddScoped<IDishIngredientRelRepository, DishIngredientsRelRepoService>();
            builder.Services.AddScoped<IIngerdientRepository, IngerdientRepoService>();
            builder.Services.AddScoped<IOrderRepository, OrderRepoService>();
            builder.Services.AddScoped<IOrderTypesRepository, OrderTypesRepoService>();
            builder.Services.AddScoped<IOrdersDishesRelRepository, OrdersDishesRelRepoService>();
            builder.Services.AddScoped<IReservationRepository, ReservationRepoService>();
            builder.Services.AddScoped<ITableRepository, TableRepoService>();
            builder.Services.AddScoped<ITestimonialsRepository, TestimonialsRepoService>();

            // Management
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepoService>();
            builder.Services.AddScoped<IEmployeeAddressRepository, EmployeeAddressRepoService>();
            builder.Services.AddScoped<IEmployeesCategoriesRepository, EmployeesCategoriesRepoService>();
            builder.Services.AddScoped<IFranchiseRepository, FranchiseRepoService>();

            // Analysis
            builder.Services.AddScoped<IOrderAnalysis, OrderAnalysis>();

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
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapAreaControllerRoute(
              name: "ClientArea",
              areaName: "Client",
              pattern: "Client/{controller}/{action=index}/{id?}");

            app.MapAreaControllerRoute(
               name: "ManagementArea",
               areaName: "Management",
               pattern: "Management/{controller}/{action=index}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}