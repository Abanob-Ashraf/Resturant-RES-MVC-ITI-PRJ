using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models;
using Resturant_RES_MVC_ITI_PRJ.Models;
using Resturant_RES_MVC_ITI_PRJ.Models.Repositories.Client;

namespace Resturant_RES_MVC_ITI_PRJ.Areas.Client.Controllers
{
    [Area("Client")]
  
    //[Route("Table")]
    public class TableController : Controller
    {
        public ITableRepository TableRepository { get; }

        public TableController(ITableRepository tableRepository)
        {
             TableRepository = tableRepository;
        }
       //[Route("/GetAllTables")]
        public ActionResult Index()
        {
            return View("Index", TableRepository.GetAllTables());
        }

        //[Route("{id:int}")]

        public ActionResult Details(int id)
        {
            return View();
        }

        //[Route("NewTable")]

        public ActionResult Create()
        {
            return View();
        }

        //[Route("NewTable")]

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

        //[Route("Update/{id:int}")]

        public ActionResult Edit(int id)
        {
            return View();
        }

        //[Route("Update/{id:int}")]

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

        //[Route("delete")]
        public ActionResult Delete(int id)
        {
            return View();
        }

        //[Route("delete")]
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
