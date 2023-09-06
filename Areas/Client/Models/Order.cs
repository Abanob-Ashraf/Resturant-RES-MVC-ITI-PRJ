using Resturant_RES_MVC_ITI_PRJ.Areas.Management.Models;
using Resturant_RES_MVC_ITI_PRJ.Models.DataAnnotation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models
{
    [Table("Order")]
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        [EnumDataType(typeof(OrderStates))]
        [DisplayName("Order State")]
        public OrderStates OrderState { get; set; }

        [Required, DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [DateRange]
        [DisplayName("Date")]
        public DateTime OrderDate { get; set; } = DateTime.Now;

        [Required]
        [EnumDataType(typeof(PaymentMethods))]
        [DisplayName("Payment Method")]
        public PaymentMethods PaymentMethod { get; set; }

        [Required]
        [DisplayName("Is Paid")]
        public bool IsPaid { get; set; }

        [ForeignKey("OrderType")]
        [DisplayName("Order Type")]
        public int OrderTypeId { get; set; }
        public OrderType? OrderType { get; set; }

        [ForeignKey("Customer")]
        [DisplayName("Customer")]
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }

        [ForeignKey("Franchise")]
        [DisplayName("Franchise")]
        public int FranchiseId { get; set; }
        public Franchise? Franchise { get; set; }

        public ICollection<OrderDishesRel>? OrderesDishesRels { get; set; }

        public enum PaymentMethods
        {
            Cash = 1,
            Visa = 2
        }
        
        public enum OrderStates
        {
            Prepering = 1,
            Moved = 2,
            Delevered = 3
        }
    }
}
