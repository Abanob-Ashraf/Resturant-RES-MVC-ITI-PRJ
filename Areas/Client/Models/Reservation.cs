using Resturant_RES_MVC_ITI_PRJ.Areas.Management.Models;
using Resturant_RES_MVC_ITI_PRJ.Models;
using Resturant_RES_MVC_ITI_PRJ.Models.DataAnnotation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models
{
    [Table("Reservation")]
    public class Reservation
    {
        [Key]
        public int ReservationID { get; set; }

        [Required]
        [DisplayName("Note")]
        public string Notes { get; set; }

        [ForeignKey("Customer")]
        [DisplayName("Customer")]
        public int CustomerID { get; set; }
        public Customer? Customer { get; set; }

        [Required, DataType(DataType.Date)]
        [CustomMinDate(ErrorMessage = "Reservation Date Must be Further tahn today")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [DisplayName("Reservarion Date")]
        public DateTime ReservarionDate { get; set; }

        [Required]
        [RegularExpression(@"^([1-6])\d{0}$", ErrorMessage = "Max is 6 Guestes")]
        [MaxLength(1)]
        [DisplayName("No Of Guests")]
        public int NoOfGuests { get; set; }

        [ForeignKey("Franchise")]
        [DisplayName("Franchise")]
        public int FranchiseID { get; set; }
        public Franchise? Franchise { get; set; }
    }
}
