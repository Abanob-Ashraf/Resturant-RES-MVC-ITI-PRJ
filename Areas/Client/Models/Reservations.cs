using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models
{
    [Table("Reservations")]
    public class Reservations
    {
        [Key]
        public int ReservationID { get; set; }

        [MaxLength]
        public string Notes { get; set; }

        [ForeignKey("Customers")]
        public int CustomerID { get; set; }
        public Customers Customers { get; set; }

        [InverseProperty("Reservation")]
        public ICollection<ReservationTablesRel> ReservationTablesRels { get; set; }

    }
}
