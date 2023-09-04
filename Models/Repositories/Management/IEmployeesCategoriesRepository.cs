using Resturant_RES_MVC_ITI_PRJ.Areas.Management.Models;

namespace Resturant_RES_MVC_ITI_PRJ.Models.Repositories
{
    public interface IEmployeesCategoriesRepository
    {
        public List<EmployeeCategory> GetAllEmployeesCategories();

        public EmployeeCategory GetEmployeesCategoryById(int id);

        public void InsertEmployeesCategory(EmployeeCategory employeesCategories);

        public void UpdateEmployeesCategory(EmployeeCategory employeesCategories);

        public void DeleteEmployeesCategory(int id);
    }
}
