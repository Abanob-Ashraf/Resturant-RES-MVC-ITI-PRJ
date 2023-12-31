﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models
{
    [Table("Ingredient")]
    public class Ingerdient
    {
        [Key]
        public int IngerdientId { get; set; }

        [Required]
        [DisplayName("Ingerdient")]
        public string IngName { get; set; }

        public ICollection<DishIngredientRel>? DishIngredientRels { get; set; }
    }
}
