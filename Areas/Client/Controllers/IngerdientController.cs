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
    //[Route("Ingerdient")]
    public class IngerdientController : Controller
    {
        public IIngerdientRepository IngerdientRepository { get; }

        public IngerdientController(IIngerdientRepository ingerdientRepository)
        {
            IngerdientRepository = ingerdientRepository;
        }

        //[Route("GetAllIngerdients")]
        public ActionResult Index()
        {
            return View("Index", IngerdientRepository.GetAllIngerdients());
        }

        //[Route("GetIngerdientById/{id:int}")]
        public ActionResult Details(int id)
        {
            return View("Details", IngerdientRepository.GetIngerdientById(id));
        }

        //[Route("CreateIngerdient")]
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        //[Route("CreateIngerdient")]
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

        //[Route("UpdateIngerdient/{id:int}")]
        public ActionResult Edit(int id)
        {
            return View(IngerdientRepository.GetIngerdientById(id));
        }

        [HttpPost]
        //[Route("UpdateIngerdient/{id:int}")]
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

        //[Route("DeleteIngerdient/{id:int}")]
        public ActionResult Delete(int id)
        {
            IngerdientRepository.DeleteIngerdient(id);
            return RedirectToAction(nameof(Index));
        }

        
    }
}
