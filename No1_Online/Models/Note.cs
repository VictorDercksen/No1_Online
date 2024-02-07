using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace No1_Online.Models
{
    [Table("Notes")]
    public class Note
    {
        public int Id { get; set; }

        [Required]
        public string ProfileId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime Revision { get; set; }

    }
}
