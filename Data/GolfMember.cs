using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace L00177784_CA2_GolfApp.Data
{
    public class GolfMember
    {
        [Key]
        public int MemberID { get; set; }

        [Display(Name = "First Name")]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(100)]
        public string LastName { get; set; }

        [StringLength(6)]
        public string Sex { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; }

        [Range(0, 36, ErrorMessage = "Please enter a value between 0-26 for Male memebers and 0-36 for female members")]
        public int Handicap { get; set; }

    }
}
