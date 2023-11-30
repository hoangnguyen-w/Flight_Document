using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable

namespace Flight_Document.Entity
{
    [Table("Account")]
    public class Account
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public Guid AccountID { get; set; }


        [MaxLength(100)]
        public string AccountName { get; set; }


        [Required(ErrorMessage = "Enter Password")]
        [MaxLength(50)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [MaxLength(200)]
        [Required(ErrorMessage = "Enter Account Email")]
        [RegularExpression(@"^.*@vietjetair\.com$", ErrorMessage = "Email must have the domain @vietjetair.com")]
        public string Email { get; set; }

        [MaxLength(20)]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Input your Number")]
        public string Phone { get; set; }

        public string Image { get; set; }

        public bool StatusTerminate { get; set; }

        public Guid RoleID { get; set; }
        public virtual Role Role { get; set; }

        public Guid GroupID { get; set; }
        public virtual Group Group { get; set; }

        public virtual ICollection<Setting> Settings { get; set; }  
    }
}
