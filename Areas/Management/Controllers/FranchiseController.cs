﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Resturant_RES_MVC_ITI_PRJ.Areas.Management.Models;
using Resturant_RES_MVC_ITI_PRJ.Models.Repositories;

namespace Resturant_RES_MVC_ITI_PRJ.Areas.Management.Controllers
{
    [Area("Management")]
    //[Route("Franchise")]
    public class FranchiseController : Controller
    {
        public IEmployeeRepository EmployeeRepository { get; }
        public IFranchiseRepository FranchiseRepository { get; }

        public FranchiseController(IEmployeeRepository employeeRepository,  IFranchiseRepository franchiseRepository)
        {
            EmployeeRepository = employeeRepository;
            FranchiseRepository = franchiseRepository;
        }

        //[Route("GetAllFranchise")]
        public ActionResult Index()
        {
            return View("Index", FranchiseRepository.GetAllFranchises());
        }

        //[Route("GetFranchiseById/{id:int}")]
        public ActionResult Details(int id)
        {
            return View("Index", FranchiseRepository.GetFranchiseById(id));
        }

        //[Route("CreateFranchise")]
        public ActionResult Create()
        {
            ViewBag.EmployeeList = new SelectList(EmployeeRepository.GetAllEmployees(), "EmpID", "EmpName");
            return View();
        }

        //[Route("CreateFranchise")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Franchise franchise)
        {
            ViewBag.EmployeeList = new SelectList(EmployeeRepository.GetAllEmployees(), "EmpID", "EmpName");

            if (ModelState.IsValid)
            {
                FranchiseRepository.InsertFranchise(franchise);

                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        //[Route("UpdateEmployee")]
        public ActionResult Edit(int id)
        {
            ViewBag.EmployeeList = new SelectList(EmployeeRepository.GetAllEmployees(), "EmpID", "EmpName");

            return View(FranchiseRepository.GetFranchiseById(id));
        }

        //[Route("UpdateEmployee")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Franchise franchise)
        {
            ViewBag.EmployeeList = new SelectList(EmployeeRepository.GetAllEmployees(), "EmpID", "EmpName");

            if (ModelState.IsValid)
            {
                FranchiseRepository.UpdateFranchise(id, franchise);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        //[Route("DeletEmployee")]

        public ActionResult Delete(int id)
        {
            FranchiseRepository.DeleteFranchise(id);
            return RedirectToAction(nameof(Index));
        }

        //// POST: FranchiseController/Delete/5
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
