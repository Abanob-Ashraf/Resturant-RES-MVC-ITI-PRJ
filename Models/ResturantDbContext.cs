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

        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerAddersses> CustomersAddersses { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<DishCategory> DishesCategories { get; set; }
        public DbSet<DishIngredientRel> DishIngredientRels { get; set; }
        public DbSet<Ingerdient> Ingerdients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderesDishesRel> OrderesDishesRels { get; set; }
        public DbSet<OrderType> OrderTypes { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Testimonials> Testimonials { get; set; }



    }
}
