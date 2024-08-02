using Microsoft.AspNetCore.Mvc;
using No1_Online.Components;
using No1_Online.Models;
using static No1_Online.Components.CompanyAutoComplete;

namespace No1_Online.Interfaces
{
    public interface ICompanyService
    {
        public Task<IEnumerable<Company>> GetAllCompanies();
        public Task<Company> SearchCompany(string companyName);
        public Task<List<Contact>> SearchContacts(Company company);
    }
}
