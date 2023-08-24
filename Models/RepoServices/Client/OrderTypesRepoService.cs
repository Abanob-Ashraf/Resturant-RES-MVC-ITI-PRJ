using Microsoft.EntityFrameworkCore;
using Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models;
using Resturant_RES_MVC_ITI_PRJ.Models.Repositories.Client;

namespace Resturant_RES_MVC_ITI_PRJ.Models.RepoServices.Client
{
    public class OrderTypesRepoService : IOrderTypesRepository
    {
        public ResturantDbContext Ctx { get; }

        public OrderTypesRepoService(ResturantDbContext ctx)
        {
            Ctx = ctx;
        }

        public List<OrderType> GetAllOrderTypes()
        {
            return Ctx.OrderTypes
                  .Include(OrderType => OrderType.Orders)
                  .ToList();
        }

        public OrderType GetOrderTypeById(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException($"Can't Find That OrderType with Id: {id}");
            }
            return Ctx.OrderTypes
                 .Include(OrderType => OrderType.Orders)
                 .Where(OrderType => OrderType.OrderTypeId == id).SingleOrDefault();
        }
        
        public void InsertOrderType(OrderType OrderType)
        {
            if (OrderType != null)
            {
                try
                {
                    Ctx.OrderTypes.Add(OrderType);
                    Ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        public void UpdateOrderType(OrderType OrderType)
        {
            if (OrderType != null)
            {
                try
                {
                    Ctx.OrderTypes.Update(OrderType);
                    Ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        public void DeleteOrderType(int id)
        {
            var deleted = GetOrderTypeById(id);
            if (deleted != null)
            {
                try
                {
                    Ctx.OrderTypes.Remove(deleted);
                    Ctx.SaveChanges();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }
}
