using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MigrantWorkers.Models
{
    public class Migrant_Worker
    {
        [Key]
        public int Id { get; set; }
        public int? UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual User User { get; set; }
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
        [ForeignKey("AgencyID")]
        public virtual Agency Agency { get; set; }
    }
}
