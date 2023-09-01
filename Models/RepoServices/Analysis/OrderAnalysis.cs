using Microsoft.EntityFrameworkCore;
using Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models;
using Resturant_RES_MVC_ITI_PRJ.Models.Repositories.Analysis;
using System.Linq;

namespace Resturant_RES_MVC_ITI_PRJ.Models.RepoServices.Analysis
{
    public class OrderAnalysis : IOrderAnalysis
    {
        public ResturantDbContext Ctx { get; }

        public OrderAnalysis(ResturantDbContext ctx)
        {
            Ctx = ctx;
        }

        //done
        public List<Dish> LeastOrderedDishes()
        {
            var data = Ctx.OrderesDishesRels
                .Include(c => c.Dish)
                .ThenInclude(c => c.DishCategory)
                .OrderByDescending(c => c.Order.OrderDate >= DateTime.Today)
                .Select(c => c.Dish).ToList();
            return data;
        }

        //done
        public Dictionary<Dish, int> GetMostOrderedDishes()
        {
            var MostDishes = Ctx.OrderesDishesRels
                .GroupBy(c => c.DishId)
                .Select(c => new
                {
                    Dish = Ctx.Dishes.FirstOrDefault(v => v.DishId == c.Key),
                    Quantity = c.Sum(v => v.Quantity),
                }).OrderByDescending(c => c.Quantity).ToDictionary(c => c.Dish, c => c.Quantity);
            return MostDishes;
        }

        //done
        public Dictionary<string, List<Order>> GetOrderByType()
        {
            var OrderByType = Ctx.Orders
                .GroupBy(c => c.OrderType.OrderTypeName)
                .ToDictionary(c => c.Key, c => c.ToList());
            return OrderByType;
        }

        public Dictionary<DateTime, List<Order>> OrdersPerDay()
        {
            var OrdersPerDay = Ctx.Orders
                .GroupBy(c => c.OrderDate)
                .ToDictionary(c => c.Key, c => c.ToList());
            return OrdersPerDay;
        }

        public Dictionary<int, List<Order>> OrdersPerMonth()
        {
            var OrdersPerDay = Ctx.Orders
                .GroupBy(c => c.OrderDate.Month)
                .ToDictionary(c => c.Key, c => c.ToList());
            return OrdersPerDay;
        }

        public Dictionary<DateTime, int> BusiestDays()
        {
            var OrdersPerDay = Ctx.Orders
                .GroupBy(c => c.OrderDate)
                .ToDictionary(c => c.Key, c => c.Count());
            return OrdersPerDay;
        }
    }
}
