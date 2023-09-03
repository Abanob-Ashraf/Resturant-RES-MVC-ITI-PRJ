using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resturant_RES_MVC_ITI_PRJ.Areas.Management.Models
{
    [Table("EmployeeCategory")]
    public class EmployeeCategory
    {
        [Key]
        public int EmployeeCategoryId { get; set; }

        [Required]
        [DisplayName("Category")]
        public string CategoryName { get; set; }

        public ICollection<Employee>? Employees { get; set; }
    }
}
