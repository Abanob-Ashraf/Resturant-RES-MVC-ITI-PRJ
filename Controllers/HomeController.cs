using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models;
using Resturant_RES_MVC_ITI_PRJ.Areas.Management.Models;
using Resturant_RES_MVC_ITI_PRJ.Models;
using Resturant_RES_MVC_ITI_PRJ.Models.Repositories;
using Resturant_RES_MVC_ITI_PRJ.Models.Repositories.Client;
using System.Diagnostics;

namespace Resturant_RES_MVC_ITI_PRJ.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public RoleManager<IdentityRole> RoleManager { get; }
        public UserManager<AppUser> UserManager { get; }
        public IDishRepository DishRepository { get; }
        public IEmployeeRepository EmployeeRepository { get; }
        public IFranchiseRepository FranchiseRepository { get; }
        public IEmployeesCategoriesRepository EmployeesCategoriesRepository { get; }
        public IOrderTypesRepository OrderTypesRepository { get; }
        public ICustomerRepository CustomerRepository { get; }

        public HomeController(
            ILogger<HomeController> logger,
            RoleManager<IdentityRole> roleManager,
            UserManager<AppUser> userManager,
            IDishRepository dishRepository,
            IEmployeeRepository employeeRepository,
            IFranchiseRepository franchiseRepository,
            IEmployeesCategoriesRepository employeesCategoriesRepository,
            IOrderTypesRepository orderTypesRepository,
            ICustomerRepository customerRepository)
        {
            _logger = logger;
            RoleManager = roleManager;
            UserManager = userManager;
            DishRepository = dishRepository;
            EmployeeRepository = employeeRepository;
            FranchiseRepository = franchiseRepository;
            EmployeesCategoriesRepository = employeesCategoriesRepository;
            OrderTypesRepository = orderTypesRepository;
            CustomerRepository = customerRepository;
        }
        [Authorize(Roles = "Admin,Employee")]
        public async Task<IActionResult> AdminIndex()
        {
            if (User.IsInRole("Admin") || User.IsInRole("Employee"))
            {
                return View("DBindex");
            }
            return View("Index");
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            await Initialize_Data();

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [AllowAnonymous]
        protected async Task Initialize_Data()
        {
            IdentityRole role1 = new IdentityRole();
            role1.Name = "Customer";
            IdentityRole role2 = new IdentityRole();
            role2.Name = "Admin";
            IdentityRole role3 = new IdentityRole();
            role3.Name = "Employee";

            //Save Role to DB
            await RoleManager.CreateAsync(role1);
            await RoleManager.CreateAsync(role2);
            await RoleManager.CreateAsync(role3);

            string ManagerPWD = "Admin$123";

            var Manager = new AppUser
            {
                Email = "zmanrest@gmail.com",
                UserName = "zmanrest@gmail.com",
                FirstName = "Zman",
                LastName = "Rest",
                PhoneNumber = "01142601607",
                EmailConfirmed = true,
                PasswordHash = ManagerPWD
            };
            var ManagerUser = await UserManager.CreateAsync(Manager, ManagerPWD);

            var DineINCustPWD = "Customer$123";

            var DineINCust = new AppUser
            {
                Email = "DineIn@ZmanRest.com",
                UserName = "DineIn@ZmanRest.com",
                FirstName = "Dine",
                LastName = "In",
                PhoneNumber = "01099412326",
                EmailConfirmed = true,
                PasswordHash = DineINCustPWD
            };
            var DineINEmpUser = await UserManager.CreateAsync(DineINCust, DineINCustPWD);

            //Add default User to Role Admin    
            if (ManagerUser.Succeeded)
            {
                await UserManager.AddToRoleAsync(Manager, "Admin");

                await UserManager.AddToRoleAsync(DineINCust, "Customer");

                var Category = new EmployeeCategory()
                {
                    CategoryName = "HeadManager"
                };
                EmployeesCategoriesRepository.InsertEmployeesCategory(Category);

                var Franchise = new Franchise()
                {
                    Street = "9st",
                    City = "Maadi",
                    Country = "Egypt"
                };
                FranchiseRepository.InsertFranchise(Franchise);

                var HeadManager = new Employee()
                {
                    EmpFirstName = Manager.FirstName,
                    EmpLastName = Manager.LastName,
                    EmpEmail = Manager.Email,
                    EmpPassword = Manager.PasswordHash,
                    EmpPhone = Manager.PhoneNumber,
                    EmpHiringDate = DateTime.Now,
                    EmpNationalId = "29810310101193",
                    City = "Maadi",
                    Country = "Egypt",
                    EmpSalary = 10000.0,
                    EmpCategoryId = 1,
                    FranchiseId = 1,
                };
                EmployeeRepository.InsertEmployee(HeadManager);

                var test = FranchiseRepository.GetFranchiseById(1);
                test.ManagerId = 1;
                FranchiseRepository.UpdateFranchise(1, test);

                var OrderType01 = new OrderType()
                {
                    OrderTypeName = "Delivery"
                };
                OrderTypesRepository.InsertOrderType(OrderType01);

                var OrderType02 = new OrderType()
                {
                    OrderTypeName = "TakeAway"
                };
                OrderTypesRepository.InsertOrderType(OrderType02);

                var OrderType03 = new OrderType()
                {
                    OrderTypeName = "Dine in"
                };
                OrderTypesRepository.InsertOrderType(OrderType03);
            }
            if (DineINEmpUser.Succeeded)
            {
                var DineIN = new Customer()
                {
                    FirstName = DineINCust.FirstName,
                    LastName = DineINCust.LastName,
                    CustEmail = DineINCust.Email,
                    CustPassword = DineINCust.PasswordHash,
                    CustPhone = DineINCust.PhoneNumber,
                    CustAddressStreet = "9th",
                    CustAddressCity = "Maadi",
                    CustAddressCounty = "Egypt"
                };
                CustomerRepository.InsertCustomer(DineIN);
            }
        }
    }
}