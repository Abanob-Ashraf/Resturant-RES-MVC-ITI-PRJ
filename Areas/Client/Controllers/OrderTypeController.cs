using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models;
using Resturant_RES_MVC_ITI_PRJ.Areas.Management.Models;
using Resturant_RES_MVC_ITI_PRJ.Models.Repositories;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models;
using Resturant_RES_MVC_ITI_PRJ.Models.Repositories.Client;

namespace Resturant_RES_MVC_ITI_PRJ.Areas.Client.Controllers
{
    [Area("Client")]
    public class OrderTypeController : Controller
    {
        public IOrderTypesRepository OrderTypesRepository { get; }

        public OrderTypeController(IOrderTypesRepository orderTypesRepository)
        {
            OrderTypesRepository = orderTypesRepository;
        }

        public ActionResult Index()
        {
            return View("Index", OrderTypesRepository.GetAllOrderTypes());
        }

        public ActionResult Details(int id)
        {
            return View("Details", OrderTypesRepository.GetOrderTypeById(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
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

        public ActionResult Edit(int id)
        {
            return View(OrderTypesRepository.GetOrderTypeById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OrderType orderType)
        {
            if (ModelState.IsValid)
            {
                OrderTypesRepository.UpdateOrderType(orderType);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            OrderTypesRepository.DeleteOrderType(id);
            return RedirectToAction(nameof(Index));
        }
    }
}