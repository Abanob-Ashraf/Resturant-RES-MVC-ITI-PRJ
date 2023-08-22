using Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models;

namespace Resturant_RES_MVC_ITI_PRJ.Models.Repositories.Client
{
    public interface IOrderesDishesRelRepository
    {
        public List<OrderesDishesRel> GetAllOrderDishesRels();

        public OrderesDishesRel GetOrderDishesRelById(int id);

        public void InsertOrderDishesRel(OrderesDishesRel orderDishesRel);

        public void UpdateOrderDishesRel(OrderesDishesRel orderDishesRel);

        public void DeleteOrderDishesRel(int id);
    }
}
