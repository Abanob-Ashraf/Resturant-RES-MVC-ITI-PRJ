using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resturant_RES_MVC_ITI_PRJ.Areas.Management.Models;
using Resturant_RES_MVC_ITI_PRJ.Models.Repositories;

namespace Resturant_RES_MVC_ITI_PRJ.Areas.Management.Controllers
{
    [Authorize(Roles = "Admin,Employee")]

    [Area("Management")]
    public class EmployeesCategoriesController : Controller
    {
        public IEmployeesCategoriesRepository EmployeesCategoriesRepository { get; }

        public EmployeesCategoriesController(IEmployeesCategoriesRepository employeesCategoriesRepository)
        {
            EmployeesCategoriesRepository = employeesCategoriesRepository;
        }

        public ActionResult Index()
        {
            return View("Index", EmployeesCategoriesRepository.GetAllEmployeesCategories());
        }

        public ActionResult Details(int id)
        {
            return View("Details", EmployeesCategoriesRepository.GetEmployeesCategoryById(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeCategory employeeCategory)
        {
            if (ModelState.IsValid)
            {
                EmployeesCategoriesRepository.InsertEmployeesCategory(employeeCategory);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            return View(EmployeesCategoriesRepository.GetEmployeesCategoryById(id));

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmployeeCategory employeeCategory)
        {
            if (ModelState.IsValid)
            {
                EmployeesCategoriesRepository.UpdateEmployeesCategory(employeeCategory);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            EmployeesCategoriesRepository.DeleteEmployeesCategory(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
