using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resturant_RES_MVC_ITI_PRJ.Areas.Management.Models;
using Resturant_RES_MVC_ITI_PRJ.Models.Repositories;

namespace Resturant_RES_MVC_ITI_PRJ.Areas.Management.Controllers
{
    [Area("Management")]
    //[Route("EmployeesCategory")]
    public class EmployeesCategoriesController : Controller
    {
        public IEmployeesCategoriesRepository EmployeesCategoriesRepository { get; }

        public EmployeesCategoriesController(IEmployeesCategoriesRepository employeesCategoriesRepository)
        {
            EmployeesCategoriesRepository = employeesCategoriesRepository;
        }

        //[Route("GetAllCategories")]
        public ActionResult Index()
        {
            return View("Index", EmployeesCategoriesRepository.GetAllEmployeesCategories());
        }

        //[Route("GetCategoriesById/{id:int}")]
        public ActionResult Details(int id)
        {
            return View("Details", EmployeesCategoriesRepository.GetEmployeesCategoryById(id));
        }

        //[Route("CreateEmployeeCategory")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //[Route("CreateEmployeeCategory")]
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

        //[Route("UpdateEmployeeCategory")]
        public ActionResult Edit(int id)
        {
            return View(EmployeesCategoriesRepository.GetEmployeesCategoryById(id));

        }

        [HttpPost]
        //[Route("UpdateEmployeeCategory")]
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

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
