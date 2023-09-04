using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models;
using Resturant_RES_MVC_ITI_PRJ.Models.Repositories;
using Resturant_RES_MVC_ITI_PRJ.Models.Repositories.Client;

namespace Resturant_RES_MVC_ITI_PRJ.Areas.Client.Controllers
{
    [Area("Client")]
    public class ReservationController : Controller
    {
        public IReservationRepository ReservationRepository { get; }
        public ICustomerRepository CustomerRepository { get; }
        public IFranchiseRepository FranchiseRepository { get; }

        public ReservationController(IReservationRepository reservationrepository,ICustomerRepository customerRepository, IFranchiseRepository franchiseRepository)
        {
            ReservationRepository = reservationrepository;
            CustomerRepository = customerRepository;
            FranchiseRepository = franchiseRepository;
        }
      
        public ActionResult Index()
        {
            return View("Index", ReservationRepository.GetAllReservations());
        }
    
        public ActionResult Details(int id)
        {
            return View(ReservationRepository.GetReservationById(id));
        }

        public ActionResult Create()
        {
            ViewBag.CustomerList = new SelectList(CustomerRepository.GetAllCustomers(), "CustID", "FirstName");
            ViewBag.FranchiseList = new SelectList(FranchiseRepository.GetAllFranchises(), "FranchiseId", "City");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Reservation reservation)
        {
            ViewBag.CustomerList = new SelectList(CustomerRepository.GetAllCustomers(), "CustID", "FirstName");
            ViewBag.FranchiseList = new SelectList(FranchiseRepository.GetAllFranchises(), "FranchiseId", "City");


            if (ModelState.IsValid)
            {
                ReservationRepository.InsertReservation(reservation);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            ViewBag.CustomerList = new SelectList(CustomerRepository.GetAllCustomers(), "CustID", "FirstName"); 
            ViewBag.FranchiseList = new SelectList(FranchiseRepository.GetAllFranchises(), "FranchiseId", "City");

            return View(ReservationRepository.GetReservationById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Reservation reservation)
        {
            ViewBag.CustomerList = new SelectList(CustomerRepository.GetAllCustomers(), "CustID", "FirstName");
            ViewBag.FranchiseList = new SelectList(FranchiseRepository.GetAllFranchises(), "FranchiseId", "City");

            if (ModelState.IsValid)
            {
                ReservationRepository.UpdateReservation(id,reservation);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            ReservationRepository.DeleteReservation(id);
            return RedirectToAction(nameof(Index));
        }
    }
}