using Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models;
using Resturant_RES_MVC_ITI_PRJ.Models.Repositories.Analysis;

namespace Resturant_RES_MVC_ITI_PRJ.Models.RepoServices.Analysis
{
    public class OrderAnalysis : IOrderAnalysis
    {
        public ResturantDbContext Ctx { get; }

        public OrderAnalysis(ResturantDbContext ctx)
        {
            Ctx = ctx;
        }

        public int GetNoCustomerOrdered()
        {
            var NoCustomerOrdered = Ctx.Orders.Where(c => c.OrderDate == DateTime.Now).Select(c => c.CustomerId).Count();
            Console.WriteLine(NoCustomerOrdered);
            return NoCustomerOrdered;
        }

        public Dictionary<string, List<Order>> GetOrderByType()
        {
            var orders = Ctx.Orders;
            var OrderByType = new Dictionary<string, List<Order>>();

            foreach (var order in orders)
            {
                if (!OrderByType.ContainsKey(order.OrderType.OrderTypeName))
                {
                    OrderByType[order.OrderType.OrderTypeName] = new List<Order>();
                }
                OrderByType[order.OrderType.OrderTypeName].Add(order);
            }
            return OrderByType;
        }
    }
}
