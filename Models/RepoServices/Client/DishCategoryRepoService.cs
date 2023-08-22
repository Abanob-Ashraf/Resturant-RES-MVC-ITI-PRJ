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
                Ctx.DishesCategories.Add(dishCategory);
                Ctx.SaveChanges();
            }

        }
        public void UpdateDishCategory(DishCategory dishCategory)
        {
                if (dishCategory != null)
                {
                    Ctx.DishesCategories.Update(dishCategory);
                    Ctx.SaveChanges();
                }
         }   

        public void DeleteDishCategory(int id)
        {
            Ctx.DishesCategories.Remove(GetDishCategoryById(id));
            Ctx.SaveChanges();
        }
    }
}
