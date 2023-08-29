using Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models;

namespace Resturant_RES_MVC_ITI_PRJ.Models.Repositories.Analysis
{
    public interface IOrderAnalysis
    {
        public List<Dish> LeastOrderedDishes();

        public Dictionary<Dish, int> GetMostOrderedDishes();

        public Dictionary<string, List<Order>> GetOrderByType();
    }
}
