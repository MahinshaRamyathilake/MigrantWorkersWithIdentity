using System.ComponentModel.DataAnnotations;

namespace MigrantWorkers.Models
{
    public class Embassy
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string Ambassador { get; set; }
        [Required]
        public string Contact_No { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
