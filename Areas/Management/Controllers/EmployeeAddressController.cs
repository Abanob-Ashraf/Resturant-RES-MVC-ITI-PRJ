using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Resturant_RES_MVC_ITI_PRJ.Areas.Management.Models;
using Resturant_RES_MVC_ITI_PRJ.Models.Repositories;
using Resturant_RES_MVC_ITI_PRJ.Models.Repositories.Management;

namespace Resturant_RES_MVC_ITI_PRJ.Areas.Management.Controllers
{
    [Area("Management")]
    //[Route("EmployeeAddress")]
    public class EmployeeAddressController : Controller
    {
        public IEmployeeRepository EmployeeRepository { get; }
        public IEmployeeAddressRepository EmployeeAddressRepository { get; }

        public EmployeeAddressController(IEmployeeRepository employeeRepository, IEmployeeAddressRepository employeeAddressRepository)
        {
            EmployeeRepository = employeeRepository;
            EmployeeAddressRepository = employeeAddressRepository;
        }

        //[Route("GetAllEmployeeAddress")]
        public ActionResult Index()
        {
            return View("Index", EmployeeAddressRepository.GetAllEmployeesAddress());
        }

        //[Route("GetEmployeeAddressById/{id:int}")]
        public ActionResult Details(int id)
        {
            return View("Details", EmployeeAddressRepository.GetEmployeeAddressById(id));
        }

        //[Route("CreateEmployeeAddress")]
        public ActionResult Create()
        {
            ViewBag.EmployeeList = new SelectList(EmployeeRepository.GetAllEmployees(), "EmpID", "EmpFirstName");
            return View();
        }

        //[Route("CreateEmployeeAddress")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeAddress employeeAddress)
        {
            ViewBag.EmployeeList = new SelectList(EmployeeRepository.GetAllEmployees(), "EmpID", "EmpFirstName");

            if (ModelState.IsValid)
            {
                EmployeeAddressRepository.InsertEmployeeAddress(employeeAddress);

                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        //[Route("UpdateEmployeeAddress/{id:int}")]
        public ActionResult Edit(int id)
        {
            ViewBag.EmployeeList = new SelectList(EmployeeRepository.GetAllEmployees(), "EmpID", "EmpFirstName");
            return View(EmployeeAddressRepository.GetEmployeeAddressById(id));
        }

        //[Route("UpdateEmployeeAddress/{id:int}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EmployeeAddress employeeAddress)
        {
            ViewBag.EmployeeList = new SelectList(EmployeeRepository.GetAllEmployees(), "EmpID", "EmpFirstName");

            if (ModelState.IsValid)
            {
                EmployeeAddressRepository.UpdateEmployeeAddress(id, employeeAddress);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        //[Route("DeletEmployeeAddress/{id:int}")]
        public ActionResult Delete(int id)
        {
            EmployeeAddressRepository.DeleteEmployeeAddress(id);
            return RedirectToAction(nameof(Index));
        }

        // POST: EmployeeAddressController/Delete/5
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
