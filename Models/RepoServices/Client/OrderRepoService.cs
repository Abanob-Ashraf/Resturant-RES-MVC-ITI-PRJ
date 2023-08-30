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
                try
                {
                    Ctx.Orders.Add(Order);
                    Ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        public void InsertOrder(Order Order, ref int x)
        {
            if (Order != null)
            {
                try
                {
                    Ctx.Orders.Add(Order);
                    Ctx.SaveChanges();
                    x = Order.OrderId;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        public void UpdateOrder(int id, Order Order)
        {
            var updateOrder = GetOrderById(id);
            if (updateOrder != null)
            {
                try
                {
                    updateOrder.OrderDate = Order.OrderDate;
                    updateOrder.OrderState = Order.OrderState;
                    updateOrder.PaymentMethod = Order.PaymentMethod;
                    updateOrder.IsPaid = Order.IsPaid;
                    updateOrder.OrderTypeId = Order.OrderTypeId;
                    updateOrder.CustomerId = Order.CustomerId;
                    updateOrder.FranchiseId = Order.FranchiseId;

                    Ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        public void DeleteOrder(int id)
        {
            var deleteOrder = GetOrderById(id);
            if (deleteOrder != null)
            {
                try
                {
                    Ctx.Orders.Remove(deleteOrder);
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
