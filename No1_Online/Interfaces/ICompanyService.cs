using Microsoft.AspNetCore.Mvc;
using No1_Online.Models;

namespace No1_Online.Interfaces
{
    public interface ICompanyService
    {
        public  Task<IEnumerable<Company>> AutoSearchCompany();
        public Task<Company> SearchCompany(string companyName);
        public Task<List<Contact>> SearchContacts(Company company);
    }
}
