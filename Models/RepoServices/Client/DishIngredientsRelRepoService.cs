using Microsoft.EntityFrameworkCore;
using Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models;
using Resturant_RES_MVC_ITI_PRJ.Models.Repositories.Client;

namespace Resturant_RES_MVC_ITI_PRJ.Models.RepoServices.Client
{
    public class DishIngredientsRelRepoService : IDishIngredientRelRepository
    {
        public ResturantDbContext Ctx { get; }

        public DishIngredientsRelRepoService(ResturantDbContext ctx)
        {
            Ctx = ctx;
        }

        public List<DishIngredientRel> GetAllDishIngredientRels()
        {
            return Ctx.DishIngredientRels
                 .Include(dishIngredientRel => dishIngredientRel.Dish)
                 .Include(dishIngredientRel => dishIngredientRel.Ingredtient)
                 .ToList();
        }

        public DishIngredientRel GetDishIngredientRelById(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException($"Can't Find That DishIngredientRel with Id: {id}");
            }
            return Ctx.DishIngredientRels
                  .Include(dishIngredientRel => dishIngredientRel.Dish)
                  .Include(dishIngredientRel => dishIngredientRel.Ingredtient)
                   .Where(dishIngredientRel => dishIngredientRel.DishIngredientRelId == id).SingleOrDefault();
        }

        public void InsertDishIngredientRel(DishIngredientRel dishIngredientRel)
        {
            if (dishIngredientRel != null)
            {
                try
                {
                    Ctx.DishIngredientRels.Add(dishIngredientRel);
                    Ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        public void UpdateDishIngredientRel(int id, DishIngredientRel dishIngredientRel)
        {
            var updatedDishIngredientRel = GetDishIngredientRelById(id);
            if (updatedDishIngredientRel != null)
            {
                try
                {
                    updatedDishIngredientRel.DishId = dishIngredientRel.DishId;
                    updatedDishIngredientRel.DishIngredientRelId = dishIngredientRel.DishIngredientRelId;
                    Ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        public void DeleteDishIngredientRel(int id)
        {
            var deletededDishIngredientRel = GetDishIngredientRelById(id);
            if (deletededDishIngredientRel != null)
            {
                try
                {
                    Ctx.DishIngredientRels.Remove(deletededDishIngredientRel);
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
