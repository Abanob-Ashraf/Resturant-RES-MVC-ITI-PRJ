using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Resturant_RES_MVC_ITI_PRJ.Areas.Management.Models;
using Resturant_RES_MVC_ITI_PRJ.Models.Repositories;

namespace Resturant_RES_MVC_ITI_PRJ.Areas.Management.Controllers
{
    [Authorize(Roles = "Admin,Employee")]

    [Area("Management")]
    public class FranchiseController : Controller
    {
        public IEmployeeRepository EmployeeRepository { get; }
        public IFranchiseRepository FranchiseRepository { get; }

        public FranchiseController(IEmployeeRepository employeeRepository, IFranchiseRepository franchiseRepository)
        {
            EmployeeRepository = employeeRepository;
            FranchiseRepository = franchiseRepository;
        }

        public ActionResult Index()
        {
            return View("Index", FranchiseRepository.GetAllFranchises());
        }

        public ActionResult Details(int id)
        {
            return View("Details", FranchiseRepository.GetFranchiseById(id));
        }

        public ActionResult Create()
        {
            ViewBag.EmployeeList = new SelectList(EmployeeRepository.GetAllEmployees(), "EmpID", "EmpFirstName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Franchise franchise)
        {
            ViewBag.EmployeeList = new SelectList(EmployeeRepository.GetAllEmployees(), "EmpID", "EmpFirstName");

            if (franchise.ManagerId == 0)
            {
                ModelState.AddModelError("ManagerId", "This Franchise should have a manager");
            }
            if (ModelState.IsValid)
            {
                FranchiseRepository.InsertFranchise(franchise);

                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            ViewBag.EmployeeList = new SelectList(EmployeeRepository.GetAllEmployees(), "EmpID", "EmpFirstName");

            return View(FranchiseRepository.GetFranchiseById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Franchise franchise)
        {
            ViewBag.EmployeeList = new SelectList(EmployeeRepository.GetAllEmployees(), "EmpID", "EmpFirstName");

            if (ModelState.IsValid)
            {
                FranchiseRepository.UpdateFranchise(id, franchise);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            FranchiseRepository.DeleteFranchise(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
