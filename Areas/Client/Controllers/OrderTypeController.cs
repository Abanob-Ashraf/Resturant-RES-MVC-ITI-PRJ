using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        //[Route("/GetAllTables")]
        public ActionResult Index()
        {
            return View("Index", OrderTypesRepository.GetAllOrderTypes());
        }
        // GET: OrderTypeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrderTypeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderTypeController/Create
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

        // GET: OrderTypeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderTypeController/Edit/5
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

        // GET: OrderTypeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderTypeController/Delete/5
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
