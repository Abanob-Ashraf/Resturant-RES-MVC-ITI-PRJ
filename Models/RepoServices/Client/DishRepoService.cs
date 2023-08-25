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
                try
                {
                    Ctx.Dishes.Add(dish);
                    Ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        public void UpdateDish(int id, Dish dish)
        {
            var updatedDish = GetDishById(id);
            if (updatedDish != null)
            {
                try
                {
                    updatedDish.DishPrice = dish.DishPrice;
                    updatedDish.DishImageName = dish.DishImageName;
                    updatedDish.DishCategoryId = dish.DishCategoryId;
                    Ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        public void DeleteDish(int id)
        {
            var deletedDish = GetDishById(id);
            if (deletedDish != null)
            {
                try
                {
                    Ctx.Dishes.Remove(deletedDish);
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
