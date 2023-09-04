using Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models;

namespace Resturant_RES_MVC_ITI_PRJ.Models.Repositories.Client
{
    public interface ITestimonialsRepository
    {
        public List<Testimonials> GetAllTestimonials();

        public Testimonials GetTestimonialsById(int id);

        public void InsertTestimonials(Testimonials Testimonials);

        public void UpdateTestimonials(int id, Testimonials Testimonials);

        public void DeleteTestimonials(int id);
    }
}
