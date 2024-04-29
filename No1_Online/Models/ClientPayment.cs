using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace No1_Online.Models
{
    [Table("ClientPayments")]
    public class ClientPayment
    {

         public int Id { get; set; }
         [Column(TypeName = "decimal(10,4)")]
         public decimal? Discount { get; set; }

         [Required]
        public DateTime Date { get; set; }

        [Column(TypeName = "decimal(10,4)")]
        public decimal Amount { get; set; }

         [Column(TypeName = "decimal(10,4)")]
         public decimal? Credit { get; set; }
         
        public DateTime? Revision { get; set; }
        [Required]
        public int LoadingScheduleId { get; set; }
        public  LoadingSchedule LoadingSchedule { get; set; }
    }
}
