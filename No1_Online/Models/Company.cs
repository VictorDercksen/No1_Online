using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace No1_Online.Models
{
    [Table("Companies")]
    public class Company
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Tel { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string? Fax { get; set; }
        [Required]
        public  string BankName { get; set; }
        public string? BranchCode { get; set; }
        [Required]
        public string AccountNumber { get; set; }

        [Column(TypeName = "decimal(10,4)")]
        public decimal? CreditLimit { get; set; }

        public int? Terms { get; set; }
        [Required]
        public string ProfileId { get; set; }

        public int Markup { get; set; }

        public string? GitName { get; set; }

        public DateTime? GitDate { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.EmailAddress)]
        
        public string? EmailRemitance { get; set; }
        [DataType(DataType.EmailAddress)]
        public string? EmailStatements { get; set; }


        public bool Blocked { get; set; }

        public bool Override { get; set; }

        public DateTime? PodclosingDate { get; set; }
        [Required]
        public int AddressId { get; set; }
        public Address Address { get; set; }

        public List<Contact> Contacts { get; set; } = new List<Contact>();

        public List<LoadingSchedule> LoadingSchedules { get; set; } = new List<LoadingSchedule>();
        public int NoteId { get; set; }
        public Note? Note { get; set; }
    }
}
