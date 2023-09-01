using Resturant_RES_MVC_ITI_PRJ.Areas.Management.Models;

namespace Resturant_RES_MVC_ITI_PRJ.Models.Repositories.Management
{
    public interface IEmployeeRepository
    {
        public List<Employee> GetAllEmployees();

        public Employee GetEmployeeById(int id);

        public void InsertEmployee(Employee employee);

        public void UpdateEmployee(int id, Employee employee);

        public void DeleteEmployee(int id);
    }
}
