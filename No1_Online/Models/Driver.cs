using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace No1_Online.Models
{
    [Table("Drivers")]
    public class Driver
    {
        public int Id { get; set; }
        [Required]
    public string FirstName { get; set; }
        [Required]
    public string LastName { get; set; } = null!;
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string? Cell { get; set; }
    
    }
}
