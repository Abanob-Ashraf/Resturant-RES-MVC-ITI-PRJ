using Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models;

namespace Resturant_RES_MVC_ITI_PRJ.Models.Repositories.Client
{
    public interface IDishIngredientRelRepository
    {
        public List<DishIngredientRel> GetAllDishIngredientRels();

        public DishIngredientRel GetDishIngredientRelById(int id);

        public void InsertDishIngredientRel(DishIngredientRel dishIngredientRel);

        public void UpdateDishIngredientRel(int id, DishIngredientRel dishIngredientRel);

        public void DeleteDishIngredientRel(int id);
    }
}
