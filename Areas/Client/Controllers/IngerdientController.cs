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
    public class IngerdientController : Controller
    {
        public IIngerdientRepository IngerdientRepository { get; }

        public IngerdientController(IIngerdientRepository ingerdientRepository)
        {
            IngerdientRepository = ingerdientRepository;
        }

        public ActionResult Index()
        {
            return View("Index", IngerdientRepository.GetAllIngerdients());
        }

        public ActionResult Details(int id)
        {
            return View("Details", IngerdientRepository.GetIngerdientById(id));
        }

        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Ingerdient ingerdient)
        {
            if (ModelState.IsValid)
            {
                IngerdientRepository.InsertIngerdient(ingerdient);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            return View(IngerdientRepository.GetIngerdientById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Ingerdient ingerdient)
        {
            if (ModelState.IsValid)
            {
                IngerdientRepository.UpdateIngerdient(ingerdient);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            IngerdientRepository.DeleteIngerdient(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
