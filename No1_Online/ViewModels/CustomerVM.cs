using No1_Online.Models;

namespace No1_Online.ViewModels
{
    public class CustomerVM 
    {
        public Company company { get; set; }
        public CustomerVM(Company company)
        {
            this.company.Blocked = true;
            this.company = company;
        }
    }
}
