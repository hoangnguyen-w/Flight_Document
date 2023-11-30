using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable

namespace Flight_Document.Entity
{
    [Table("Group")]
    public class Group
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid GroupID { get; set; }

        [Required(ErrorMessage = "Enter Group Name")]
        [MaxLength(100)]
        public string GroupName { get; set; }

        public string Creator { get; set; }

        public DateTime CreateDateGroup { get; set; }

        public string Note { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }

        public virtual ICollection<GroupPermission> GroupPermissions { get; set; }
    }
}
