
using Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models;

namespace Resturant_RES_MVC_ITI_PRJ.Models.Repositories
{

    public interface IOrderTypesRepository
    {
        public List<OrderTypes> GetAllOrderTypes();

        public OrderTypes GetOrderTypeById(int id);

        public void InsertOrderType(OrderTypes orderTypes);

        public void UpdateOrderType(int id, OrderTypes orderTypes);

        public void DeleteOrderType(int id);
    }
}
