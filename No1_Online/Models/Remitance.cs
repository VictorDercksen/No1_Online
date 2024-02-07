using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace No1_Online.Models
{
    [Table("Remitances")]
    public class Remitance
    {
        public int Id { get; set; }

       

        public DateTime Poddate { get; set; }


        [Required]
        public string ProfileId { get; set; }
        [Required]
        public DateTime Duedate { get; set; }
        [Required]
        public DateTime PaymentDate { get; set; }
        [Required]

        [Column(TypeName = "decimal(10,4)")]
        public decimal Amount { get; set; }
        [Required]
        public string PaymentType { get; set; }
        [Required]
        public int InvoiceId { get; set; }
        public virtual Invoice Invoice { get; }
        [Required]
        public int LoadingScheduleId { get; set; }
        public virtual LoadingSchedule LoadingSchedule { get; set; }
    }
}
