using Microsoft.EntityFrameworkCore;
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
                throw new ArgumentException($"Can't Find That Customer with Id: {id}");
            }
            return Ctx.Testimonials
                  .Include(tst => tst.Customer)
                  .Where(tst => tst.TestimonialsID == id).FirstOrDefault();
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
                Ctx.Testimonials.Update(Testimonials);
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
