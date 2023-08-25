using System.ComponentModel.DataAnnotations;

namespace Resturant_RES_MVC_ITI_PRJ.Models.ViewModels
{
    public class roleVM
    {
        [Required]
        public string RoleName { get; set; }
    }
}
