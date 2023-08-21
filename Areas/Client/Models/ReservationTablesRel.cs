using Resturant_RES_MVC_ITI_PRJ.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models
{
    [Table("ReservationTablesRel")]
    public class ReservationTablesRel
    {
        [Key]
        public int ReservationTablesRelID { get; set; }

        [ForeignKey("Reservation")]
        public int ReservationID { get; set; }

        [ForeignKey("Tables")]
        public int TableID { get; set; }

        [CustomMinDate(ErrorMessage = "Reservation Date Must be Further tahn today")]
        public DateTime ReservarionDate { get; set; }
        public Reservations? Reservation { get; set; }

        public Tables? Tables { get; set; }
    }
}
