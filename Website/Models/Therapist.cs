using System.ComponentModel.DataAnnotations;

namespace Website.Models
{
    public class Therapist
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Name")]
        [StringLength(30)]
        public string? TUsername { get; set; }
        [Required(ErrorMessage = "Please Enter Password")]
        [StringLength(30)]
        public string? TPassword { get; set; }
        [Required]
        [EmailAddress]
        public string? TEmail { get; set; }
        public string? TContactNum { get; set; }
        public string? imgPath { get; set; }
    }
}
