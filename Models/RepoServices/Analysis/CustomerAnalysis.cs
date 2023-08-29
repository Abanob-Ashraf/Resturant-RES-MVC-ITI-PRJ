using Microsoft.EntityFrameworkCore;
using Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models;
using Resturant_RES_MVC_ITI_PRJ.Models.Repositories.Analysis;

namespace Resturant_RES_MVC_ITI_PRJ.Models.RepoServices.Analysis
{
    public class CustomerAnalysis : ICustomerAnalysis
    {
        public ResturantDbContext Ctx { get; }

        public CustomerAnalysis(ResturantDbContext ctx)
        {
            Ctx = ctx;
        }

        //done
        public int NoOfRegisteredCustomers()
        {
            var NoOfRegisteredCustomers = Ctx.Customers.Count();
            return NoOfRegisteredCustomers;
        }

        //done
        public List<Customer> LeastCustomersSignUps()
        {
            var LeastCustomers = Ctx.Customers.Include(c => c.CustomerAddersses).OrderByDescending(c => c.CustID).Take(10).ToList();
            return LeastCustomers;
        }

        //done
        public int GetNoCustomerOrdered()
        {
            var NoCustomerOrdered = Ctx.Orders.Where(c => c.OrderDate == DateTime.Today).Select(c => c.CustomerId).Count();
            Console.WriteLine(NoCustomerOrdered);
            return NoCustomerOrdered;
        }

        //done
        public List<Customer> GetMostCustomersOrderedMoreOne()
        {
            var MostCustomers = Ctx.Orders.Include(c => c.Customer).ThenInclude(c => c.CustomerAddersses)
                .GroupBy(c => c.CustomerId)
                .Where(c => c.Count() > 1).OrderByDescending(c => c.Count())
                .Select(c => c.First().Customer).ToList();
            return MostCustomers;
        }
    }
}
