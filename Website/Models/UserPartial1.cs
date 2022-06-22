using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Website.Models
{
    public partial class UserTable
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter Name")]
        [StringLength(30)]
        public string? Username { get; set; }
        [Required(ErrorMessage = "Please enter Password")]
        [StringLength(30)]
        public string? Password { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }

    }
}
