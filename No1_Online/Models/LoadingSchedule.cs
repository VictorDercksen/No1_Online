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
        [Display(Name = "Transporter:")]
        public int CompanyTransId { get; set; }
        
        public Company CompanyTrans { get; set; }
        [Display(Name = "Client References Number:")]
        public string? PurchaseOrder { get; set; }

        [Display(Name = "Sub Reg Number:")]
        public string? SubReg { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,3)")]
        [Display(Name = "Load Value:")]
        public decimal Value { get; set; }
        [Display(Name = "Load Instructions:")]
        public string? LoadInstruction { get; set; }
        [Required]
        [Display(Name = "Marketer:")]
        public string ProfileId { get; set; }

        [Display(Name = "POD Number:")]
        public string? Podnum { get; set; }

        public int? Depo { get; set; }
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
        public int LoadingPointLoadId { get; set; }
        public LoadingPoint LoadingPointLoad { get; set; }
        [Required]
        public int LoadingPointOffId { get; set; }
        public  LoadingPoint LoadingPointOff { get; set; } 

        public int? NoteId { get; set; }
        public  Note? Note { get;  }
        
        public int? VehicleId { get; set; }  
        public Vehicle Vehicle { get; set; } 
    }
}
