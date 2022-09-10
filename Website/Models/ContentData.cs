using System.ComponentModel.DataAnnotations;

namespace Website.Models
{
    public class ContentData
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string? Topic { get; set; }
        [Required]
        [MinLength(500)]
        public string? Description { get; set; }
    }
}
