using Microsoft.EntityFrameworkCore;
using Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models;
using Resturant_RES_MVC_ITI_PRJ.Models.Repositories.Client;

namespace Resturant_RES_MVC_ITI_PRJ.Models.RepoServices.Client
{
    public class DishCategoryRepoService : IDishCategoryRepository
    {
        public ResturantDbContext Ctx { get; }

        public DishCategoryRepoService(ResturantDbContext ctx)
        {
            Ctx = ctx;
        }

        public List<DishCategory> GetAllDishCategories()
        {
            return Ctx.DishesCategories
                .Include(DishCategory => DishCategory.Dish)
                .ToList();
        }

        public DishCategory GetDishCategoryById(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException($"Can't Find That DishCategory with Id: {id}");
            }
            return Ctx.DishesCategories
               .Include(DishCategory => DishCategory.Dish)
               .Where(DishCategory => DishCategory.DishCategoryId == id).SingleOrDefault();
        }

        public void InsertDishCategory(DishCategory dishCategory)
        {
            if (dishCategory != null)
            {
                try
                {
                    Ctx.DishesCategories.Add(dishCategory);
                    Ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        public void UpdateDishCategory(DishCategory dishCategory)
        {
            if (dishCategory != null)
            {
                try
                {
                    Ctx.DishesCategories.Update(dishCategory);
                    Ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        } 

        public void DeleteDishCategory(int id)
        {
            var deleted = GetDishCategoryById(id);
            if(deleted != null)
            {
                try
                {
                    Ctx.DishesCategories.Remove(deleted);
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
