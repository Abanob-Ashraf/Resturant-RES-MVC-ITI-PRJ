using Microsoft.EntityFrameworkCore;
using Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models
{
    [Table("Customer")]
    [Index("CustEmail", IsUnique = true)]
    [Index("CustPhone", IsUnique = true)]
    public class Customer
    {
        [Key]
        public int CustID { get; set; }
        [Required(ErrorMessage = "You Must Enter Customer Name")]
        [StringLength(50)]
        [DisplayName("Customer Name")]
        public string CustName { get; set; }

        [Required(ErrorMessage = "You Must Enter Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid Email Address")]
        [DisplayName("Email")]
        public string CustEmail { get; set; }

        [Required(ErrorMessage = "You Must Enter Email")]
        [DataType(DataType.Password)]
        [RegularExpression("\"^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$\"\r\n", ErrorMessage = "Enter a strong passwor")]
        public string CustPassword { get; set; }

        [RegularExpression(@"^(010|011|012|015)\d{8}$", ErrorMessage = "start with 010 | 011 | 012 | 015 and max 11 Diget")]
        [MaxLength(11)]
        [DisplayName("Phone Number")]
        public string CustPhone { get; set; }

        [InverseProperty("Customer")]
        public ICollection<CustomerAddersses>? CustomerAddersses { get; set; }

        [InverseProperty("Customer")]
        public ICollection<Testimonials>? Testimonials { get; set; }

        [InverseProperty("Customer")]
        public ICollection<Reservation>? Reservations { get; set; }

        [InverseProperty("Customer")]
        public ICollection<Order>? Orders { get; set; }

    }
}
