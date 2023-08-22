using Resturant_RES_MVC_ITI_PRJ.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models
{
    [Table("Reservation")]
    public class Reservation
    {
        [Key]
        public int ReservationID { get; set; }

        [MaxLength]
        public string Notes { get; set; }

        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        public Customer? Customer { get; set; }

        [CustomMinDate(ErrorMessage = "Reservation Date Must be Further tahn today")]
        public DateTime ReservarionDate { get; set; }

        [ForeignKey("Table")]
        public int TableID { get; set; }
        public Table? Table { get; set; }


    }
}
