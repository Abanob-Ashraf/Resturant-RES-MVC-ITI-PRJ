using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resturant_RES_MVC_ITI_PRJ.Models.Repositories.Client;

namespace Resturant_RES_MVC_ITI_PRJ.Areas.Client.Controllers
{
    [Area("Client")]
    public class TestimonialsController : Controller
    {
        public ITestimonialsRepository TestimonialsRepository { get; }

        public TestimonialsController(ITestimonialsRepository testimonialsRepository)
        {
            TestimonialsRepository = testimonialsRepository;
        }
      
        public ActionResult Index()
        {
            return View("Index", TestimonialsRepository.GetAllTestimonials());
        }

        // GET: TestimonialsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TestimonialsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TestimonialsController/Create
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

        // GET: TestimonialsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TestimonialsController/Edit/5
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

        // GET: TestimonialsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TestimonialsController/Delete/5
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
