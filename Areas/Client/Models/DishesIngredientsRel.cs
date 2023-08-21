using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models
{
    [Table("DishesIngredientsRel")]
    public class DishesIngredientsRel
    {
        [Key]
        [Required]
        public int DishesIngredientsRelId { get; set; }

        [Required]
        [ForeignKey("Dishes")]
        public int DishId { get; set; }

        [Required]
        [ForeignKey("Ingredtients")]
        public int IngerdientId { get; set; }

        public Dish? Dishes { get; set; }

        public Ingerdients? Ingredtients { get; set; }
    }
}
