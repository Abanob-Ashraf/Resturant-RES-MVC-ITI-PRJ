using Microsoft.EntityFrameworkCore;
using Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models;
using Resturant_RES_MVC_ITI_PRJ.Models.Repositories.Client;

namespace Resturant_RES_MVC_ITI_PRJ.Models.RepoServices.Client
{
    public class TableRepoService : ITableRepository
    {
        public ResturantDbContext Ctx { get; }

        public TableRepoService(ResturantDbContext ctx)
        {
            Ctx = ctx;
        }

        public List<Table> GetAllTables()
        {
            return Ctx.Tables
                  .Include(tab => tab.Reservations)
                  .ToList();
        }

        public Table GetTableById(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException($"Can't Find That Table with Id: {id}");
            }
            return Ctx.Tables
                  .Include(tab => tab.Reservations)
                  .Where(tab => tab.TableID == id).SingleOrDefault();
        }

        public void InsertTable(Table Table)
        {
            if (Table != null)
            {
                try
                {
                    Ctx.Tables.Add(Table);
                    Ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        public void UpdateTable(Table Table)
        {
            if (Table != null)
            {
                try
                {
                    Ctx.Tables.Update(Table);
                    Ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        public void DeleteTable(int id)
        {
            var deleted = GetTableById(id);
            if(deleted != null)
            {
                try
                {
                    Ctx.Tables.Remove(deleted);
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
