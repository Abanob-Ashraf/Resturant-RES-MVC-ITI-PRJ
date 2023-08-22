using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models
{
    [Table("DishCategory")]

    public class DishCategory
    {
        [Key]
        public int DishCategoryId { get; set; }

        [Required]
        public string DishCategoryName { get; set; }

        public ICollection<Dish>? Dish { get; set; }
    }
}
