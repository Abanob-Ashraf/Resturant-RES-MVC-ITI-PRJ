﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models;
using Resturant_RES_MVC_ITI_PRJ.Areas.Management.Models;
using Resturant_RES_MVC_ITI_PRJ.Models.Repositories;
using Resturant_RES_MVC_ITI_PRJ.Models.Repositories.Client;

namespace Resturant_RES_MVC_ITI_PRJ.Areas.Client.Controllers
{
    [Area("Client")]
    public class CustomerController : Controller
    {
        public ICustomerRepository CustomerRepository { get; }

        public CustomerController(ICustomerRepository customerRepository)
        {
            CustomerRepository = customerRepository;
        }

        //[Route("GetAllCustomers")]
        public ActionResult Index()
        {
            return View("Index", CustomerRepository.GetAllCustomers());
        }

        //[Route("GetCustomerById/{id:int}")]
        public ActionResult Details(int id)
        {
            return View("Details", CustomerRepository.GetCustomerById(id));
        }

        //[Route("CreateCustomer")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //[Route("CreateCustomer")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                CustomerRepository.InsertCustomer(customer);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        //[Route("EditCustomer")]
        public ActionResult Edit(int id)
        {
            return View(CustomerRepository.GetCustomerById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                CustomerRepository.UpdateCustomer(customer);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            CustomerRepository.DeleteCustomer(id);
            return RedirectToAction(nameof(Index));
        }

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
