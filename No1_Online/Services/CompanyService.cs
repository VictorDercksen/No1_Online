using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using No1_Online.Components;
using No1_Online.Data;
using No1_Online.Interfaces;
using No1_Online.Models;
using ServiceStack;
using System.Threading;
using static No1_Online.Components.CompanyAutoComplete;

namespace No1_Online.Services
{
    public class CompanyService: ICompanyService
    {
        private readonly AppDbContext _context;

        private readonly ILogger<CompanyService> _logger;
        private static SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);
        public CompanyService(AppDbContext context, ILogger<CompanyService> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Company>> GetAllCompanies()
        {
            try
            {
                await _semaphore.WaitAsync();
                _logger.LogInformation("GetAllCompanies called");

                var companies = await _context.Companies.ToListAsync();

                _logger.LogInformation($"GetAllCompanies returned {companies.Count} companies");
                return companies;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred in GetAllCompanies");
                throw;
            }
            finally
            {
                _semaphore.Release();
            }
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
