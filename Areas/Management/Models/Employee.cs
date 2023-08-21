using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.CodeAnalysis.Options;

namespace Resturant_RES_MVC_ITI_PRJ.Areas.Management.Models
{
    [Table("Employee")]
    //[Index("EmpEmail", IsUnique = true)]
    //[Index("EmpPhone", IsUnique = true)]
    //[Index("EmpNationalId", IsUnique = true)]
    public class Employee
    {
        //FranchiseId int

        [Key]
        public int EmpID { get; set; }

        [Required(ErrorMessage = "You Must Enter Name")]
        [StringLength(50)]
        public string EmpName { get; set; }

        [Required(ErrorMessage = "You Must Enter Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid Email Address")]
        public string EmpEmail { get; set; }

        [RegularExpression(@"^(010|011|012|015)\d{8}$", ErrorMessage = "start with 010 | 011 | 012 | 015 and max 11 Diget")]
        [MaxLength(11)]
        public string EmpPhone { get; set; }

        [RegularExpression(@"^([1-9])\d{13}$", ErrorMessage = "max 14 Diget")]
        [MaxLength(14)]
        public string EmpNationalId { get; set; }

        [Range(typeof(DateTime), "1/1/1900", "31/12/3100", ErrorMessage = "Date must be between {1} and {2}")]
        public DateTime EmpHiringDate { get; set; }

        [Required]
        [Range(1400.0, 50000.0, ErrorMessage = "Salary must be between {1} and {2}")]
        public double EmpSalary { get; set; } = 1400.0;


        [ForeignKey("EmployeesCategories")]
        public int EmpCategoryId { get; set; }
        public EmployeesCategories? EmployeesCategories { get; set; }

        [ForeignKey("Franchise")]
        public int FranchiseId { get; set; }
        public Franchise? Franchise { get; set; }

        [InverseProperty("Manager")]
        public ICollection<Franchise>? Franchises { get; set; }
        public ICollection<EmployeeAddress>? EmployeeAddress { get; set; }
    }
}
