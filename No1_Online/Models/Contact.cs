using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace No1_Online.Models
{
    [Table("Contacts")]
    public class Contact
    {
        public int Id { get; set; }
        [Required]
        
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Position { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string? Tel { get; set; }
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [Required]
        public DateTime Revision { get; set; }
        [Required]
        public int CompanyId { get; set; }
        public Company Company { get; set; }

    }
}
