using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Resturant_RES_MVC_ITI_PRJ.Areas.Client.Controllers
{
    public class DishIngredientsRelController : Controller
    {
        // GET: DishIngredientsRelController
        public ActionResult Index()
        {
            return View();
        }

        // GET: DishIngredientsRelController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DishIngredientsRelController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DishIngredientsRelController/Create
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

        // GET: DishIngredientsRelController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DishIngredientsRelController/Edit/5
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

        // GET: DishIngredientsRelController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DishIngredientsRelController/Delete/5
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
