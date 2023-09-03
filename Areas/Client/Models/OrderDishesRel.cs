using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models
{
    [Table("OrderDishesRel")]
    public class OrderDishesRel
    {
        [Key]
        public int OrderDishesRelId { get; set; }

        [Required]
        [DisplayName("Quantity")]
        public int Quantity { get; set; }

        [ForeignKey("Order")]
        [DisplayName("Order")]
        public int OrderId { get; set; }
        public Order? Order { get; set; }

        [ForeignKey("Dish")]
        [DisplayName("Dish")]
        public int DishId { get; set; }
        public Dish? Dish { get; set; }
    }
}
