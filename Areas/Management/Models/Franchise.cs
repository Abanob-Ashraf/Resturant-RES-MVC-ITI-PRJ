using Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resturant_RES_MVC_ITI_PRJ.Areas.Management.Models
{
    [Table("Franchise")]
    public class Franchise
    {
        [Key]
        public int FranchiseId { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Country { get; set; }

        [ForeignKey("Manager")]
        public int ManagerId { get; set; }
        public Employee? Manager { get; set; }

        [InverseProperty("Franchise")]
        public ICollection<Employee>? Employees { get; set; }

        public ICollection<Order>? Orders { get; set; }
    }
}
