using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models;

namespace Resturant_RES_MVC_ITI_PRJ.Models
{
    public class ResturantDbContext : IdentityDbContext
    {
        public ResturantDbContext(DbContextOptions<ResturantDbContext> options) : base(options)
        {

        }

        public DbSet<Customers> Customers { get; set; }
        public DbSet<CustomersAddersses> CustomersAddersses { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<DishesCategories> DishesCategories { get; set; }
        public DbSet<DishesIngredientsRel> dishesIngredientsRels { get; set; }
        public DbSet<Ingerdients> Ingerdients { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderDishesRel> ordersDishesRels { get; set; }
        public DbSet<OrderTypes> OrderTypes { get; set; }
        public DbSet<Reservations> Reservations { get; set; }
        public DbSet<Tables> Tables { get; set; }
        public DbSet<Testimonials> Testimonials { get; set; }



    }
}
