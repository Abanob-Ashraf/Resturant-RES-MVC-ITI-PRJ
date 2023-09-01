using Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models;

namespace Resturant_RES_MVC_ITI_PRJ.Models.Repositories.Analysis
{
    public interface IOrderAnalysis
    {
        public List<Dish> LeastOrderedDishes();

        public Dictionary<Dish, int> GetMostOrderedDishes();

        public Dictionary<string, List<Order>> GetOrderByType();

        public Dictionary<DateTime, List<Order>> OrdersPerDay();

        public Dictionary<DateTime, List<Order>> OrdersPerMonth();

        public Dictionary<DateTime, int> BusiestDays();
    }

    /*
     * Time-based Metrics:
        *  Orders per day/week/month.
        *  Revenue per day/week/month.
        *  Busiest days or hours.
     *  *  *  *  *  *  *  *  *  *  
     *  Geographic Insights:
        *  Orders by region/country
     */
}
