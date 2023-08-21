using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resturant_RES_MVC_ITI_PRJ.Models
{
    [Table("Dishe")]

    public class Dishes
    {
        

        [Key]
        public int DishesId { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public string ImageName { get; set; }


        [ForeignKey("DishesCategories")]
        public int DishCategoryId { get; set; }

        public DishesCategories? DishesCategories { get; set; }

    }
}
