using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace No1_Online.Models
{
    [Table("LoadingSchedules")]
    public class LoadingSchedule
    {
        [Display(Name = "Load Id:")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Loading Date:")]
        public DateTime Date { get; set; }

        
        [Display(Name = "Client References Number:")]
        public string? PurchaseOrder { get; set; }

        [Display(Name = "Sub Reg Number:")]
        public string? SubReg { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,4)")]
        [Display(Name = "Load Value:")]
        public decimal Value { get; set; }
        [Display(Name = "Load Instructions:")]
        public string? LoadInstruction { get; set; }
        [Required]
        [Display(Name = "Marketer:")]
        public string ProfileId { get; set; }

        [Display(Name = "POD Number:")]
        public int? Podnum { get; set; }

        public int Depo { get; set; }
        [Display(Name = "Payment Terms:")]
        public string? PayTerms { get; set; }

        [Display(Name = "Self Load:")]
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
