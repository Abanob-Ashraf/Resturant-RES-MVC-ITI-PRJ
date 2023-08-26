using Microsoft.EntityFrameworkCore;
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
        public List<Dish> LeastOrderedDishes()
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetMostCustomersOrderedMoreOne()
        {
            var MostCustomers = Ctx.Orders
                .GroupBy(c => c.CustomerId)
                .Where(c => c.Count() > 1)
                .Select(c => c.First().Customer).ToList();
            return MostCustomers;
        }

        public Dictionary<Dish, int> GetMostOrderedDishes()
        {
            var MostDishes = Ctx.OrderesDishesRels
                .GroupBy(c => c.DishId)
                .Select(c => new
                {
                    Dish = Ctx.Dishes.FirstOrDefault(v => v.DishId == c.Key),
                    Quantity = c.Sum(v => v.Quantity),
                }).ToDictionary(b => b.Dish, b => b.Quantity);
                return MostDishes;
        }

        //public List<Dish> LeastOrderedDishes()
        //{
        //    var data;
        //    return data;
        //}
        //public List<Customer> GetCustomersOrdered()
        //{
        //    var MostCustomers = Ctx.Orders
        //        .GroupBy(c => c.CustomerId)
        //        .Where(c => c.Count() > 1)
        //        .Select(c => c.First().Customer).ToList();
        //    return MostCustomers;
        //}

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
