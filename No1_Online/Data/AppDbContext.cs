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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure the one-to-many relationship between Company and LoadingSchedule
            modelBuilder.Entity<Company>()
                .HasMany(c => c.LoadingSchedules)
                .WithOne(ls => ls.Company)
                .HasForeignKey(ls => ls.CompanyId);

            // Configure the one-to-many relationship between Vehicle and LoadingSchedule
            modelBuilder.Entity<Vehicle>()
                .HasMany(v => v.LoadingSchedules)
                .WithOne(ls => ls.Vehicle)
                .HasForeignKey(ls => ls.VehicleId)
                .IsRequired(false);  // Since VehicleId is nullable

            // Configure the one-to-many relationship between Note and LoadingSchedule
            modelBuilder.Entity<Note>()
                .HasMany(n => n.LoadingSchedules)
                .WithOne(ls => ls.Note)
                .HasForeignKey(ls => ls.NoteId)
                .IsRequired(false);  // Since NoteId is nullable

            // Ensure that other configurations like decimal precision are respected
            modelBuilder.Entity<Company>()
                .Property(c => c.CreditLimit)
                .HasColumnType("decimal(18,3)");

            modelBuilder.Entity<Vehicle>()
                .Property(v => v.GITValue)
                .HasColumnType("decimal(18,3)");

            modelBuilder.Entity<LoadingSchedule>()
                .HasOne<Company>(ls => ls.CompanyTrans)
                .WithMany()
                .HasForeignKey(ls => ls.CompanyTransId);
                

        }
    }


}
