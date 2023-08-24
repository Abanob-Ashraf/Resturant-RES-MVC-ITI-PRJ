using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Resturant_RES_MVC_ITI_PRJ.Areas.Management.Models;
using Resturant_RES_MVC_ITI_PRJ.Models.Repositories;

namespace Resturant_RES_MVC_ITI_PRJ.Areas.Management.Controllers
{
    [Area("Management")]
    //[Route("Employees")]
    public class EmployeeController : Controller
    {
        public IEmployeeRepository EmployeeRepository { get; }
        public IEmployeesCategoriesRepository EmployeesCategoriesRepository { get; }
        public IFranchiseRepository FranchiseRepository { get; }

        public EmployeeController(IEmployeeRepository employeeRepository, IEmployeesCategoriesRepository employeesCategoriesRepository, IFranchiseRepository franchiseRepository)
        {
            EmployeeRepository = employeeRepository;
            EmployeesCategoriesRepository = employeesCategoriesRepository;
            FranchiseRepository = franchiseRepository;
        }

        //[Route("GetAllEmployees")]
        public ActionResult Index()
        {
            return View("Index", EmployeeRepository.GetAllEmployees());
        }

        //[Route("GetEmployeeById/{id:int}")]
        public ActionResult Details(int id)
        {
            return View("Details", EmployeeRepository.GetEmployeeById(id));
        }
        
        //[Route("CreateEmployee")]
        public ActionResult Create()
        {
            ViewBag.CategoryList = new SelectList(EmployeesCategoriesRepository.GetAllEmployeesCategories(), "EmployeeCategoryId", "CategoryName");
            ViewBag.FranchiseList = new SelectList(FranchiseRepository.GetAllFranchises(), "FranchiseId", "City");
            return View();
        }

        [HttpPost]
        //[Route("CreateEmployee")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            ViewBag.CategoryList = new SelectList(EmployeesCategoriesRepository.GetAllEmployeesCategories(), "EmployeeCategoryId", "CategoryName");
            ViewBag.FranchiseList = new SelectList(FranchiseRepository.GetAllFranchises(), "FranchiseId", "City");

            if (ModelState.IsValid)
            {
                EmployeeRepository.InsertEmployee(employee);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        //[Route("UpdateEmployee")]
        public ActionResult Edit(int id)
        {
            ViewBag.CategoryList = new SelectList(EmployeesCategoriesRepository.GetAllEmployeesCategories(), "EmployeeCategoryId", "CategoryName");
            ViewBag.FranchiseList = new SelectList(FranchiseRepository.GetAllFranchises(), "FranchiseId", "City");
            return View(EmployeeRepository.GetEmployeeById(id));
        }

        [HttpPost]
        //[Route("UpdateEmployee")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Employee employee)
        {
            ViewBag.CategoryList = new SelectList(EmployeesCategoriesRepository.GetAllEmployeesCategories(), "EmployeeCategoryId", "CategoryName");
            ViewBag.FranchiseList = new SelectList(FranchiseRepository.GetAllFranchises(), "FranchiseId", "City");

            if (ModelState.IsValid)
            {
                EmployeeRepository.UpdateEmployee(id, employee);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        //[Route("DeletEmployee")]
        public ActionResult Delete(int id)
        {
            EmployeeRepository.DeleteEmployee(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
