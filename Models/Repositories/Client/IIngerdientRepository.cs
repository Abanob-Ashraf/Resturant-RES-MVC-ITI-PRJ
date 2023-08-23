using Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models;

namespace Resturant_RES_MVC_ITI_PRJ.Models.Repositories.Client
{

    public interface IIngerdientRepository
    {
        public List<Ingerdient> GetAllIngerdients();
        
        public Ingerdient GetIngerdientById(int id);

        public void InsertIngerdient(Ingerdient Ingerdient);

        public void UpdateIngerdient(int id, Ingerdient Ingerdient);

        public void DeleteIngerdient(int id);
        void UpdateIngerdient(Ingerdient ingerdient);
    }
}
