using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resturant_RES_MVC_ITI_PRJ.Models.Repositories;

namespace Resturant_RES_MVC_ITI_PRJ.Areas.Management.Controllers
{
    [Area("Client")]
    [Route("Employee")]
    public class EmployeeController : Controller
    {
        public IEmployeeRepository EmployeeRepository { get; }

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            EmployeeRepository = employeeRepository;
        }

        [Route("GetAllEmployees")]
        public ActionResult Index()
        {
            return View("Index", EmployeeRepository.GetAllEmployees());
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

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

        public ActionResult Edit(int id)
        {
            return View();
        }

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

        public ActionResult Delete(int id)
        {
            return View();
        }

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
