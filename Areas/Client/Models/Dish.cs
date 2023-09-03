using System.ComponentModel;
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
        [DisplayName("Dish Name")]
        public string DishName { get; set; }

        [Required]
        [DisplayName("Price")]
        public double DishPrice { get; set; }

        [Required]
        [DisplayName("Image")]
        public string DishImageName { get; set; }

        [ForeignKey("DishCategory")]
        [Required]
        [DisplayName("Category")]
        public int DishCategoryId { get; set; }
        public DishCategory? DishCategory { get; set; }

        public ICollection<DishIngredientRel>? DishIngredientRels { get; set; }
    }
}
