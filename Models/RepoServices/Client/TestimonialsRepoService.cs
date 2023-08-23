using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models;
using Resturant_RES_MVC_ITI_PRJ.Models.Repositories.Client;

namespace Resturant_RES_MVC_ITI_PRJ.Models.RepoServices.Client
{
    public class TestimonialsRepoService : ITestimonialsRepository
    {
        public ResturantDbContext Ctx { get; }

        public TestimonialsRepoService(ResturantDbContext ctx)
        {
            Ctx = ctx;
        }

        public List<Testimonials> GetAllTestimonials()
        {
            return Ctx.Testimonials
                  .Include(tst=>tst.Customer)
                  .ToList();
        }

        public Testimonials GetTestimonialsById(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException($"Can't Find That Testimonials with Id: {id}");
            }
            return Ctx.Testimonials
                  .Include(tst => tst.Customer)
                  .Where(tst => tst.TestimonialsID == id).SingleOrDefault();
        }

        public void InsertTestimonials(Testimonials Testimonials)
        {
            if (Testimonials != null)
            {
                Ctx.Testimonials.Add(Testimonials);
                Ctx.SaveChanges();
            }
        }

        public void UpdateTestimonials(int id, Testimonials Testimonials)
        {
            if (Testimonials != null)
            {
                var updatedTestimonials = GetTestimonialsById(id);
                updatedTestimonials.CustomerID = Testimonials.CustomerID;
                updatedTestimonials.TestimonialsText = Testimonials.TestimonialsText;
                Ctx.SaveChanges();
            }
        }

        public void DeleteTestimonials(int id)
        {
            Ctx.Testimonials.Remove(GetTestimonialsById(id));
            Ctx.SaveChanges();
        }
    }
}
