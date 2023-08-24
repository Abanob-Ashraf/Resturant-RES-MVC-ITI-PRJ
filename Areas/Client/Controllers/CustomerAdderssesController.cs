using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models;
using Resturant_RES_MVC_ITI_PRJ.Models.Repositories;
using Resturant_RES_MVC_ITI_PRJ.Models.Repositories.Client;

namespace Resturant_RES_MVC_ITI_PRJ.Areas.Client.Controllers
{
    [Area("Client")]
    //[Route("CustomerAddersse")]
    public class CustomerAdderssesController : Controller
    {
        public ICustomerRepository CustomerRepository { get; }
        public ICustomerAdderssesRepository CustomerAdderssesRepository { get; }

        public CustomerAdderssesController(ICustomerRepository customerRepository, ICustomerAdderssesRepository customerAdderssesRepository)
        {
            CustomerRepository = customerRepository;
            CustomerAdderssesRepository = customerAdderssesRepository;
        }

        //[Route("GetAllCustomerAddersses")]
        public ActionResult Index()
        {
            return View("Index", CustomerAdderssesRepository.GetAllCustomerAddersses());
        }

        //[Route("GetCustomerAdderssById/{id:int}")]
        public ActionResult Details(int id)
        {
            return View("Details", CustomerAdderssesRepository.GetCustomerAdderssById(id));
        }

        //[Route("CreateCustomerAdderss")]
        public ActionResult Create()
        {
            ViewBag.CustomerList = new SelectList(CustomerRepository.GetAllCustomers(), "CustID", "CustName");
            return View();
        }

        //[Route("CreateCustomerAdderss")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerAddersses customerAddersses)
        {
            ViewBag.CustomerList = new SelectList(CustomerRepository.GetAllCustomers(), "CustID", "CustName");

            if (ModelState.IsValid)
            {
                CustomerAdderssesRepository.InsertCustomerAdderss(customerAddersses);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        //[Route("UpdateCustomerAdderss/{id:int}")]
        public ActionResult Edit(int id)
        {
            ViewBag.CustomerList = new SelectList(CustomerRepository.GetAllCustomers(), "CustID", "CustName");

            return View(CustomerAdderssesRepository.GetCustomerAdderssById(id));
        }

        //[Route("UpdateCustomerAdderss/{id:int}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CustomerAddersses customerAddersses)
        {
            ViewBag.CustomerList = new SelectList(CustomerRepository.GetAllCustomers(), "CustID", "CustName");

            if (ModelState.IsValid)
            {
                CustomerAdderssesRepository.UpdateCustomerAdderss(id, customerAddersses);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        //[Route("DeletCustomerAdderss")]
        public ActionResult Delete(int id)
        {
            CustomerAdderssesRepository.DeleteCustomerAdderss(id);
            return RedirectToAction(nameof(Index));
        }

        // POST: CustomerAdderssesController/Delete/5
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
