using Microsoft.EntityFrameworkCore;
using Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models;
using Resturant_RES_MVC_ITI_PRJ.Areas.Management.Models;
using Resturant_RES_MVC_ITI_PRJ.Models.Repositories;

namespace Resturant_RES_MVC_ITI_PRJ.Models.RepoServices.Management
{
    public class EmployeeRepoService : IEmployeeRepository
    {
        public ResturantDbContext Ctx { get; }

        public EmployeeRepoService(ResturantDbContext ctx)
        {
            Ctx = ctx;
        }

        public List<Employee> GetAllEmployees()
        {
            return Ctx.Employees
                .Include(emp => emp.EmployeeAddress)
                .Include(emp => emp.EmployeeCategory)
                .Include(emp => emp.Franchise)
                .Include(emp => emp.Franchises).ToList();
                
        }

        public Employee GetEmployeeById(int id)
        {
            if(id == 0)
            {
                throw new ArgumentException($"Can't Find That Employee with Id: {id}");
            }
            return Ctx.Employees
                .Include (emp => emp.EmployeeAddress)
                .Include (emp => emp.EmployeeCategory)
                .Include (emp => emp.Franchise)
                .Include (emp => emp.Franchises)
                .Where(emp => emp.EmpID == id).SingleOrDefault();
        }

        public void InsertEmployee(Employee employee)
        {
            if (employee != null)
            {
                Ctx.Employees.Add(employee);
                Ctx.SaveChanges();
            }
        }

        public void UpdateEmployee(Employee employee)
        {
            if (employee != null)
            {
                Ctx.Employees.Update(employee);
                Ctx.SaveChanges();
            }
        }

        public void DeleteEmployee(int id)
        {
            Ctx.Employees.Remove(GetEmployeeById(id));
            Ctx.SaveChanges();
        }
    }
}
