using Resturant_RES_MVC_ITI_PRJ.Areas.Management.Models;

namespace Resturant_RES_MVC_ITI_PRJ.Models.Repositories
{
    public interface IEmployeesCategoriesRepository
    {

        public List<EmployeesCategories> GetAllEmployeesCategories();

        public EmployeesCategories GetEmployeesCategoryById(int id);

        public void InsertEmployeesCategory(EmployeesCategories employeesCategories);

        public void UpdateEmployeesCategory(EmployeesCategories employeesCategories);

        public void DeleteEmployeesCategory(int id);
    }
}
