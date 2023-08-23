using Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models;

namespace Resturant_RES_MVC_ITI_PRJ.Models.Repositories.Client
{

    public interface IOrderTypesRepository
    {
        public List<OrderType> GetAllOrderTypes();

        public OrderType GetOrderTypeById(int id);

        public void InsertOrderType(OrderType orderTypes);

        public void UpdateOrderType(int id, OrderType orderTypes);

        public void DeleteOrderType(int id);
        void UpdateOrderType(OrderType orderType);
    }
}
