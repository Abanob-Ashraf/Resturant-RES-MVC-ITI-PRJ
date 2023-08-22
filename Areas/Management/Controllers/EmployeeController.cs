using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resturant_RES_MVC_ITI_PRJ.Areas.Management.Models;
using Resturant_RES_MVC_ITI_PRJ.Models.Repositories;

namespace Resturant_RES_MVC_ITI_PRJ.Areas.Management.Controllers
{
    [Area("Management")]
    //[Route("Employees")]
    public class EmployeeController : Controller
    {
        public IEmployeeRepository EmployeeRepository { get; }

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            EmployeeRepository = employeeRepository;
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
            return View();
        }

        [HttpPost]
        //[Route("CreateEmployee")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                EmployeeRepository.InsertEmployee(employee);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        //[Route("UpdateEmployee")]
        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        //[Route("UpdateEmployee")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                EmployeeRepository.UpdateEmployee(employee);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        //[Route("DeletEmployee")]
        public ActionResult Delete(int id)
        {
            return View();
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
