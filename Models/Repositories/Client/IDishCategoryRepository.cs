using Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models;

namespace Resturant_RES_MVC_ITI_PRJ.Models.Repositories.Client
{
    public interface IDishCategoryRepository
    {
        public List<DishCategory> GetAllDishCategories();

        public DishCategory GetDishCategoryById(int id);

        public void InsertDishCategory(DishCategory dishCategory);

        public void UpdateDishCategory(DishCategory dishCategory);

        public void DeleteDishCategory(int id);
    }
}
