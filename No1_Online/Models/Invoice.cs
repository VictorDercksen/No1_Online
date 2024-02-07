using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace No1_Online.Models
{
    [Table("Invoices")]
    public class Invoice
    {
        public int Id { get; set; }
        [Required]
        public int GroupAllocation { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public DateTime Revision { get; set; }
        [Required]
        public int LoadingScheduleId { get; set; }
        public LoadingSchedule LoadingSchedule { get; set; }

    }
}
