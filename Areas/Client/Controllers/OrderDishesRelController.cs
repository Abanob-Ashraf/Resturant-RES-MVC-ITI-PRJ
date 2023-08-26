using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models;
using Resturant_RES_MVC_ITI_PRJ.Areas.Management.Models;
using Resturant_RES_MVC_ITI_PRJ.Models.Repositories;
using Resturant_RES_MVC_ITI_PRJ.Models.Repositories.Client;

namespace Resturant_RES_MVC_ITI_PRJ.Areas.Client.Controllers
{
    [Area("Client")]
    //[Route("OrderDishesRel")]
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
        //[Route("/GetAllTables")]
        public ActionResult Index()
        {
            return View("Index", OrderDishesRelRepository.GetAllOrderDishesRels());
        }
        //[Route("GetOrderDishesRelById/{id:int}")]
        public ActionResult Details(int id)
        {
            return View("Details", OrderDishesRelRepository.GetOrderDishesRelById(id));
        }

        //[Route("CreateOrderDishesRel")]
        public ActionResult Create()
        {
            ViewBag.OrderList = new SelectList(OrderRepository.GetAllOrders(), "OrderId", "OrderState");
            ViewBag.DishList = new SelectList(DishRepository.GetAllDishes(), "DishId", "DishImageName");


            return View();
        }

        [HttpPost]
        //[Route("CreateOrderDishesRel")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderDishesRel orderDishesRel)
        {
            ViewBag.OrderList = new SelectList(OrderRepository.GetAllOrders(), "OrderId", "OrderState");
            ViewBag.DishList = new SelectList(DishRepository.GetAllDishes(), "DishId", "DishImageName");

            if (ModelState.IsValid)
            {
                OrderDishesRelRepository.InsertOrderDishesRel(orderDishesRel);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        //[Route("UpdateOrderDishesRel")]
        public ActionResult Edit(int id)
        {
            ViewBag.OrderList = new SelectList(OrderRepository.GetAllOrders(), "OrderId", "OrderState");
            ViewBag.DishList = new SelectList(DishRepository.GetAllDishes(), "DishId", "DishImageName");
            return View(OrderDishesRelRepository.GetOrderDishesRelById(id));
        }

        [HttpPost]
        //[Route("UpdateOrderDishesRel")]
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

        //[Route("DeletOrderDishesRel")]
        public ActionResult Delete(int id)
        {
            OrderDishesRelRepository.DeleteOrderDishesRel(id);
            return RedirectToAction(nameof(Index));
        }

       
    }
}
