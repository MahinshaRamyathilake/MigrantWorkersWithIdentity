using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MigrantWorkers.Models
{
    [Keyless]
    public class Migrant_Worker_Input
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
        [Required]
        public string Fname { get; set; }
        [Required]
        public string Lname { get; set; }
        [Required]
        public string Fullname { get; set; }
        [Required]
        public string NameWithInit { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string ContactNo { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string Workplace { get; set; }
        [Required]
        public string Workplaceaddress { get; set; }
        [Required]
        public string AddressInSriLanka { get; set; }
        [Required]
        public int no_of_dependants { get; set; }
        [Required]
        public string Dob { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Visa_no { get; set; }
        [Required]
        public string Passport_no { get; set; }
        [Required]
        public string PassportExpDate { get; set; }
        public int? AgencyID { get; set; }
    }
}
