using Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models;

namespace Resturant_RES_MVC_ITI_PRJ.Models.Repositories.Analysis
{
    public interface ICustomerAnalysis
    {
        public int NoOfRegisteredCustomers();

        public List<Customer> LeastCustomersSignUps();

        public int GetNoCustomerOrdered();

        public List<Customer> GetMostCustomersOrderedMoreOne();
    }
}
