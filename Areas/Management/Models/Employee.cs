using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.CodeAnalysis.Options;
using Resturant_RES_MVC_ITI_PRJ.Models;
using System.Configuration;
using Resturant_RES_MVC_ITI_PRJ.Models.DataAnnotation;
using System.ComponentModel;

namespace Resturant_RES_MVC_ITI_PRJ.Areas.Management.Models
{
    [Table("Employee")]
    [Index("EmpEmail", IsUnique = true)]
    [Index("EmpPhone", IsUnique = true)]
    [Index("EmpNationalId", IsUnique = true)]
    public class Employee
    {
        //public IConfiguration Configuration { get; set; }
        //public static string minDate { get; set; }
        //public Employee(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //    minDate = configuration["MinimumDate"].ToString();
        //}

        [Key]
        public int EmpID { get; set; }

        [Required(ErrorMessage = "You Must Enter First Name")]
        [StringLength(50)]
        [DisplayName("First Name")]
        public string EmpFirstName { get; set; }
        
        [Required(ErrorMessage = "You Must Enter Last Name")]
        [StringLength(50)]
        [DisplayName("Last Name")]
        public string EmpLastName { get; set; }

        [Required(ErrorMessage = "You Must Enter Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid Email Address")]
        [DisplayName("Email")]
        public string EmpEmail { get; set; }

        //[Required(ErrorMessage = "You Must Enter Password")]
        [DataType(DataType.Password)]
        //[RegularExpression("\"^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$\"\r\n", ErrorMessage = "Enter a strong passwor")]
        [DisplayName("Password")]
        public string? EmpPassword { get; set; }

        [RegularExpression(@"^(010|011|012|015)\d{8}$", ErrorMessage = "start with 010 | 011 | 012 | 015 and max 11 Diget")]
        [MaxLength(11)]
        [DisplayName("Mobile Phone")]
        public string EmpPhone { get; set; }

        [RegularExpression(@"^([1-9])\d{13}$", ErrorMessage = "max 14 Diget")]
        [MaxLength(14)]
        [DisplayName("National ID")]
        public string EmpNationalId { get; set; }

        [Required]
        [DisplayName("City")]
        public string City { get; set; }

        [Required]
        [DisplayName("Country")]
        public string Country { get; set; }

        [Required, DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [DateRange("01/01/2010")]
        [DisplayName("Hiring Date")]
        public DateTime EmpHiringDate { get; set; }

        [Required]
        [Range(1400.0, 50000.0, ErrorMessage = "Salary must be between {1} and {2}")]
        [DisplayName("Salary")]
        public double EmpSalary { get; set; } = 1400.0;

        [NotMapped]
        [DisplayName("Role")]
        public string RoleName { get; set; } 

        [ForeignKey("EmployeeCategory")]
        [DisplayName("Category")]
        public int EmpCategoryId { get; set; }
        public EmployeeCategory? EmployeeCategory { get; set; }

        [ForeignKey("Franchise")]
        [DisplayName("Franchise")]
        public int FranchiseId { get; set; }
        public Franchise? Franchise { get; set; }

        [InverseProperty("Manager")]
        public ICollection<Franchise>? Franchises { get; set; }
    }
}
