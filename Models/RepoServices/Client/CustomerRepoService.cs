using Microsoft.EntityFrameworkCore;
using Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models;
using Resturant_RES_MVC_ITI_PRJ.Models.Repositories.Client;

namespace Resturant_RES_MVC_ITI_PRJ.Models.RepoServices.Client
{
    public class CustomerRepoService : ICustomerRepository
    {
        public ResturantDbContext Ctx { get; }

        public CustomerRepoService(ResturantDbContext ctx)
        {
            Ctx = ctx;
        }
        public List<Customer> GetAllCustomers()
        {
            return Ctx.Customers
                 .Include(emp => emp.Testimonials)
                 .Include(emp => emp.Reservations)
                 .Include(emp => emp.CustomerAddersses)
                 .Include(emp => emp.Orders).ToList();
        }

        public Customer GetCustomerById(int id)
        {
            throw new NotImplementedException();
        }

        public void InsertCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void DeleteCustomer(int id)
        {
            throw new NotImplementedException();
        }

    }
}
