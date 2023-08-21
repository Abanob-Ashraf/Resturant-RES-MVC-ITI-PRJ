using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models
{
    [Table("Testimonials")]
    public class Testimonials
    {
        [Key]
        public int TestimonialsID { get; set; }

        [MaxLength]
        public int TestimonialsText { get; set; }

        [ForeignKey("Customers")]
        public int CustomerID { get; set; }

        public Customers Customers { get; set; }

    }
}
