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
                try
                {
                    Ctx.Employees.Add(employee);
                    Ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                
            }
        }

        public void UpdateEmployee(int id, Employee employee)
        {
            var updatedEmployee = GetEmployeeById(id);
            if (employee != null)
            {
                try
                {
                    updatedEmployee.EmpID = employee.EmpID;
                    updatedEmployee.EmpName = employee.EmpName;
                    updatedEmployee.EmpEmail = employee.EmpEmail;
                    updatedEmployee.EmpPhone = employee.EmpPhone;
                    updatedEmployee.EmpNationalId = employee.EmpNationalId;
                    updatedEmployee.EmpHiringDate = employee.EmpHiringDate;
                    updatedEmployee.EmpCategoryId = employee.EmpCategoryId;
                    updatedEmployee.FranchiseId = employee.FranchiseId;
                    Ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

            }
        }

        public void DeleteEmployee(int id)
        {
            var deletedEmployee = GetEmployeeById(id);
            if (deletedEmployee != null)
            {
                try
                {
                    Ctx.Employees.Remove(deletedEmployee);
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
