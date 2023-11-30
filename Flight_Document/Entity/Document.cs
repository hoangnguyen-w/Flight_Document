using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable

namespace Flight_Document.Entity
{
    [Table("Document")]
    public class Document
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid DocumentID { get; set; }


        [Required(ErrorMessage = "Enter Document Name")]
        [MaxLength(100)]
        public string DocumentName { get; set; }

        public float Version { get; set; }

        public string Note { get; set; }

        [Required]
        public byte[] DocumentFile { get; set; }

        public DateTime CreateDateDocument { get; set; }


        public Guid DocumentTypeID { get; set; }
        public virtual DocumentType DocumentType { get; set; }

        [ForeignKey("Flight")]
        public string FlightNo { get; set; }
        public virtual Flight Flight { get; set; }

        public virtual ICollection<GroupPermission> GroupPermissions { get; set; }

    }
}
