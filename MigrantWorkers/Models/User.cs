using System.ComponentModel.DataAnnotations;

namespace MigrantWorkers.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string UserType { get; set; }
        [Required]
        public string status { get; set; }
    }
}
