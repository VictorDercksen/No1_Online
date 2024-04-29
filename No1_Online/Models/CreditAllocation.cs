using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace No1_Online.Models
{
    [Table("CreditAllocations")]
    public class CreditAllocation
    {
        public int Id { get; set; }

        [Column(TypeName = "decimal(18,3)")]
        [Required]  
        public decimal Amount { get; set; }
        [Required]
        public DateTime Date { get; set; }
        
        public DateTime? Revision { get; set; }
        [Required]
        public int LoadingScheduleId { get; set; }
        public LoadingSchedule LoadingSchedule { get; set; }
    }
}
