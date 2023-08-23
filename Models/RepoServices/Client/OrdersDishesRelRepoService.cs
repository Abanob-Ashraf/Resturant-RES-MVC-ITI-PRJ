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
                Ctx.OrderesDishesRels.Add(orderDishesRel);
                Ctx.SaveChanges();
            }
        }

        public void UpdateOrderDishesRel(OrderDishesRel orderDishesRel)
        {
            if (orderDishesRel != null)
            {
                Ctx.OrderesDishesRels.Update(orderDishesRel);
                Ctx.SaveChanges();
            }
        }

        public void DeleteOrderDishesRel(int id)
        {
            Ctx.OrderesDishesRels.Remove(GetOrderDishesRelById(id));
            Ctx.SaveChanges();
        }

        void IOrdersDishesRelRepository.UpdateOrderDishesRel(int id, OrderDishesRel orderDishesRel)
        {
            throw new NotImplementedException();
        }
    }
}
