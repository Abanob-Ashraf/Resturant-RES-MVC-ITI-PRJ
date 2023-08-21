
using Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models;

namespace Resturant_RES_MVC_ITI_PRJ.Models.Repositories
{

    public interface IOrderTypesRepository
    {
        public List<OrderTypes> GetAllOrderTypes();

        public OrderTypes GetOrderTypesById(int id);

        public void InsertOrderTypes(OrderTypes orderTypes);

        public void UpdateOrderTypes(int id, OrderTypes orderTypes);

        public void DeleteOrderTypes(int id);
    }
}
