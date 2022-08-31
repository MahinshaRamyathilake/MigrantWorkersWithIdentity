using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MigrantWorkers.Models
{
    public class FamilyDetail
    {
        [Key]
        public int Id { get; set; }
        public int? UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual User User { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ContactNo { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Relationship { get; set; }
    }
}
