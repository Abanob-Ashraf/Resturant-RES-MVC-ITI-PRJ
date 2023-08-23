using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models;
using Resturant_RES_MVC_ITI_PRJ.Areas.Management.Models;
using Resturant_RES_MVC_ITI_PRJ.Models.Repositories;
using Resturant_RES_MVC_ITI_PRJ.Models.Repositories.Client;

namespace Resturant_RES_MVC_ITI_PRJ.Areas.Client.Controllers
{
    [Area("Client")]
    //[Route("OrderType")]
    public class OrderTypeController : Controller
    {

        public IOrderTypesRepository OrderTypesRepository { get; }

        public OrderTypeController(IOrderTypesRepository orderTypesRepository)
        {
            OrderTypesRepository = orderTypesRepository;
        }
        //[Route("/GetAllTables")]
        public ActionResult Index()
        {
            return View("Index", OrderTypesRepository.GetAllOrderTypes());
        }
        //[Route("GetOrderTypeById/{id:int}")]
        public ActionResult Details(int id)
        {
            return View("Details", OrderTypesRepository.GetOrderTypeById(id));
        }

        //[Route("CreateOrderType")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //[Route("CreateOrderType")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderType orderType)
        {
            if (ModelState.IsValid)
            {
                OrderTypesRepository.InsertOrderType(orderType);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        //[Route("UpdateOrderType/{id:int}")]
        public ActionResult Edit(int id)
        {
            return View(OrderTypesRepository.GetOrderTypeById(id));
        }

        [HttpPost]
        //[Route("UpdateOrderType/{id:int}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, OrderType orderType)
        {
            if (ModelState.IsValid)
            {
                OrderTypesRepository.UpdateOrderType(orderType);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        //[Route("DeleteOrderType/{id:int}")]
        public ActionResult Delete(int id)
        {
            OrderTypesRepository.DeleteOrderType(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
