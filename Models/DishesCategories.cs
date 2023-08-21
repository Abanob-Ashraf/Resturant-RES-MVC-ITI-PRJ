using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resturant_RES_MVC_ITI_PRJ.Models
{
    [Table("DishesCategorie")]

    public class DishesCategories
    {
        [Key]
        public int DishesCategoriesId { get; set; }

        [Required]
        public string DishCategoryName { get; set; }

        public ICollection<Dishes>? Dishes { get; set; }
    }
}
