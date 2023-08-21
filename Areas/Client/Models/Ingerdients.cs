using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models
{
    [Table("Ingredient")]
    public class Ingerdients
    {
        [Key]

        public int IngerdientsId { get; set; }
        [Required]
        public string IngName { get; set; }


        public virtual ICollection<DishesIngredientsRel>? DishesIngredientsRel { get; set; }
    }
}
