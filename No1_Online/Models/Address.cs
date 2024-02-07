using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace No1_Online.Models
{
    [Table("Addresses")]
    public class Address
    {
        
        public int Id { get; set; }

        [Required]
        public string Address1 { get; set; }
        [Required]
        public string Address2 { get; set; }

        public string? Address3 { get; set; }

        public string? PhysicalAddress1 { get; set; }

        public string? PhysicalAddress2 { get; set; }

        public string? PhysicalAddress3 { get; set; }
        [Required]
        public int PostcalCode { get; set; }

        public int? PhysicalPostalCode { get; set; }

        
    }
}
