using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resturant_RES_MVC_ITI_PRJ.Models
{
    [Table("DishesCategories")]

    public class DishesCategories
    {
        [Key]
        public int DishesCategoriesId { get; set; }

        [Required]
        public string DishesCategoriesName { get; set; }

        public ICollection<Dish>? Dishes { get; set; }
    }
}
