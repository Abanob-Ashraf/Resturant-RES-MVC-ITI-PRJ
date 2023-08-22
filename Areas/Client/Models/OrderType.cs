using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models
{
    [Table("OrderType")]
    public class OrderType
    {

        [Key]
        public int OrderTypeId { get; set; }

        [Required(ErrorMessage = "You Must Enter Order")]
        [StringLength(50)]
        public string OrderTypeName { get; set; }



        public ICollection<Order>? Orders { get; set; }
    }
}
