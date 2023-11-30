using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable

namespace Flight_Document.Entity
{
    [Table("Flight")]
    public class Flight
    {
        [Key]
        public string FlightNo { get; set; }


        [Required(ErrorMessage = "Enter Router")]
        [MaxLength(50)]
        public string Router { get; set; }


        [Required(ErrorMessage = "Enter Departure Date")]
        public DateTime DepartureDate { get; set; }


        [Required(ErrorMessage = "Enter Duration")]
        public TimeSpan Duration { get; set; }

        public int LocationID { get; set; }
        public virtual Location Location { get; set; }

        public int SecondLocationID { get; set; }

        public virtual ICollection<Document> Documents { get; set; }
    }
}
