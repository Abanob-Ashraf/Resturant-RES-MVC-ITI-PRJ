using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resturant_RES_MVC_ITI_PRJ.Models
{
    [Table("EmployeeAddress")]
    public class EmployeeAddress
    {
        [Key]
        public int AddressId { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Country { get; set; }

        [ForeignKey("Employee")]
        public int EmpId { get; set; }

        public Employee? Employee { get; set; }
    }
}
