using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models
{
    [Table("Tables")]
    public class Tables
    {
        [Key]
        public int TablesID { get; set; }

        [Required(ErrorMessage = "Enter Table Number")]
        public string TableNumber { get; set; }
        public int ChairsNumbers { get; set; }

        [InverseProperty("Tables")]
        public ICollection<Reservations>? Reservations { get; set; }

    }
}
