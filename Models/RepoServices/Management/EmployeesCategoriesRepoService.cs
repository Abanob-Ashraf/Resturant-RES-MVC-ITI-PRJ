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
                try
                {
                    Ctx.EmployeeCategories.Add(employeesCategories);
                    Ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        public void UpdateEmployeesCategory(EmployeeCategory employeesCategories)
        {
            if (employeesCategories != null)
            {
                try
                {
                    Ctx.EmployeeCategories.Update(employeesCategories);
                    Ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        public void DeleteEmployeesCategory(int id)
        {
            var deletedEmployeesCategories = GetEmployeesCategoryById(id);
            if (deletedEmployeesCategories != null)
            {
                try
                {
                    Ctx.EmployeeCategories.Remove(deletedEmployeesCategories);
                    Ctx.SaveChanges();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }
}
