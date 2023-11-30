using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable

namespace Flight_Document.Entity
{
    [Table("Location")]
    public class Location
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LocationID { get; set; }

        public string LocationName { get; set; }

        public virtual ICollection<Flight> Flights { get; set; }
        //public virtual ICollection<Flight> SecondLocationIDs { get; set; }
    }
}
