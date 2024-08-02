using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace No1_Online.Models
{
    [Table("TransportedProducts")]
    public class TransportedProduct
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,3)")]
        public decimal LoadRate { get; set; }
        [Required]  
        [Column(TypeName = "decimal(18,3)")]
        public decimal PaymentRate { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,3)")]
        public decimal Quantity { get; set; }

        [NotMapped]
        public decimal ClientVAT = 15;
        [NotMapped]
        public decimal TransporterVAT = 15;
        public DateTime? Revision { get; set; }
        
        [Required]  
        public int LoadingScheduleId { get; set; }  
        public virtual LoadingSchedule LoadingSchedule { get; set; }
        [Required]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
