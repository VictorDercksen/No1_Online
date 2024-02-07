﻿using System.ComponentModel.DataAnnotations;

namespace No1_Online.ViewModels
{
    public class RegisterVM
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public  string? Surname { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Compare("Password", ErrorMessage ="Passwords do not match.")]
        [Display(Name = "Confirm Password")]    
        public string? ConfirmPassword { get; set; }
    }
}
