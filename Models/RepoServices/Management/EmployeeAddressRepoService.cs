using Microsoft.EntityFrameworkCore;
using Resturant_RES_MVC_ITI_PRJ.Areas.Management.Models;
using Resturant_RES_MVC_ITI_PRJ.Models.Repositories.Management;

namespace Resturant_RES_MVC_ITI_PRJ.Models.RepoServices.Management
{
    public class EmployeeAddressRepoService : IEmployeeAddressRepository
    {
        public ResturantDbContext Ctx { get; }

        public EmployeeAddressRepoService(ResturantDbContext ctx)
        {
            Ctx = ctx;
        }

        public List<EmployeeAddress> GetAllEmployeesAddress()
        {
            return Ctx.EmployeesAddresses
                .Include(emp => emp.Employee).ToList();
        }

        public EmployeeAddress GetEmployeeAddressById(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException($"Can't Find That EmployeeAddress with Id: {id}");
            }
            return Ctx.EmployeesAddresses
                .Include(emp => emp.Employee)
                .Where(emp => emp.AddressId == id).SingleOrDefault();
        }

        public void InsertEmployeeAddress(EmployeeAddress employeeAddress)
        {
            if (employeeAddress != null)
            {
                try
                {
                    Ctx.EmployeesAddresses.Add(employeeAddress);
                    Ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        public void UpdateEmployeeAddress(int id, EmployeeAddress employeeAddress)
        {
            var updatedEmployeeAddress = GetEmployeeAddressById(id);
            if (updatedEmployeeAddress != null)
            {
                try
                {
                    updatedEmployeeAddress.City = employeeAddress.City;
                    updatedEmployeeAddress.Country = employeeAddress.Country;
                    updatedEmployeeAddress.EmpId = employeeAddress.EmpId;

                    Ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        public void DeleteEmployeeAddress(int id)
        {
            var deletedEmployeeAddress = GetEmployeeAddressById(id);
            if (deletedEmployeeAddress != null)
            {
                try
                {
                    Ctx.EmployeesAddresses.Remove(deletedEmployeeAddress);
                    Ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }
}
