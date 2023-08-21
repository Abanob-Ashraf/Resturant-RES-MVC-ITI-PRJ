using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models
{
    [Table("CustomersAddersses")]
    public class CustomerAddersses
    {
        [Key]
        public int CustomersAdderssesID { get; set; }

        public int CustAddressApartment { get; set; }
        public int CustAddressFloor { get; set; }
        public string CustAddressBuildingNo { get; set; }
        public string CustAddressStreet { get; set; }
        public string? CustAddressCity { get; set; }
        public string? CustAddressCounty { get; set; }

        [ForeignKey("Customers")]

        public int CustomerID { get; set; }

        public Customer? Customers { get; set; }

        public ICollection<Reservations>? Reservations { get; set; }


    }
}
