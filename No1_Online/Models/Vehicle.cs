using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace No1_Online.Models
{
    [Table("Vehicles")]
    public class Vehicle
    {
        public int Id { get; set; }
        
        public string? Registration { get; set; }
        
        public DateTime? Revision { get; set; }

        [Column(TypeName = "decimal(18,3)")]
        [Display(Name = "Load Value:")]
        public decimal? GITValue { get; set; }
        public int? CompanyId { get; set; }

        public Company? Company { get; set; }
        public ICollection<LoadingSchedule> LoadingSchedules { get; set; }
    }
}
