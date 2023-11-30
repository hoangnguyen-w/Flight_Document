using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable

namespace Flight_Document.Entity
{
    [Table("GroupPermission")]
    public class GroupPermission
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid GroupPermissionID { get; set; }

        public int StatusPermission { get; set; }

        public Guid GroupID { get; set; }
        public virtual Group Group { get; set; }

        public Guid DocumentID { get; set; }
        public virtual Document Document { get; set; }

    }
}
