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
    public class TestimonialsController : Controller
    {
        public ITestimonialsRepository TestimonialsRepository { get; }
        public ICustomerRepository CustomerRepository { get; }

        public TestimonialsController(ITestimonialsRepository testimonialsRepository,ICustomerRepository customerRepository)
        {
            TestimonialsRepository = testimonialsRepository;
            CustomerRepository = customerRepository;
        }
      
        public ActionResult Index()
        {
            return View("Index", TestimonialsRepository.GetAllTestimonials());
        }

        // GET: TestimonialsController/Details/5
        public ActionResult Details(int id)
        {
            return View("Details",TestimonialsRepository.GetTestimonialsById(id));
        }

        // GET: TestimonialsController/Create
        public ActionResult Create()
        {
            ViewBag.CustomerList = new SelectList(CustomerRepository.GetAllCustomers(), "CustID", "CustName");

            return View();
        }

        // POST: TestimonialsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Testimonials testimonial)
        {
            ViewBag.CustomerList = new SelectList(CustomerRepository.GetAllCustomers(), "CustID", "CustName");

            if (ModelState.IsValid)
                {
                    TestimonialsRepository.InsertTestimonials(testimonial);
                    return RedirectToAction(nameof(Index));
                }
                return View();
                       
        }

        // GET: TestimonialsController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.CustomerList = new SelectList(CustomerRepository.GetAllCustomers(), "CustID", "CustName");

            return View(TestimonialsRepository.GetTestimonialsById(id));
        }

        // POST: TestimonialsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Testimonials testimonial)
        {
            ViewBag.CustomerList = new SelectList(CustomerRepository.GetAllCustomers(), "CustID", "CustName");

            if (ModelState.IsValid)
                {
                    TestimonialsRepository.UpdateTestimonials(id,testimonial);
                    return RedirectToAction(nameof(Index));
                }
                return View();
           
        }

        // GET: TestimonialsController/Delete/5
        public ActionResult Delete(int id)
        {
            TestimonialsRepository.DeleteTestimonials(id);
            return RedirectToAction(nameof(Index));
        }

        // POST: TestimonialsController/Delete/5
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
