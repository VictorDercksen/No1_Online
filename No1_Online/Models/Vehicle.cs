using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace No1_Online.Models
{
    [Table("Vehicles")]
    public class Vehicle
    {
        public Vehicle()
        {
            Id = 0; // This will be set by the database
            Registration = string.Empty;
            Revision = DateTime.Now;
            GITValue = 0m;
            CompanyId = 0;
            Company = new Company();
            LoadingSchedules = new List<LoadingSchedule>();
        }
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
