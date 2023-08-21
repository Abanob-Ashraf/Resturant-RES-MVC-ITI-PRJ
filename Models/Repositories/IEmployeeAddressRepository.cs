using Resturant_RES_MVC_ITI_PRJ.Areas.Management.Models;

namespace Resturant_RES_MVC_ITI_PRJ.Models.Repositories
{
    public interface IEmployeeAddressRepository
    {

        public List<EmployeeAddress> GetAllEmployeesAddress();
        public EmployeeAddress GetEmployeeAddressById(int id);
        public void InsertEmployeeAddress(EmployeeAddress employee);
        public void UpdateEmployeeAddress(EmployeeAddress employee);
        public void DeleteEmployeeAddress(int id);
    }
}
