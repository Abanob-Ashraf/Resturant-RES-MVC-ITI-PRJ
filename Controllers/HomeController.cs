using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Resturant_RES_MVC_ITI_PRJ.Models;
using System.Diagnostics;

namespace Resturant_RES_MVC_ITI_PRJ.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public RoleManager<IdentityRole> RoleManager { get; }

        public HomeController(ILogger<HomeController> logger, RoleManager<IdentityRole> roleManager)
        {
            _logger = logger;
            RoleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            IdentityRole role1 = new IdentityRole();
            role1.Name = "Customer";
            IdentityRole role2 = new IdentityRole();
            role2.Name = "Admin";

            //Save Role to DB
             await RoleManager.CreateAsync(role1);
            await RoleManager.CreateAsync(role2);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}