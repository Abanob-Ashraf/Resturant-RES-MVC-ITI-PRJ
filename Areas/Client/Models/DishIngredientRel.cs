using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models
{
    [Table("DishIngredientRel")]
    public class DishIngredientRel
    {
        [Key]
        [Required]
        public int DishIngredientRelId { get; set; }

        [Required]
        [ForeignKey("Dish")]
        [DisplayName("Dish")]
        public int DishId { get; set; }
        public Dish? Dish { get; set; }

        [Required]
        [ForeignKey("Ingredtient")]
        [DisplayName("Ingerdient")]
        public int IngerdientId { get; set; }
        public Ingerdient? Ingredtient { get; set; }
    }
}
