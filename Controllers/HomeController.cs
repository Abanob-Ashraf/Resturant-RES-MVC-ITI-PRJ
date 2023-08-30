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

        public HomeController(
            ILogger<HomeController> logger, 
            RoleManager<IdentityRole> roleManager, 
            UserManager<AppUser> userManager, 
            IDishRepository dishRepository, 
            IEmployeeRepository employeeRepository, 
            IFranchiseRepository franchiseRepository,
            IEmployeesCategoriesRepository employeesCategoriesRepository,
            IOrderTypesRepository orderTypesRepository)
        {
            _logger = logger;
            RoleManager = roleManager;
            UserManager = userManager;
            DishRepository = dishRepository;
            EmployeeRepository = employeeRepository;
            FranchiseRepository = franchiseRepository;
            EmployeesCategoriesRepository = employeesCategoriesRepository;
            OrderTypesRepository = orderTypesRepository;
        }

        public async Task<IActionResult> AdminIndex()
        {
            if (User.IsInRole("Admin"))
            {
                return View("DBindex");
            }
            return View("Index");
        }
        public async Task<IActionResult> Index()
        {
            IdentityRole role1 = new IdentityRole();
            role1.Name = "Customer";
            IdentityRole role2 = new IdentityRole();
            role2.Name = "Admin";

            //Save Role to DB
             await RoleManager.CreateAsync(role1);
            await RoleManager.CreateAsync(role2);

            string userPWD = "Admin$123";

            var user = new AppUser
            {
                Email = "zmanrest@gmail.com",
                UserName = "zmanrest@gmail.com",
                FirstName = "Zman",
                LastName = "Rest",
                PhoneNumber = "01142601607",
                EmailConfirmed = true,
                PasswordHash = userPWD
            };
            var chkUser = await UserManager.CreateAsync(user, userPWD);

            //Add default User to Role Admin    
            if (chkUser.Succeeded)
            {
                var result1 = await UserManager.AddToRoleAsync(user, "Admin");

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
                    EmpFirstName = user.FirstName,
                    EmpLastName = user.LastName,
                    EmpEmail = user.Email,
                    EmpPassword = userPWD,
                    EmpPhone = user.PhoneNumber,
                    EmpHiringDate = DateTime.Now,
                    EmpNationalId = "29810310101193",
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
                    OrderTypeName = "takeAway"
                };
                OrderTypesRepository.InsertOrderType(OrderType02);

                var OrderType03 = new OrderType()
                {
                    OrderTypeName = "Dine in"
                };
                OrderTypesRepository.InsertOrderType(OrderType03);

            }
            ViewBag.Menu = DishRepository.GetAllDishes();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}