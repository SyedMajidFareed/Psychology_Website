using System.ComponentModel.DataAnnotations;

namespace Website.Models
{
    public class ContentData : AuditModel
    {
        public string? Category { get; set; }
        [Required]
        [StringLength(100)]
        public string? Topic { get; set; }
        [Required]
        [MinLength(500)]
        public string? Description { get; set; }
    }
}
