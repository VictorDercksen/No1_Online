using No1_Online.Models;
using Microsoft.AspNetCore.Identity;
namespace No1_Online.ViewModels
{
    public class CompanyVM
    {
        public Company company { get; set; } = new Company();

        public CompanyVM()
        {
           
            company.Address = new Address();
            company.Note = new Note();

        }

        public CompanyVM(Company company)
        {
            this.company = company;
        }
    }
}
