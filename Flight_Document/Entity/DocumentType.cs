using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable

namespace Flight_Document.Entity
{
    [Table("DocumentType")]
    public class DocumentType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid DocumentTypeID { get; set; }

        
        [Required(ErrorMessage ="Input your Document Type ")]
        [MaxLength(100)]
        public string DocumentTypeName { get; set; }

        public virtual ICollection<Document> Documents { get; set; }
    }
}
