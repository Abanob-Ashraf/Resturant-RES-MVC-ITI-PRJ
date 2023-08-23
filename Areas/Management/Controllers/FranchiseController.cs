using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resturant_RES_MVC_ITI_PRJ.Models.Repositories;

namespace Resturant_RES_MVC_ITI_PRJ.Areas.Management.Controllers
{
    [Area("Management")]
    //[Route("Franchise")]
    public class FranchiseController : Controller
    {
        public IEmployeeRepository EmployeeRepository { get; }
        public IFranchiseRepository FranchiseRepository { get; }

        public FranchiseController(IEmployeeRepository employeeRepository,  IFranchiseRepository franchiseRepository)
        {
            EmployeeRepository = employeeRepository;
            FranchiseRepository = franchiseRepository;
        }

        //[Route("GetAllFranchise")]
        public ActionResult Index()
        {
            return View();
        }

        // GET: FranchiseController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FranchiseController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FranchiseController/Create
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

        // GET: FranchiseController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FranchiseController/Edit/5
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

        // GET: FranchiseController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FranchiseController/Delete/5
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
