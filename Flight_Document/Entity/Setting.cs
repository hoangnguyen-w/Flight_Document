using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable

namespace Flight_Document.Entity
{
    [Table("Setting")]
    public class Setting
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Logo { get; set; }

        public bool StatusCapcha { get; set; }

        public Guid AccountID { get; set; }
        public virtual Account Account { get; set; }
    }
}
