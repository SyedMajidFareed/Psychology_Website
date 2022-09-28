using System.ComponentModel.DataAnnotations;

namespace Website.Models
{
    public class UserContent
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter Name")]
        [StringLength(30)]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Please enter Password")]
        [StringLength(30)]
        public string? Password { get; set; }
        public string? Category { get; set; }
        [Required]
        [StringLength(100)]
        public string? Topic { get; set; }
        [Required]
        [MinLength(500)]
        public string? Description { get; set; }
    }
}
