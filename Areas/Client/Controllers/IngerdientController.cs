using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Resturant_RES_MVC_ITI_PRJ.Areas.Client.Controllers
{
    public class IngerdientController : Controller
    {
        // GET: IngerdientController
        public ActionResult Index()
        {
            return View();
        }

        // GET: IngerdientController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: IngerdientController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IngerdientController/Create
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

        // GET: IngerdientController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: IngerdientController/Edit/5
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

        // GET: IngerdientController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: IngerdientController/Delete/5
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
