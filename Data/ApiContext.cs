using Microsoft.EntityFrameworkCore;
using MyPublicAPI.Models;
using File = MyPublicAPI.Models.File;

namespace MyPublicAPI.Data
{
    public class ApiContext(DbContextOptions<ApiContext> options) : DbContext(options)
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Journal> Journals { get; set; }

        public DbSet<File> Files { get; set; }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<SubAccount> SubAccounts { get; set; }
        public DbSet<UserCompany> UserCompanies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<File>()
                .Property(f => f.Blob)
                .HasColumnType("varbinary(MAX)"); // Specify the SQL Server data type for the blob field
            modelBuilder.Entity<UserCompany>()
                .HasKey(uc => new { uc.UserId, uc.CompanyId });

            base.OnModelCreating(modelBuilder);
            // Seed data
            modelBuilder.Entity<Account>().HasData(
                new Account { Id = Guid.NewGuid(), AccountNumber = 1234, AccountName = "Main Account", AccountType = "Asset" },
                new Account { Id = Guid.NewGuid(), AccountNumber = 5678, AccountName = "Expense Account", AccountType = "Expense" }
            );

            modelBuilder.Entity<UserCompany>().HasData(
                new UserCompany { UserId = Guid.NewGuid(), CompanyId = Guid.NewGuid() },
                new UserCompany { UserId = Guid.NewGuid(), CompanyId = Guid.NewGuid() }
            );
        }

    }
}