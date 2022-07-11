using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MigrantWorkers.Models
{
    public class Embassy_User
    {
        [Key]
        public int Id { get; set; }

        public int? UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual User User { get; set; }

        public int? EmbassyID { get; set; }
        [ForeignKey("EmbassyID")]
        public virtual Embassy Embassy { get; set; }

        [Required]
        public string Fname { get; set; }
        [Required]
        public string Lname { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
