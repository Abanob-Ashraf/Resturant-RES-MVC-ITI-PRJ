using Microsoft.EntityFrameworkCore;
using Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models;
using Resturant_RES_MVC_ITI_PRJ.Models.Repositories.Client;

namespace Resturant_RES_MVC_ITI_PRJ.Models.RepoServices.Client
{
    public class IngerdientRepoService : IIngerdientRepository
    {

        public ResturantDbContext Ctx { get; }

        public IngerdientRepoService(ResturantDbContext ctx)
        {
            Ctx = ctx;
        }

        public List<Ingerdient> GetAllIngerdients()
        {
            return Ctx.Ingerdients
                 .Include(Ingerdient => Ingerdient.DishIngredientRels)
                 .ToList();
        }

        public Ingerdient GetIngerdientById(int id)
        {

            if (id == 0)
            {
                throw new ArgumentException($"Can't Find That Dish with Id: {id}");
            }
            return Ctx.Ingerdients
                .Include(Ingerdient => Ingerdient.DishIngredientRels)
               .Where(Ingerdient => Ingerdient.IngerdientId == id).SingleOrDefault();
        }

        public void InsertIngerdient(Ingerdient Ingerdient)
        {
            Ctx.Ingerdients.Add(Ingerdient);
            Ctx.SaveChanges();
        }

        public void UpdateIngerdient(int id, Ingerdient Ingerdient)
        {
            Ctx.Ingerdients.Update(Ingerdient);
            Ctx.SaveChanges();
        }

        public void DeleteIngerdient(int id)
        {
            Ctx.Ingerdients.Remove(GetIngerdientById(id));
            Ctx.SaveChanges();
        }
    }
}
