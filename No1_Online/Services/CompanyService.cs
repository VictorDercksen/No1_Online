using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using No1_Online.Data;
using No1_Online.Interfaces;
using No1_Online.Models;
using ServiceStack;

namespace No1_Online.Services
{
    public class CompanyService: ICompanyService
    {
        private readonly AppDbContext _context;

        public CompanyService(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Company>> AutoSearchCompany()
        {
            var companies = _context.Companies
                
                .ToList();

            
            return companies;
        }

        [HttpGet]
        public async Task<Company> SearchCompany(string companyName)
        {
           var company = await _context.Companies.Include(c => c.Address)
                .Include(c => c.Note).Include(c => c.Address)
                .Include(c => c.Note).FirstOrDefaultAsync(c => c.Name == companyName);


            return company;
        }

        [HttpGet]
        public async Task<List<Contact>> SearchContacts(Company company)
        {
            List<Contact> contacts = await _context.Contacts
               .Where(c => c.CompanyId == company.Id)
               .ToListAsync();


            return contacts;
        }
    }
}
