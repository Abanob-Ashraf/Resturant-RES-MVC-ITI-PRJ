using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace Resturant_RES_MVC_ITI_PRJ.Models
{
    public class ExternalLoginModel
    {
   



            [Required]
            [EmailAddress]
            public string Email { get; set; }

            public ClaimsPrincipal Principal { get; set; }

        }
    }




