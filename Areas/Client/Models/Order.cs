using Resturant_RES_MVC_ITI_PRJ.Areas.Management.Models;
using Resturant_RES_MVC_ITI_PRJ.Models.DataAnnotation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models
{
    [Table("Order")]
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        //[Required(ErrorMessage = "You Must Enter Order")]
        [StringLength(50)]
        public string? OrderState { get; set; }

        [Required, DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [DateRange]
        public DateTime OrderDate { get; set; } = DateTime.Now;

        [Required]
        [EnumDataType(typeof(PaymentMethods))]
        public PaymentMethods PaymentMethod { get; set; }

        //[ForeignKey("PaymentMethod")]
        //public int PaymentMethodId { get; set; }
        //public PaymentMethod? PaymentMethod { get; set; }

        [Required]
        public bool IsPaid { get; set; }

        [ForeignKey("OrderType")]
        public int OrderTypeId { get; set; }
        public OrderType? OrderType { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }

        [ForeignKey("Franchise")]
        public int FranchiseId { get; set; }
        public Franchise? Franchise { get; set; }

        public ICollection<OrderDishesRel>? OrderesDishesRels { get; set; }

        public enum PaymentMethods
        {
            Cash = 1,
            Visa = 2
        }
    }
}
