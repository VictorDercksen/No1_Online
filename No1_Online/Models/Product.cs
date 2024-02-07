using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace No1_Online.Models
{
    [Table("Products")]
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime Revision { get; set; }
    }
}
