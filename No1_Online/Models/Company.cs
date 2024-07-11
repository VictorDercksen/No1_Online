using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace No1_Online.Models
{
    [Table("Companies")]
    public class Company
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name:")]
        public string Name { get; set; }
        [Required]
        public int ContactType { get; set; }
        
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        [Display(Name = "Tel:")]
        public string? Tel { get; set; }
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        [Display(Name = "Fax")]
        public string? Fax { get; set; }
        [Required]
        [Display(Name = "Bank Name:")]
        public  string? BankName { get; set; }
        [Display(Name = "Branch Code:")]
        public string? BranchCode { get; set; }
        
        [Display(Name = "Account Number:")]
        public string? AccountNumber { get; set; }
        
        [Display(Name = "VAT Number:")]
        public string? VATNo { get; set; }

        [Column(TypeName = "decimal(18,3)")]
        [Display(Name = "Cred Limit:")]
        public decimal? CreditLimit { get; set; }
        [Display(Name = "Terms:")]
        public int? Terms { get; set; }
        
        [Display(Name = "Marketer")]
        [Column(TypeName = "nvarchar(450)")]
        public string? ProfileId { get; set; }
        [Display(Name = "Markup:")]
        public int? Markup { get; set; }

        public string? GitName { get; set; }

        public Nullable<DateTime> GitDate { get; set; }
       
        //[DataType(DataType.EmailAddress)]
        [Display(Name = "Email LoadCon:")]
        public string? Email { get; set; }
        //[DataType(DataType.EmailAddress)]
        [Display(Name = "Email Remitance:")]
        public string? EmailRemitance { get; set; }
        //[DataType(DataType.EmailAddress)]
        [Display(Name = "Email Statements:")]
        public string? EmailStatements { get; set; }
        [Display(Name = "Group:")]
        public string? Group { get; set; }
        [Display(Name = "Blocked:")]
        public bool  Blocked { get; set; }
        [Display(Name = "Override:")]
        public bool Override { get; set; }
        [Display(Name = "Closing Date:")]
        public Nullable<DateTime> ClosingDate { get; set; }
        [Display(Name = "POD Closing date:")]

        public Nullable<DateTime> PodclosingDate { get; set; }
        
        public int? AddressId { get; set; }
        public Address? Address { get; set; }

        public List<Contact> Contacts { get; set; } = new List<Contact>();

        public List<LoadingSchedule> LoadingSchedules { get; set; } = new List<LoadingSchedule>();
        public int? NoteId { get; set; }
        public Note? Note { get; set; }
    }
}
