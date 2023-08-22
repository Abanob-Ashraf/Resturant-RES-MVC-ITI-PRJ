using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models
{
    [Table("Tables")]
    public class Table
    {
        [Key]
        public int TableID { get; set; }

        [Required(ErrorMessage = "Enter Table Number")]
        public string TableNumber { get; set; }
        public int ChairsNumber { get; set; }

        [InverseProperty("Table")]
        public ICollection<Reservation>? Reservations { get; set; }

    }
}
