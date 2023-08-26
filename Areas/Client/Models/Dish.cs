using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models
{
    [Table("Dish")]

    public class Dish
    {
        [Key]
        public int DishId { get; set; }

        [Required]
        public string DishName { get; set; }

        [Required]
        public double DishPrice { get; set; }

        [Required]
        public string DishImageName { get; set; }

        [ForeignKey("DishCategory")]
        [Required]
        public int DishCategoryId { get; set; }
        public DishCategory? DishCategory { get; set; }

        public ICollection<DishIngredientRel>? DishIngredientRels { get; set; }
    }
}
