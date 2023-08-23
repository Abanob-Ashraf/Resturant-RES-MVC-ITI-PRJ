using Microsoft.EntityFrameworkCore;
using Resturant_RES_MVC_ITI_PRJ.Areas.Management.Models;
using Resturant_RES_MVC_ITI_PRJ.Models.Repositories;

namespace Resturant_RES_MVC_ITI_PRJ.Models.RepoServices.Management
{
    public class FranchiseRepoService : IFranchiseRepository
    {
        public ResturantDbContext Ctx { get; }

        public FranchiseRepoService(ResturantDbContext ctx)
        {
            Ctx = ctx;
        }

        public List<Franchise> GetAllFranchises()
        {
            return Ctx.Franchises
                .Include(emp => emp.Manager)
                .Include(emp => emp.Employees)
                .Include(emp => emp.Orders).ToList();
        }

        public Franchise GetFranchiseById(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException($"Can't Find That Franchise with Id: {id}");
            }
            return Ctx.Franchises
                .Include(emp => emp.Manager)
                .Include(emp => emp.Employees)
                .Include(emp => emp.Orders)
                .Where(emp => emp.FranchiseId == id).SingleOrDefault();
        }

        public void InsertFranchise(Franchise franchise)
        {
            if (franchise != null)
            {
                Ctx.Franchises.Add(franchise);
                Ctx.SaveChanges();
            }
        }

        public void UpdateFranchise(Franchise franchise)
        {
            if (franchise != null)
            {
                Ctx.Franchises.Update(franchise);
                Ctx.SaveChanges();
            }
        }

        public void DeleteFranchise(int id)
        {
            Ctx.Franchises.Remove(GetFranchiseById(id));
            Ctx.SaveChanges();
        }
    }
}
