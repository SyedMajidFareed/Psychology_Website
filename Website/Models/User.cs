using System.ComponentModel.DataAnnotations;

namespace Website.Models
{
    public class User
    {
        //public int Id { get; set; }
        [Required (ErrorMessage = "Please Enter Name")]
        public string? Username { get; set; }

        [Required (ErrorMessage = "Please Enter Password")]
        public string? Password { get; set; }
        
        public string? Email{ get; set; }
        //public string Gender { get; set; }
    }
}
