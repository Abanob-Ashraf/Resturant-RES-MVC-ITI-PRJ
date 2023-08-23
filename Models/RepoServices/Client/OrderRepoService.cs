using Microsoft.EntityFrameworkCore;
using Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models;
using Resturant_RES_MVC_ITI_PRJ.Areas.Management.Models;
using Resturant_RES_MVC_ITI_PRJ.Models.Repositories.Client;

namespace Resturant_RES_MVC_ITI_PRJ.Models.RepoServices.Client
{
    public class OrderRepoService : IOrderRepository
    {
        public ResturantDbContext Ctx { get; }

        public OrderRepoService(ResturantDbContext ctx)
        {
            Ctx = ctx;
        }


        public List<Order> GetAllOrders()
        {
            return Ctx.Orders
                  .Include(ord => ord.Franchise)
                  .Include(ord => ord.OrderType)
                  .Include(ord => ord.Customer)
                  .Include(ord => ord.OrderesDishesRels)
                  .ToList();
        }

        public Order GetOrderById(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException($"Can't Find That Order with Id: {id}");
            }
            return Ctx.Orders
                   .Include(ord => ord.Franchise)
                   .Include(ord => ord.OrderType)
                   .Include(ord => ord.Customer)
                   .Include(ord => ord.OrderesDishesRels)
                    .Where(ord => ord.OrderId == id).SingleOrDefault();
        }

        public void InsertOrder(Order Order)
        {
            if (Order != null)
            {
                Ctx.Orders.Add(Order);
                Ctx.SaveChanges();
            }
        }

        public void UpdateOrder(Order Order)
        {
            if (Order != null)
            {
                Ctx.Orders.Update(Order);
                Ctx.SaveChanges();
            }
        }

        public void DeleteOrder(int id)
        {
            Ctx.Orders.Remove(GetOrderById(id));
            Ctx.SaveChanges();
        }

        void IOrderRepository.UpdateOrder(int id, Order Order)
        {
            throw new NotImplementedException();
        }
    }
}
