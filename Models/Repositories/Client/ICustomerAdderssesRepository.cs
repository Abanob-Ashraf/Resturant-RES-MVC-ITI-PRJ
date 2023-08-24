using Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models;
using Resturant_RES_MVC_ITI_PRJ.Areas.Management.Models;

namespace Resturant_RES_MVC_ITI_PRJ.Models.Repositories.Client
{
    public interface ICustomerAdderssesRepository
    {
        public List<CustomerAddersses> GetAllCustomerAddersses();

        public CustomerAddersses GetCustomerAdderssById(int id);

        public void InsertCustomerAdderss(CustomerAddersses customerAddersses);

        public void UpdateCustomerAdderss(int id, CustomerAddersses customerAddersses);

        public void DeleteCustomerAdderss(int id);
    }
}
