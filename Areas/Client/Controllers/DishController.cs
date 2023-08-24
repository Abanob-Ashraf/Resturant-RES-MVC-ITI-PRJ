using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models;
using Resturant_RES_MVC_ITI_PRJ.Models.Repositories.Client;

namespace Resturant_RES_MVC_ITI_PRJ.Areas.Client.Controllers
{
    [Area("Client")]
    //[Route("Customer")]
    public class DishController : Controller
    {
        public IDishRepository DishRepository { get; }

        public IDishCategoryRepository CategoryRepository { get; }

        public DishController(IDishRepository dishRepository, IDishCategoryRepository dishCategoryRepository)
        {
            DishRepository = dishRepository;
            CategoryRepository = dishCategoryRepository;
        }

        public ActionResult Index()
        {
            return View("Index", DishRepository.GetAllDishes());
        }

        public ActionResult Details(int id)
        {
            return View("Details", DishRepository.GetDishById(id));
        }

        public ActionResult Create()
        {
            ViewBag.CategoryList = new SelectList(CategoryRepository.GetAllDishCategories(), "DishCategoryId", "DishCategoryName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Dish dish)
        {
            ViewBag.CategoryList = new SelectList(CategoryRepository.GetAllDishCategories(), "DishCategoryId", "DishCategoryName");

            if (ModelState.IsValid)
            {
                DishRepository.InsertDish(dish);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            ViewBag.CategoryList = new SelectList(CategoryRepository.GetAllDishCategories(), "DishCategoryId", "DishCategoryName");

            return View(DishRepository.GetDishById(id));
        }

        // POST: DishController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Dish dish)
        {
            ViewBag.CategoryList = new SelectList(CategoryRepository.GetAllDishCategories(), "DishCategoryId", "DishCategoryName");

            if (ModelState.IsValid)
            {
                DishRepository.UpdateDish(id, dish);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: DishController/Delete/5
        public ActionResult Delete(int id)
        {
            DishRepository.DeleteDish(id);
            return RedirectToAction(nameof(Index));
        }

        // POST: DishController/Delete/5
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
