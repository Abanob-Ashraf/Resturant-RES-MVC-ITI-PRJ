using Microsoft.EntityFrameworkCore;
using Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models;
using Resturant_RES_MVC_ITI_PRJ.Models.Repositories.Client;

namespace Resturant_RES_MVC_ITI_PRJ.Models.RepoServices.Client
{
    public class OrdersDishesRelRepoService : IOrdersDishesRelRepository
    {

        public ResturantDbContext Ctx { get; }

        public OrdersDishesRelRepoService(ResturantDbContext ctx)
        {
            Ctx = ctx;
        }

        public List<OrderDishesRel> GetAllOrderDishesRels()
        {
            return Ctx.OrderesDishesRels
                 .Include(orderdishRel => orderdishRel.Dish)
                 .Include(ordSishRel => ordSishRel.Order)
                 .ToList();
        }

        public OrderDishesRel GetOrderDishesRelById(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException($"Can't Find That OrderesDishesRel with Id: {id}");
            }
            return Ctx.OrderesDishesRels
                  .Include(orderdishRel => orderdishRel.Dish)
                  .Include(ordSishRel => ordSishRel.Order)
                  .Where(ordSishRel => ordSishRel.OrderDishesRelId == id).SingleOrDefault();
        }

        public void InsertOrderDishesRel(OrderDishesRel orderDishesRel)
        {
            if (orderDishesRel != null)
            {
                try
                {
                    Ctx.OrderesDishesRels.Add(orderDishesRel);
                    Ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        public void UpdateOrderDishesRel(int id,OrderDishesRel orderDishesRel)
        {
            var updateOrderDishesRel = GetOrderDishesRelById(id);
            if (updateOrderDishesRel != null)
            {
                try
                {
                    updateOrderDishesRel.OrderId = orderDishesRel.OrderId;
                    updateOrderDishesRel.DishId = orderDishesRel.DishId;
                    updateOrderDishesRel.Quantity = orderDishesRel.Quantity;

                    Ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        public void DeleteOrderDishesRel(int id)
        {
            var delete = GetOrderDishesRelById(id);
            if (delete != null)
            {
                try
                {
                    Ctx.OrderesDishesRels.Remove(delete);
                    Ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }
}
