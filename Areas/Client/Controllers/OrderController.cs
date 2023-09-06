using MailKit.Search;
using Microsoft.AspNetCore.Authorization;
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
    public class OrderController : Controller
    {
        public IOrderRepository OrderRepository { get; }
        public IOrderTypesRepository OrderTypeRepository { get; }
        public ICustomerRepository CustomerRepository { get; }
        public IFranchiseRepository FranchiseRepository { get; }
        public IDishRepository DishRepository { get; }

        public OrderController(IOrderRepository orderRepository,
            IOrderTypesRepository orderTypesRepository,
            ICustomerRepository customerRepository,
            IFranchiseRepository franchiseRepository,
            IDishRepository dishRepository
            )
        {
            OrderRepository = orderRepository;
            OrderTypeRepository = orderTypesRepository;
            CustomerRepository = customerRepository;
            FranchiseRepository = franchiseRepository;
            DishRepository = dishRepository;
        }

        public ActionResult Index()
        {
            ViewBag.OrdersLst = new SelectList(OrderTypeRepository.GetAllOrderTypes(), "OrderTypeId", "OrderTypeName");
            return View("Index", OrderRepository.GetAllOrders());
        }

        [HttpPost]
        public ActionResult Index(IFormCollection collection)
        {
            int OrderID = int.Parse(collection["OrderTypeId"]);
            ViewBag.OrdersLst = new SelectList(OrderTypeRepository.GetAllOrderTypes(), "OrderTypeId", "OrderTypeName", OrderID);

            return View(OrderRepository.GetAllOrders().Where(d => d.OrderTypeId == OrderID));
        }


        public ActionResult Cart()
        {
            return View(DishRepository.GetAllDishes());
        }

        public ActionResult Details(int id)
        {
            return View("Details", OrderRepository.GetOrderById(id));
        }

        public ActionResult Create()
        {
            ViewBag.OrderTypeList = new SelectList(OrderTypeRepository.GetAllOrderTypes(), "OrderTypeId", "OrderTypeName");
            ViewBag.CustomerList = new SelectList(CustomerRepository.GetAllCustomers(), "CustID", "FirstName");
            ViewBag.FranchiseList = new SelectList(FranchiseRepository.GetAllFranchises(), "FranchiseId", "City");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Order order)
        {
            ViewBag.OrderTypeList = new SelectList(OrderTypeRepository.GetAllOrderTypes(), "OrderTypeId", "OrderTypeName");
            ViewBag.CustomerList = new SelectList(CustomerRepository.GetAllCustomers(), "CustID", "FirstName");
            ViewBag.FranchiseList = new SelectList(FranchiseRepository.GetAllFranchises(), "FranchiseId", "City");

            if (ModelState.IsValid)
            {
                OrderRepository.InsertOrder(order);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            ViewBag.OrderTypeList = new SelectList(OrderTypeRepository.GetAllOrderTypes(), "OrderTypeId", "OrderTypeName");
            ViewBag.CustomerList = new SelectList(CustomerRepository.GetAllCustomers(), "CustID", "FirstName");
            ViewBag.FranchiseList = new SelectList(FranchiseRepository.GetAllFranchises(), "FranchiseId", "City");

            return View(OrderRepository.GetOrderById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Order order)
        {
            ViewBag.OrderTypeList = new SelectList(OrderTypeRepository.GetAllOrderTypes(), "OrderTypeId", "OrderTypeName");
            ViewBag.CustomerList = new SelectList(CustomerRepository.GetAllCustomers(), "CustID", "FirstName");
            ViewBag.FranchiseList = new SelectList(FranchiseRepository.GetAllFranchises(), "FranchiseId", "City");

            if (ModelState.IsValid)
            {
                OrderRepository.UpdateOrder(id, order);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            OrderRepository.DeleteOrder(id);
            return RedirectToAction(nameof(Index));
        }
    }
}