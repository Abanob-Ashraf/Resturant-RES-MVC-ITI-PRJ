using Microsoft.EntityFrameworkCore;
using Resturant_RES_MVC_ITI_PRJ.Areas.Management.Models;
using Resturant_RES_MVC_ITI_PRJ.Models.Repositories;

namespace Resturant_RES_MVC_ITI_PRJ.Models.RepoServices.Management
{
    public class EmployeesCategoriesRepoService : IEmployeesCategoriesRepository
    {
        public ResturantDbContext Ctx { get; }

        public EmployeesCategoriesRepoService(ResturantDbContext ctx)
        {
            Ctx = ctx;
        }

        public List<EmployeeCategory> GetAllEmployeesCategories()
        {
            return Ctx.EmployeeCategories
                .Include(emp => emp.Employees).ToList();
        }

        public EmployeeCategory GetEmployeesCategoryById(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException($"Can't Find That EmployeeCategory with Id: {id}");
            }
            return Ctx.EmployeeCategories
                .Include(emp => emp.Employees)
                .Where(emp => emp.EmployeeCategoryId == id).SingleOrDefault();
        }

        public void InsertEmployeesCategory(EmployeeCategory employeesCategories)
        {
            if (employeesCategories != null)
            {
                Ctx.EmployeeCategories.Add(employeesCategories);
                Ctx.SaveChanges();
            }
        }

        public void UpdateEmployeesCategory(EmployeeCategory employeesCategories)
        {
            if (employeesCategories != null)
            {
                Ctx.EmployeeCategories.Update(employeesCategories);
                Ctx.SaveChanges();
            }
        }

        public void DeleteEmployeesCategory(int id)
        {
            Ctx.EmployeeCategories.Remove(GetEmployeesCategoryById(id));
            Ctx.SaveChanges();
        }
    }
}
