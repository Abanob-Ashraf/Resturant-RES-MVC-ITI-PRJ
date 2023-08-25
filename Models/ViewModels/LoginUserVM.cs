using System.ComponentModel.DataAnnotations;

namespace Resturant_RES_MVC_ITI_PRJ.Models.ViewModels
{
    public class LoginUserVM
    {
        

        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RemeberMe { get; set; }
    }
}
