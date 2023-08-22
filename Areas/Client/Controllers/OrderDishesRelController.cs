using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resturant_RES_MVC_ITI_PRJ.Models.Repositories.Client;

namespace Resturant_RES_MVC_ITI_PRJ.Areas.Client.Controllers
{
    [Area("Client")]
    public class OrderDishesRelController : Controller
    {

        public IOrdersDishesRelRepository OrdersDishesRelRepository { get; }

        public OrderDishesRelController(IOrdersDishesRelRepository ordersDishesRelRepository)
        {
            OrdersDishesRelRepository = ordersDishesRelRepository;
        }
        //[Route("/GetAllTables")]
        public ActionResult Index()
        {
            return View("Index", OrdersDishesRelRepository.GetAllOrderDishesRels());
        }
        // GET: OrderDishesRelController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrderDishesRelController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderDishesRelController/Create
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

        // GET: OrderDishesRelController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderDishesRelController/Edit/5
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

        // GET: OrderDishesRelController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderDishesRelController/Delete/5
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
