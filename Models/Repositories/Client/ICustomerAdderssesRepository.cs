using Resturant_RES_MVC_ITI_PRJ.Areas.Management.Models;

namespace Resturant_RES_MVC_ITI_PRJ.Models.Repositories.Client
{
    public interface ICustomerAdderssesRepository
    {
        public List<Franchise> GetAllCustomerAddersses();

        public Franchise GetCustomerAdderssById(int id);

        public void InsertCustomerAdderss(Franchise franchise);

        public void UpdateCustomerAdderss(Franchise franchise);

        public void DeleteCustomerAdderss(int id);
    }
}
