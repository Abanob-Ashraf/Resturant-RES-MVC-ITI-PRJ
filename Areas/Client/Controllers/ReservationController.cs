using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models;
using Resturant_RES_MVC_ITI_PRJ.Models.Repositories.Client;

namespace Resturant_RES_MVC_ITI_PRJ.Areas.Client.Controllers
{
    [Area("Client")]
    public class ReservationController : Controller
    {
       

        public IReservationRepository ReservationRepository { get; }
        public ICustomerRepository CustomerRepository { get; }
        public ITableRepository TableRepository { get; }

        public ReservationController(IReservationRepository reservationrepository,ICustomerRepository customerRepository,ITableRepository tableRepository)
        {
            ReservationRepository = reservationrepository;
            CustomerRepository = customerRepository;
            TableRepository = tableRepository;
        }
      
        public ActionResult Index()
        {
            return View("Index", ReservationRepository.GetAllReservations());
        }
    
    
        // GET: ReservationController/Details/5
        public ActionResult Details(int id)
        {
            return View(ReservationRepository.GetReservationById(id));
        }

        // GET: ReservationController/Create
        public ActionResult Create()
        {
            ViewBag.CustomerList = new SelectList(CustomerRepository.GetAllCustomers(), "CustID", "FirstName");
            ViewBag.TableList = new SelectList(TableRepository.GetAllTables(), "TableID", "TableNumber");

            return View();
        }

        // POST: ReservationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Reservation reservation)
        {
            ViewBag.CustomerList = new SelectList(CustomerRepository.GetAllCustomers(), "CustID", "FirstName");
            ViewBag.TableList = new SelectList(TableRepository.GetAllTables(), "TableID", "TableNumber");

            if (ModelState.IsValid)
            {
                ReservationRepository.InsertReservation(reservation);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: ReservationController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.CustomerList = new SelectList(CustomerRepository.GetAllCustomers(), "CustID", "FirstName");
            ViewBag.TableList = new SelectList(TableRepository.GetAllTables(), "TableID", "TableNumber");

            return View(ReservationRepository.GetReservationById(id));
        }

        // POST: ReservationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Reservation reservation)
        {

            ViewBag.CustomerList = new SelectList(CustomerRepository.GetAllCustomers(), "CustID", "FirstName");
            ViewBag.TableList = new SelectList(TableRepository.GetAllTables(), "TableIDTableID", "TableNumber");

            if (ModelState.IsValid)
            {
                ReservationRepository.UpdateReservation(id,reservation);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: ReservationController/Delete/5
        public ActionResult Delete(int id)
        {

            ReservationRepository.DeleteReservation(id);
            return RedirectToAction(nameof(Index));
        }

      
    }
}
