using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace No1_Online.Models
{
    [Table("LoadingPoints")]
    public class LoadingPoint
    {
        public LoadingPoint()
        {
            Id = 0; // This will be set by the database
            Street = string.Empty;
            Suburb = string.Empty;
            City = string.Empty;
            PostalCode = 0;
            Revision = DateTime.Now;
        }
        public int Id { get; set; }
        
        public string? Street { get; set; }

        public string? Suburb { get; set; }

        public string? City { get; set; }
        [DataType(DataType.PostalCode)]
        public int? PostalCode { get; set; }

       
        public DateTime? Revision { get; set; }

        

    }
}
