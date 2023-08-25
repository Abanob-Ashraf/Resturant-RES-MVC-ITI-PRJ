using Resturant_RES_MVC_ITI_PRJ.Models.ViewModels;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Resturant_RES_MVC_ITI_PRJ.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult NewRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NewRole(roleVM roleViewModel)
        {
            if (ModelState.IsValid)
            {
                //Mapping from roleViewModel to IdentityRole

                IdentityRole roleDbModel = new IdentityRole();
                roleDbModel.Name = roleViewModel.RoleName;
                
                //Save Role to DB
                IdentityResult result = await roleManager.CreateAsync(roleDbModel);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);  //Summary
                    }
                }
            }
            return View(roleViewModel);
        }

    }
}
