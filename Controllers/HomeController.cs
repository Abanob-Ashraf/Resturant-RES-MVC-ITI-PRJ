using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resturant_RES_MVC_ITI_PRJ.Models;
using Resturant_RES_MVC_ITI_PRJ.Models.Repositories;
using System.Diagnostics;

namespace Resturant_RES_MVC_ITI_PRJ.Controllers
{
    public class HomeController : Controller
    {
        public IInitializeDefaultData InitializeDefaultData { get; }

        public HomeController(IInitializeDefaultData initializeDefaultData)
        {
            InitializeDefaultData = initializeDefaultData;
        }
        [Authorize(Roles = "Admin,Employee")]
        public async Task<IActionResult> AdminIndex()
        {
            if (User.IsInRole("Admin") || User.IsInRole("Employee"))
            {
                return View("DBindex");
            }
            return View("Index");
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            await InitializeDefaultData.Initialize_Data();

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}