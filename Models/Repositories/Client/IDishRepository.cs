using Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models;

namespace Resturant_RES_MVC_ITI_PRJ.Models.Repositories.Client
{
    public interface IDishRepository
    {
        public List<Dish> GetAllDishes();

        public Dish GetDishById(int id);

        public void InsertDish(Dish dish);

        public void UpdateDish(int id, Dish dish);

        public void DeleteDish(int id);
    }
}
