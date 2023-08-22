using Microsoft.EntityFrameworkCore;
using Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models;
using Resturant_RES_MVC_ITI_PRJ.Models.Repositories.Client;

namespace Resturant_RES_MVC_ITI_PRJ.Models.RepoServices.Client
{
    public class OrderesDishesRelRepoService : IOrderesDishesRelRepository
    {

        public ResturantDbContext Ctx { get; }

        public OrderesDishesRelRepoService(ResturantDbContext ctx)
        {
            Ctx = ctx;
        }

        public List<OrderesDishesRel> GetAllOrderDishesRels()
        {
            return Ctx.OrderesDishesRels
                 .Include(orderdishRel => orderdishRel.Dish)
                 .Include(ordSishRel => ordSishRel.Order)
                 .ToList();

        }

        public OrderesDishesRel GetOrderDishesRelById(int id)
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

        public void InsertOrderDishesRel(OrderesDishesRel orderDishesRel)
        {

            if (orderDishesRel != null)
            {
                Ctx.OrderesDishesRels.Add(orderDishesRel);
                Ctx.SaveChanges();
            }
        }

        public void UpdateOrderDishesRel(OrderesDishesRel orderDishesRel)
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
    }
}
