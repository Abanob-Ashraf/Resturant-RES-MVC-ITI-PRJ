using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resturant_RES_MVC_ITI_PRJ.Models
{
    [Table("EmployeesCategories")]
    public class EmployeesCategories
    {
        [Key]
        public int EmployeesCategoriesId { get; set; }

        [Required]
        public string CategoryName { get; set; }

        public ICollection<Employee>? Employees { get; set; }
    }
}
