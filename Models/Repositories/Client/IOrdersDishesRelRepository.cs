﻿using Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models;

namespace Resturant_RES_MVC_ITI_PRJ.Models.Repositories.Client
{
    public interface IOrdersDishesRelRepository
    {
        public List<OrderDishesRel> GetAllOrderDishesRels();

        public OrderDishesRel GetOrderDishesRelById(int id);

        public void InsertOrderDishesRel(OrderDishesRel orderDishesRel);

        public void UpdateOrderDishesRel(int id, OrderDishesRel orderDishesRel);

        public void DeleteOrderDishesRel(int id);
    }
}
