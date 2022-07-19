using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MigrantWorkers.Models
{
    [Keyless]
    public class Agency_User_Input
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Required]
        public string UserType { get; set; }
        [Required]
        public string status { get; set; }
        public int? AgencyID { get; set; }
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
