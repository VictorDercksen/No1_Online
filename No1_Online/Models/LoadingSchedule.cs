using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace No1_Online.Models
{
    [Table("LoadingSchedules")]
    public class LoadingSchedule
    {
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string PurchaseOrder { get; set; }


        public string? SubReg { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,4)")]

        public decimal Value { get; set; }

        public string? LoadInstruction { get; set; }
        [Required]
        public string ProfileId { get; set; }


        public int? Podnum { get; set; }

        public int Depo { get; set; }

        public string? PayTerms { get; set; }


        public bool SelfLoad { get; set; }

        [Required]  
        public DateTime Revision { get; set; }
        [Required]
        public int CompanyId { get; set; }
        public  Company Company { get; }
        [Required]
        public int DriverId { get; set; }    
        public virtual Driver Driver { get; set; }

        [Required]
        public int LoadingPointLoadId { get; set; }
        public LoadingPoint LoadingPointLoad { get; }
        [Required]
        public int LoadingPointOffId { get; set; }
        public  LoadingPoint LoadingPointOff { get; } 

        public int? NoteId { get; set; }
        public  Note? Note { get; set; }
        [Required]
        public int VehicleId { get; set; }  
        public Vehicle Vehicle { get; set; } 
    }
}
