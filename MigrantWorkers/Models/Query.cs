using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MigrantWorkers.Models
{
    public class Query
    {
        [Key]
        public int Id { get; set; }

        public int? UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual User User { get; set; }

        public string To { get; set; }

        public int? AgencyID { get; set; }
        [ForeignKey("AgencyID")]
        public virtual Agency Agency { get; set; }

        public int? EmbassyID { get; set; }
        [ForeignKey("EmbassyID")]
        public virtual Embassy Embassy { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
