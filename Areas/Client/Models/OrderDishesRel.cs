using System.ComponentModel.DataAnnotations.Schema;

namespace Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models
{
    [Table("OrderDishesRel")]
    public class OrderDishesRel
    {

        [Key]
        public int Id { get; set; }


        [Required]
        public int Quantity { get; set; }



        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public Order? Order { get; set; }


        [ForeignKey("Dish")]
        public int DishId { get; set; }
        public Dish? Dish { get; set; }
    }
}
