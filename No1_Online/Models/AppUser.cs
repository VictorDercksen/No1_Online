using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace No1_Online.Models
{
    public class AppUser : IdentityUser
    {
        [StringLength(100)]
        [MaxLength((100))]
        [Required]
        public string? Name { get; set; }
        public string? Surname { get; set; }
    }
}
