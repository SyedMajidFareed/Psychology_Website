using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Website.Models
{
    public partial class UserTable
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Name")]
        [StringLength(30)]
        public string? Username { get; set; }
        [Required(ErrorMessage = "Please Enter Password")]
        [StringLength(30)]
        public string? Password { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        public string? imgPath { get; set; }

    }
}
