using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable

namespace Flight_Document.Entity
{
    [Table("Role")]
    public class Role
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public Guid RoleId { get; set; }

            
        [Required(ErrorMessage = "Enter Role Name")]
        public string RoleName { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
