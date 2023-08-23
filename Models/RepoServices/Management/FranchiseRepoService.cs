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
                try
                {
                    Ctx.Franchises.Add(franchise);
                    Ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        public void UpdateFranchise(int id, Franchise franchise)
        {
            var updatedFranchise = GetFranchiseById(id);
            if (franchise != null)
            {
                try
                {
                    updatedFranchise.FranchiseId = franchise.FranchiseId;
                    updatedFranchise.Street = franchise.Street;
                    updatedFranchise.City = franchise.City;
                    updatedFranchise.Country = franchise.Country;
                    updatedFranchise.ManagerId = franchise.ManagerId;

                    Ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        public void DeleteFranchise(int id)
        {
            var deletedFranchise = GetFranchiseById(id);
            if (deletedFranchise != null)
            {
                try
                {
                    Ctx.Franchises.Remove(deletedFranchise);
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
