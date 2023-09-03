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
                  .Include(tst => tst.Customer)
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

        public void InsertTestimonials(Testimonials testimonials)
        {
            if (testimonials != null)
            {
                try
                {
                    Ctx.Testimonials.Add(testimonials);
                    Ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        public void UpdateTestimonials(int id, Testimonials Testimonials)
        {
            var updatedTestimonials = GetTestimonialsById(id);
            if (updatedTestimonials != null)
            {
                try
                {
                    updatedTestimonials.CustomerID = Testimonials.CustomerID;
                    updatedTestimonials.TestimonialsText = Testimonials.TestimonialsText;
                    updatedTestimonials.ShownInWebsite = Testimonials.ShownInWebsite;
                    Ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        public void DeleteTestimonials(int id)
        {
            var deletedTestimonials = GetTestimonialsById(id);
            if (deletedTestimonials != null)
            {
                try
                {
                    Ctx.Testimonials.Remove(deletedTestimonials);
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
