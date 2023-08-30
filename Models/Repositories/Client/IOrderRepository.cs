using Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models;
using Resturant_RES_MVC_ITI_PRJ.Areas.Management.Models;

namespace Resturant_RES_MVC_ITI_PRJ.Models.Repositories.Client
{
    public interface IOrderRepository
    {
        public List<Order> GetAllOrders();

        public Order GetOrderById(int id);

        public void InsertOrder(Order Order);

        public void InsertOrder(Order Order, ref int id);

        public void UpdateOrder(int id, Order Order);

        public void DeleteOrder(int id);
    }
}
