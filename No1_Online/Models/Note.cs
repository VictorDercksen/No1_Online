using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace No1_Online.Models
{
    [Table("Notes")]
    public class Note
    {

        public int Id { get; set; }

       
        [Required]
        
        public string Description { get; set; }
        
        
        public Nullable<DateTime> Revision { get; set; }
        public ICollection<LoadingSchedule> LoadingSchedules { get; set; }

    }
}
