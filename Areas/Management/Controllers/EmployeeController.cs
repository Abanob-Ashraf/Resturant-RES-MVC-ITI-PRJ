using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Resturant_RES_MVC_ITI_PRJ.Areas.Management.Models;
using Resturant_RES_MVC_ITI_PRJ.Models;
using Resturant_RES_MVC_ITI_PRJ.Models.Repositories;
using Resturant_RES_MVC_ITI_PRJ.Models.Repositories.Client;
using Resturant_RES_MVC_ITI_PRJ.Models.ViewModels;

namespace Resturant_RES_MVC_ITI_PRJ.Areas.Management.Controllers
{
    [Area("Management")]
    //[Route("Employees")]
    public class EmployeeController : Controller
    {
        public IEmployeeRepository EmployeeRepository { get; }
        public IEmployeesCategoriesRepository EmployeesCategoriesRepository { get; }
        public IFranchiseRepository FranchiseRepository { get; }
        public UserManager<AppUser> UserManager { get; }
        public RoleManager<IdentityRole> RoleManager { get; }

        public EmployeeController(IEmployeeRepository employeeRepository, IEmployeesCategoriesRepository employeesCategoriesRepository, IFranchiseRepository franchiseRepository, UserManager<AppUser> userManager,RoleManager<IdentityRole> roleManager)
        {
            EmployeeRepository = employeeRepository;
            EmployeesCategoriesRepository = employeesCategoriesRepository;
            FranchiseRepository = franchiseRepository;
            UserManager = userManager;
            RoleManager = roleManager;
        }

        //[Route("GetAllEmployees")]
        public ActionResult Index()
        {
            return View("Index", EmployeeRepository.GetAllEmployees());
        }

        //[Route("GetEmployeeById/{id:int}")]
        public ActionResult Details(int id)
        {
            return View("Details", EmployeeRepository.GetEmployeeById(id));
        }
        
        //[Route("CreateEmployee")]
        public ActionResult Create()
        {
            ViewBag.CategoryList = new SelectList(EmployeesCategoriesRepository.GetAllEmployeesCategories(), "EmployeeCategoryId", "CategoryName");
            ViewBag.FranchiseList = new SelectList(FranchiseRepository.GetAllFranchises(), "FranchiseId", "City");
            ViewBag.RoleList = new SelectList(RoleManager.Roles.Select(r => r.Name).ToList(),"Name");
            return View();
        }

        [HttpPost]
        //[Route("CreateEmployee")]
        [ValidateAntiForgeryToken]
        public async  Task<ActionResult> Create(Employee employee)
        {
            ViewBag.CategoryList = new SelectList(EmployeesCategoriesRepository.GetAllEmployeesCategories(), "EmployeeCategoryId", "CategoryName");
            ViewBag.FranchiseList = new SelectList(FranchiseRepository.GetAllFranchises(), "FranchiseId", "City");
            ViewBag.RoleList = new SelectList(RoleManager.Roles.Select(r=>r.Name).ToList(),"Name");

            if (ModelState.IsValid)
            {

                EmployeeRepository.InsertEmployee(employee);
                 
                AppUser user = new AppUser();
                user.FirstName = employee.EmpFirstName;
                user.LastName = employee.EmpLastName;
                user.UserName = employee.EmpEmail;
                user.Email = employee.EmpEmail;
                user.PhoneNumber = employee.EmpPhone;
                user.PasswordHash = employee.EmpPassword;
                user.EmailConfirmed = true;
                
                IdentityResult result = await UserManager.CreateAsync(user, employee.EmpPassword);
                await UserManager.AddToRoleAsync(user, employee.RoleName);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        //[Route("UpdateEmployee/{id:int}")]
        public ActionResult Edit(int id)
        {
            ViewBag.CategoryList = new SelectList(EmployeesCategoriesRepository.GetAllEmployeesCategories(), "EmployeeCategoryId", "CategoryName");
            ViewBag.FranchiseList = new SelectList(FranchiseRepository.GetAllFranchises(), "FranchiseId", "City");
            ViewBag.RoleList = new SelectList(RoleManager.Roles.Select(r=>r.Name).ToList(),"Name");

            return View(EmployeeRepository.GetEmployeeById(id));
        }

        [HttpPost]
        //[Route("UpdateEmployee/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Employee employee)
        {
            ViewBag.CategoryList = new SelectList(EmployeesCategoriesRepository.GetAllEmployeesCategories(), "EmployeeCategoryId", "CategoryName");
            ViewBag.FranchiseList = new SelectList(FranchiseRepository.GetAllFranchises(), "FranchiseId", "City");
            ViewBag.RoleList = new SelectList(RoleManager.Roles.Select(r => r.Name).ToList(), "Name");

            if (ModelState.IsValid)
            {
                EmployeeRepository.UpdateEmployee(id, employee);
                var user = await UserManager.FindByNameAsync(employee.EmpEmail);
                if (user != null)
                {
                    user.FirstName = employee.EmpFirstName;
                    user.LastName = employee.EmpLastName;
                    user.UserName = employee.EmpEmail;
                    user.Email = employee.EmpEmail;
                    user.PhoneNumber = employee.EmpPhone;

                    var result = await UserManager.UpdateAsync(user);
                }
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        //[Route("DeletEmployee")]
        public async Task <ActionResult> Delete(int id)
        {
            var emp = EmployeeRepository.GetEmployeeById(id);
            var user = await UserManager.FindByNameAsync(emp.EmpEmail);
            if (user != null)
            {
                var result = await UserManager.DeleteAsync(user);
            }
            EmployeeRepository.DeleteEmployee(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
