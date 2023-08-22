using Resturant_RES_MVC_ITI_PRJ.Areas.Management.Models;

namespace Resturant_RES_MVC_ITI_PRJ.Models.Repositories.Client
{
    public interface IOrderRepository
    {
        public List<Franchise> GetAllOrders();

        public Franchise GetOrderById(int id);

        public void InsertOrder(Franchise franchise);

        public void UpdateOrder(Franchise franchise);

        public void DeleteOrder(int id);
    }
}
