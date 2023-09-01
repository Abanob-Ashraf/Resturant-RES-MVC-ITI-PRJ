using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models;
using Resturant_RES_MVC_ITI_PRJ.Areas.Management.Models;
using Resturant_RES_MVC_ITI_PRJ.Models;
using Resturant_RES_MVC_ITI_PRJ.Models.Repositories;
using Resturant_RES_MVC_ITI_PRJ.Models.Repositories.Client;


namespace Resturant_RES_MVC_ITI_PRJ.Areas.Client.Controllers
{
    [Area("Client")]
    //[Route("Customer")]
    public class CustomerController : Controller
    {
        public ICustomerRepository CustomerRepository { get; }

        public UserManager<AppUser> UserManager { get; }

        public CustomerController(ICustomerRepository customerRepository, UserManager<AppUser> userManager)
        {
            CustomerRepository = customerRepository;
            UserManager = userManager;
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
        public async Task<ActionResult> Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                CustomerRepository.UpdateCustomer(customer);
                var user = await UserManager.FindByNameAsync(customer.CustEmail);
                if (user != null)
                {
                    user.FirstName = customer.FirstName;
                    user.LastName = customer.LastName;
                    user.PhoneNumber = customer.CustPhone;

                    var newPasswordHash = UserManager.PasswordHasher.HashPassword(user, customer.CustPassword);
                    user.PasswordHash = newPasswordHash;

                    var result = await UserManager.UpdateAsync(user);
                }
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<ActionResult> Delete(int id)
        {
            var cust = CustomerRepository.GetCustomerById(id);
            var user = await UserManager.FindByNameAsync(cust.CustEmail);
            if (user != null)
            {
                var result = await UserManager.DeleteAsync(user);
            }

            CustomerRepository.DeleteCustomer(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
