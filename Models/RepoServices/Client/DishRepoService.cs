using Microsoft.EntityFrameworkCore;
using Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models;
using Resturant_RES_MVC_ITI_PRJ.Models.Repositories.Client;

namespace Resturant_RES_MVC_ITI_PRJ.Models.RepoServices.Client
{
    public class DishRepoService : IDishRepository
    {
        public ResturantDbContext Ctx { get; }

        public DishRepoService(ResturantDbContext ctx)
        {
            Ctx = ctx;
        }
        public List<Dish> GetAllDishes()
        {
            return Ctx.Dishes
                .Include(d => d.DishCategory)
                .Include(d => d.DishIngredientRels)
                .ToList();
        }

        public Dish GetDishById(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException($"Can't Find That Dish with Id: {id}");
            }
            return Ctx.Dishes
                .Include(d => d.DishCategory)
                .Include(d => d.DishIngredientRels)
                .Where(d => d.DishId == id).SingleOrDefault();
        }

        public void InsertDish(Dish dish)
        {
            if (dish != null)
            {
                Ctx.Dishes.Add(dish);
                Ctx.SaveChanges();
            }
        }

        public void UpdateDish(Dish dish)
        {
            if (dish != null)
            {
                Ctx.Dishes.Update(dish);
                Ctx.SaveChanges();
            }
        }

        public void DeleteDish(int id)
        {
            Ctx.Dishes.Remove(GetDishById(id));
            Ctx.SaveChanges();
        }
    }
}
