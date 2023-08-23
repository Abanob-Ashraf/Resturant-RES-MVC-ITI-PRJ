using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Resturant_RES_MVC_ITI_PRJ.Areas.Client.Controllers
{
    public class CustomerAdderssesController : Controller
    {
        // GET: CustomerAdderssesController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CustomerAdderssesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomerAdderssesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerAdderssesController/Create
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

        // GET: CustomerAdderssesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomerAdderssesController/Edit/5
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

        // GET: CustomerAdderssesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerAdderssesController/Delete/5
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
