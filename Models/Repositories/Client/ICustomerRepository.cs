using Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models;
using Resturant_RES_MVC_ITI_PRJ.Areas.Management.Models;

namespace Resturant_RES_MVC_ITI_PRJ.Models.Repositories.Client
{
    public interface ICustomerRepository
    {
        public List<Customer> GetAllCustomers();

        public Customer GetCustomerById(int id);

        public void InsertCustomer(Customer customer);

        public void UpdateCustomer(Customer customer);

        public void DeleteCustomer(int id);
    }
}
