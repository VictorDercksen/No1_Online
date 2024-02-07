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
    public string? Cell { get; set; }
    
    }
}
