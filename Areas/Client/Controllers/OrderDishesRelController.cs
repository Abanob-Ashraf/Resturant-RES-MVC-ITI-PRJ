using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models;
using Resturant_RES_MVC_ITI_PRJ.Areas.Management.Models;
using Resturant_RES_MVC_ITI_PRJ.Models.Repositories;
using Resturant_RES_MVC_ITI_PRJ.Models.Repositories.Client;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Resturant_RES_MVC_ITI_PRJ.Areas.Client.Controllers
{
    [Area("Client")]
    public class OrderDishesRelController : Controller
    {

        public IOrdersDishesRelRepository OrderDishesRelRepository { get; }
        public IOrderRepository OrderRepository { get; }
        public IDishRepository DishRepository { get; }

        public OrderDishesRelController(IOrdersDishesRelRepository ordersDishesRelRepository, IOrderRepository orderRepository, IDishRepository dishRepository)
        {
            OrderDishesRelRepository = ordersDishesRelRepository;
            OrderRepository = orderRepository;
            DishRepository = dishRepository;
        }

        public ActionResult Index()
        {
            return View("Index", OrderDishesRelRepository.GetAllOrderDishesRels());
        }
        public ActionResult OrderDishesApi(int id)
        {
            var dishs = OrderDishesRelRepository.GetAllOrderDishesRels().Where(e => e.OrderId == id).Select(o => new { orderid = o.OrderId, dishes = o.Dish, quantity = o.Quantity });
            var jsonOptions = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            };
            var serializedDishes = JsonSerializer.Serialize(dishs, jsonOptions);

            return new ContentResult
            {
                Content = serializedDishes,
                ContentType = "application/json"
            };
        }

        public ActionResult Details(int id)
        {
            return View("Details", OrderDishesRelRepository.GetOrderDishesRelById(id));
        }

        public ActionResult Create()
        {
            ViewBag.OrderList = new SelectList(OrderRepository.GetAllOrders(), "OrderId", "OrderState");
            ViewBag.DishList = new SelectList(DishRepository.GetAllDishes(), "DishId", "DishName");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderDishesRel orderDishesRel)
        {
            ViewBag.OrderList = new SelectList(OrderRepository.GetAllOrders(), "OrderId", "OrderState");
            ViewBag.DishList = new SelectList(DishRepository.GetAllDishes(), "DishId", "DishName");

            if (ModelState.IsValid)
            {
                OrderDishesRelRepository.InsertOrderDishesRel(orderDishesRel);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            ViewBag.OrderList = new SelectList(OrderRepository.GetAllOrders(), "OrderId", "OrderState");
            ViewBag.DishList = new SelectList(DishRepository.GetAllDishes(), "DishId", "DishImageName");
            return View(OrderDishesRelRepository.GetOrderDishesRelById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, OrderDishesRel orderDishesRel)
        {
            ViewBag.OrderList = new SelectList(OrderRepository.GetAllOrders(), "OrderId", "OrderState");
            ViewBag.DishList = new SelectList(DishRepository.GetAllDishes(), "DishId", "DishImageName");

            if (ModelState.IsValid)
            {
                OrderDishesRelRepository.UpdateOrderDishesRel(id, orderDishesRel);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            OrderDishesRelRepository.DeleteOrderDishesRel(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
