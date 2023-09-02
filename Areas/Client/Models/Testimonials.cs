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
        public string TestimonialsText { get; set; }

        public bool ShownInWebsite { get; set; } = false;

        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        public Customer? Customer { get; set; }

    }
}
