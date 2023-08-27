//using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace Resturant_RES_MVC_ITI_PRJ.Models.ViewModels
{
    public class RegisterUserVM
    {
       

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Compare("Email")]
        public string ConfirmEmail { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        [RegularExpression(@"^(010|011|012|015)\d{8}$", ErrorMessage = "start with 010 | 011 | 012 | 015 and max 11 Diget")]
        [MaxLength(11)]
        public string  Phone { get; set; }
    }
}
