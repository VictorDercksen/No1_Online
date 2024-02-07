using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using No1_Online.Models;

namespace No1_Online.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base((options))
        {
            
        }

        public  DbSet<Address> Addresses { get; set; }

        public DbSet<ClientPayment> ClientPayments { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<CreditAllocation> CreditAllocations { get; set; }

        public DbSet<Driver> Drivers { get; set; }

        public DbSet<Invoice> Invoices { get; set; }

        public DbSet<LoadingPoint> LoadingPoints { get; set; }

        public DbSet<LoadingSchedule> LoadingSchedules { get; set; }

        public DbSet<Note> Notes { get; set; }

        public DbSet<Product> Products { get; set; }


        public DbSet<Remitance> Remitances { get; set; }

        public DbSet<TransportedProduct> TransportedProducts { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }
    }
}
