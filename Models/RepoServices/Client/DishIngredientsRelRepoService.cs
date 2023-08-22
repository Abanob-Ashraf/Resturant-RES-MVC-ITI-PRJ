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
            return Ctx.DishIngredientRels
                  .Include(dishIngredientRel => dishIngredientRel.Dish)
                  .Include(dishIngredientRel => dishIngredientRel.Ingredtient)
                   .Where(dishIngredientRel => dishIngredientRel.DishIngredientRelId == id).SingleOrDefault();
        }

        public void InsertDishIngredientRel(DishIngredientRel dishIngredientRel)
        {
            Ctx.DishIngredientRels.Add(dishIngredientRel);
            Ctx.SaveChanges();
        }

        public void UpdateDishIngredientRel(DishIngredientRel dishIngredientRel)
        {
            Ctx.DishIngredientRels.Update(dishIngredientRel);
            Ctx.SaveChanges();
        }


        public void DeleteDishIngredientRel(int id)
        {
            Ctx.DishIngredientRels.Remove(GetDishIngredientRelById(id));
            Ctx.SaveChanges();
        }
    }
}
