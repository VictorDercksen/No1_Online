using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace No1_Online.Models
{
    [Table("Notes")]
    public class Note
    {
        public Note()
        {
            Id = 0; // This will be set by the database
            Description = string.Empty;
            Revision = DateTime.Now;
            LoadingSchedules = new List<LoadingSchedule>();
        }
        public int Id { get; set; }

       
        
        
        public string? Description { get; set; }
        
        
        public Nullable<DateTime> Revision { get; set; }
        public ICollection<LoadingSchedule> LoadingSchedules { get; set; }

    }
}
