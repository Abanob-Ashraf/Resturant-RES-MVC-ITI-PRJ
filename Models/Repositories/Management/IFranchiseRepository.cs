using Resturant_RES_MVC_ITI_PRJ.Areas.Management.Models;

namespace Resturant_RES_MVC_ITI_PRJ.Models.Repositories
{
    public interface IFranchiseRepository
    {

        public List<Franchise> GetAllFranchises();

        public Franchise GetFranchiseById(int id);

        public void InsertFranchise(Franchise franchise);

        public void UpdateFranchise(int id, Franchise franchise);

        public void DeleteFranchise(int id);
    }
}
