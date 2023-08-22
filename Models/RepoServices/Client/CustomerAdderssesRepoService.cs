using Microsoft.EntityFrameworkCore;
using Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models;
using Resturant_RES_MVC_ITI_PRJ.Areas.Management.Models;
using Resturant_RES_MVC_ITI_PRJ.Models.Repositories.Client;

namespace Resturant_RES_MVC_ITI_PRJ.Models.RepoServices.Client
{
    public class CustomerAdderssesRepoService : ICustomerAdderssesRepository
    {

        public ResturantDbContext Ctx { get; }

        public CustomerAdderssesRepoService(ResturantDbContext ctx)
        {
            Ctx = ctx;
        }


        public List<CustomerAddersses> GetAllCustomerAddersses()
        {
            return Ctx.CustomersAddersses.Include(add => add.Customer).ToList();
        }

        public CustomerAddersses GetCustomerAdderssById(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException($"Can't Find That Customer with Id: {id}");
            }
            return Ctx.CustomersAddersses
                .Include(add => add.Customer)
                .Where(cs => cs.CustomerAdderssesID == id).SingleOrDefault();
        }

        public void InsertCustomerAdderss(CustomerAddersses customerAddersses)
        {
            if (customerAddersses != null)
            {
                Ctx.CustomersAddersses.Add(customerAddersses);
                Ctx.SaveChanges();
            }
        }

        public void UpdateCustomerAdderss(CustomerAddersses customerAddersses)
        {
            if (customerAddersses != null)
            {
                Ctx.CustomersAddersses.Update(customerAddersses);
                Ctx.SaveChanges();
            }
        }

        public void DeleteCustomerAdderss(int id)
        {
            throw new NotImplementedException();
        }
    }
}
