using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace L00177784_CA2_GolfApp.Data
{
    public class TeeTime
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Round Time")]
        public DateTime RoundDate { get; set; } = DateTime.Now.Date;

        public int RoundHour { get; set; } = 9;

        public int RoundMinute { get; set; }

        [Required]
        public int Player1Id { get; set; }
        public GolfMember Player1 { get; set; }

        [Required]
        public int Player2Id { get; set; }
        public GolfMember Player2 { get; set; }

        public int Player3Id { get; set; }
        public GolfMember Player3 { get; set; }

        public int Player4Id { get; set; }
        public GolfMember Player4 { get; set; }

    
        
    }
}
