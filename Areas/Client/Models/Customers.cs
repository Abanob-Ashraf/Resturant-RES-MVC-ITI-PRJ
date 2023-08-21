﻿using Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resturant_RES_MVC_ITI_PRJ.Models
{
    [Table("Customers")]
    public class Customers
    {
        [Key]
        public int CustID { get; set; }
        [Required(ErrorMessage = "You Must Enter Customer Name")]
        [StringLength(50)]
        public string CustName { get; set; }

        [Required(ErrorMessage = "You Must Enter Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid Email Address")]
        public string CustEmail { get; set; }

        [Required(ErrorMessage = "You Must Enter Email")]
        [DataType(DataType.Password)]

        [RegularExpression("\"^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$\"\r\n", ErrorMessage = "Enter a strong passwor")]
        public string CustPassword { get; set; }

        [RegularExpression(@"^(010|011|012|015)\d{8}$", ErrorMessage = "start with 010 | 011 | 012 | 015 and max 11 Diget")]
        [MaxLength(11)]
        public string CustPhone { get; set; }

        [InverseProperty("Manager")]
        public ICollection<CustomersAddersses> CustomersAddersses { get; set; }
    }
}
