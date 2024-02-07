using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace No1_Online.Models
{
    [Table("Vehicles")]
    public class Vehicle
    {
        public int Id { get; set; }
        [Required]
        public string Registration { get; set; }
        [Required]
        public DateTime Revision { get; set; }

        
    }
}
