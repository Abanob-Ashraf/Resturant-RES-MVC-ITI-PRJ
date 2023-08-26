using Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models;

namespace Resturant_RES_MVC_ITI_PRJ.Models.Repositories.Analysis
{
    public interface IOrderAnalysis
    {
        public int GetNoCustomerOrdered();

        public Dictionary<string, List<Order>> GetOrderByType();
    }
}
