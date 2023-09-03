using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models
{
    [Table("Testimonials")]
    public class Testimonials
    {
        [Key]
        public int TestimonialsID { get; set; }

        [Required]
        [DisplayName("Testimonial")]
        public string TestimonialsText { get; set; }

        [DisplayName("Show In Website")]
        public bool ShownInWebsite { get; set; } = false;

        [ForeignKey("Customer")]
        [DisplayName("Customer")]
        public int CustomerID { get; set; }
        public Customer? Customer { get; set; }

    }
}
