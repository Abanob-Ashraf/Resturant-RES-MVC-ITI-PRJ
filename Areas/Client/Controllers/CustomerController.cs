using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models;
using Resturant_RES_MVC_ITI_PRJ.Areas.Management.Models;
using Resturant_RES_MVC_ITI_PRJ.Models;
using Resturant_RES_MVC_ITI_PRJ.Models.Repositories;
using Resturant_RES_MVC_ITI_PRJ.Models.Repositories.Client;
using Resturant_RES_MVC_ITI_PRJ.Models.ViewModels;


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
            var phones = CustomerRepository.GetAllCustomers().Select(u => u.CustPhone).ToList();
            if (phones.Contains(customer.CustPhone))
            {
                ModelState.AddModelError("Phone", "Already Exist Phone Number");
            }
            if (customer.CustPassword == null)
            {
                ModelState.AddModelError("password", "You must enter a password");
            }
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
            if (User.IsInRole("Customer"))
            {
                return View("ClientEditCustomer", CustomerRepository.GetCustomerById(id));
            }
            return View(CustomerRepository.GetCustomerById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Customer customer)
        {
            var phones = CustomerRepository.GetAllCustomers().Select(u => u.CustPhone).ToList();
            var OldPhone = CustomerRepository.GetCustomerById(customer.CustID).CustPhone;
            if (phones.Contains(customer.CustPhone) && customer.CustPhone != OldPhone)
            {
                ModelState.AddModelError("Phone", "Already Exist Phone Number");
            }

            if (ModelState.IsValid)
            {
                var oldPass = CustomerRepository.GetCustomerById(customer.CustID).CustPassword;
                if (customer.CustPassword == null)
                {

                    customer.CustPassword = oldPass;
                }
                CustomerRepository.UpdateCustomer(customer);
                var user = await UserManager.FindByNameAsync(customer.CustEmail);

                if (user != null)
                {
                    user.FirstName = customer.FirstName;
                    user.LastName = customer.LastName;
                    user.PhoneNumber = customer.CustPhone;


                    if (customer.CustPassword != null)
                    {
                        var newPasswordHash = UserManager.PasswordHasher.HashPassword(user, customer.CustPassword);
                        user.PasswordHash = newPasswordHash;

                    }


                    var result = await UserManager.UpdateAsync(user);
                }
                var routeValues = new RouteValueDictionary(new { area = "" });

                return RedirectToAction("Profile", "Account", routeValues);
            }
            if (User.IsInRole("Customer"))
            {

                return View("ClientEditCustomer");
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
