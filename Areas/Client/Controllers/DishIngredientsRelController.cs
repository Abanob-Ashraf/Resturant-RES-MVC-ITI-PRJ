using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models;
using Resturant_RES_MVC_ITI_PRJ.Models.Repositories.Client;

namespace Resturant_RES_MVC_ITI_PRJ.Areas.Client.Controllers
{
    [Area("Client")]
    //[Route("Customer")]
    public class DishIngredientsRelController : Controller
    {
        public IDishIngredientRelRepository RelRepository { get; }
        public IDishRepository DishRepository { get; }
        public IIngerdientRepository IngerdientRepository { get; }

        public DishIngredientsRelController(IDishIngredientRelRepository relRepository, IDishRepository dishRepository, IIngerdientRepository ingerdientRepository)
        {
            RelRepository = relRepository;
            DishRepository = dishRepository;
            IngerdientRepository = ingerdientRepository;
        }

        public ActionResult Index()
        {
            return View("Index", RelRepository.GetAllDishIngredientRels());
        }

        public ActionResult Details(int id)
        {
            return View("Details", RelRepository.GetDishIngredientRelById(id));
        }

        // GET: DishIngredientsRelController/Create
        public ActionResult Create()
        {
            ViewBag.DishList = new SelectList(DishRepository.GetAllDishes(), "DishId", "DishName");
            ViewBag.IngerdientList = new SelectList(IngerdientRepository.GetAllIngerdients(), "IngerdientId", "IngName");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DishIngredientRel dishIngredientRel)
        {
            var routeValues = new RouteValueDictionary(new { id = dishIngredientRel.DishId });

            ViewBag.DishList = new SelectList(DishRepository.GetAllDishes(), "DishId", "DishName");
            ViewBag.IngerdientList = new SelectList(IngerdientRepository.GetAllIngerdients(), "IngerdientId", "IngName");

            if (ModelState.IsValid)
            {
                RelRepository.InsertDishIngredientRel(dishIngredientRel);
                return RedirectToAction("Details", "Dish", routeValues);
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            ViewBag.DishList = new SelectList(DishRepository.GetAllDishes(), "DishId", "DishName");
            ViewBag.IngerdientList = new SelectList(IngerdientRepository.GetAllIngerdients(), "IngerdientId", "IngName");

            return View(RelRepository.GetDishIngredientRelById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DishIngredientRel dishIngredientRel)
        {
            ViewBag.DishList = new SelectList(DishRepository.GetAllDishes(), "DishId", "DishName");
            ViewBag.IngerdientList = new SelectList(IngerdientRepository.GetAllIngerdients(), "IngerdientId", "IngName");

            if (ModelState.IsValid)
            {
                RelRepository.UpdateDishIngredientRel(id, dishIngredientRel);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public ActionResult Delete(int id, int DishID)
        {
            var routeValues = new RouteValueDictionary(new { id = DishID });

            RelRepository.DeleteDishIngredientRel(id);
            return RedirectToAction("Details", "Dish", routeValues);
        }


    }
}
