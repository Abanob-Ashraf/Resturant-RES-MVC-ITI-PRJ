using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models;
using Resturant_RES_MVC_ITI_PRJ.Models.Repositories.Client;

namespace Resturant_RES_MVC_ITI_PRJ.Areas.Client.Controllers
{
    [Area("Client")]
    public class DishCategoryController : Controller
    {
        public IDishCategoryRepository DishCategoryRepository { get; }

        public DishCategoryController(IDishCategoryRepository dishCategoryRepository)
        {
            DishCategoryRepository = dishCategoryRepository;
        }
        
        public ActionResult Index()
        {
            return View("Index", DishCategoryRepository.GetAllDishCategories());
        }
        // GET: OrderTypeController/Details/5
        public ActionResult Details(int id)
        {
            return View(DishCategoryRepository.GetDishCategoryById(id));
        }

        // GET: OrderTypeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DishCategory dishCategory)
        {
            if (ModelState.IsValid)
            {
                DishCategoryRepository.InsertDishCategory(dishCategory);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: OrderTypeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(DishCategoryRepository.GetDishCategoryById(id));
        }

        // POST: OrderTypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DishCategory dishCategory)
        {
            if (ModelState.IsValid)
            {
                DishCategoryRepository.UpdateDishCategory(dishCategory);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: OrderTypeController/Delete/5
        public ActionResult Delete(int id)
        {
            DishCategoryRepository.DeleteDishCategory(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
