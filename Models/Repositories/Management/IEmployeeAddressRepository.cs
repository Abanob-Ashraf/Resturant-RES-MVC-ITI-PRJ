using Resturant_RES_MVC_ITI_PRJ.Areas.Management.Models;

namespace Resturant_RES_MVC_ITI_PRJ.Models.Repositories.Management
{
    public interface IEmployeeAddressRepository
    {

        public List<EmployeeAddress> GetAllEmployeesAddress();
        public EmployeeAddress GetEmployeeAddressById(int id);
        public void InsertEmployeeAddress(EmployeeAddress employeeAddress);
        public void UpdateEmployeeAddress(EmployeeAddress employeeAddress);
        public void DeleteEmployeeAddress(int id);
    }
}
