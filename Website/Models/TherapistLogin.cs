using System.ComponentModel.DataAnnotations;

namespace Website.Models
{
    public class TherapistLogin
    {
        public int Id{ get; set; }
        [Required(ErrorMessage = "Please enter Name")]
        [StringLength(30)]
        public string? TUsername { get; set; }

        [Required(ErrorMessage = "Please enter Password")]
        [StringLength(30)]
        public string? TPassword { get; set; }
    }
}
