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

        public TestimonialsController(ITestimonialsRepository testimonialsRepository, ICustomerRepository customerRepository)
        {
            TestimonialsRepository = testimonialsRepository;
            CustomerRepository = customerRepository;
        }

        public ActionResult Index()
        {
            return View("Index", TestimonialsRepository.GetAllTestimonials());
        }

        public ActionResult Details(int id)
        {
            return View("Details", TestimonialsRepository.GetTestimonialsById(id));
        }

        public ActionResult Create()
        {
            ViewBag.CustomerList = new SelectList(CustomerRepository.GetAllCustomers(), "CustID", "FirstName");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Testimonials testimonial)
        {
            var routeValues = new RouteValueDictionary(new { area = "" });

            ViewBag.CustomerList = new SelectList(CustomerRepository.GetAllCustomers(), "CustID", "FirstName");

            if (ModelState.IsValid)
            {
                TestimonialsRepository.InsertTestimonials(testimonial);
                return RedirectToAction("Index", "Home", routeValues);
            }
            return RedirectToAction("Index", "Home", routeValues);
        }

        public ActionResult Edit(int id)
        {
            ViewBag.CustomerList = new SelectList(CustomerRepository.GetAllCustomers(), "CustID", "FirstName");

            return View(TestimonialsRepository.GetTestimonialsById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Testimonials testimonial)
        {
            ViewBag.CustomerList = new SelectList(CustomerRepository.GetAllCustomers(), "CustID", "FirstName");

            if (ModelState.IsValid)
            {
                TestimonialsRepository.UpdateTestimonials(id, testimonial);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            TestimonialsRepository.DeleteTestimonials(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
