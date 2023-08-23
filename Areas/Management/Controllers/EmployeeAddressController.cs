using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        //[Route("GetAllFranchise")]
        public ActionResult Index()
        {
            return View();
        }

        // GET: EmployeeAddressController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmployeeAddressController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeAddressController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeAddressController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmployeeAddressController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeAddressController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeeAddressController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
