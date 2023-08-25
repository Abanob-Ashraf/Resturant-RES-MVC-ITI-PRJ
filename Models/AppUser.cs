using Microsoft.AspNetCore.Identity;

namespace Resturant_RES_MVC_ITI_PRJ.Models
{
    public class AppUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Job { get; set; }
    }
}
