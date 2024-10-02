using Microsoft.EntityFrameworkCore;
using MyPublicAPI.Models;
using File = MyPublicAPI.Models.File;

namespace MyPublicAPI.Data
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options): base(options) {}

        public DbSet<Product> Products { get; set; }
        public DbSet<Journal> Journals { get; set; }

        public DbSet<File> Files { get; set; }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<SubAccount> SubAccounts { get; set; }
        public DbSet<UserCompany> UserCompanys { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<File>()
                .Property(f => f.Blob)
                .HasColumnType("varbinary(MAX)"); // Specify the SQL Server data type for the blob field
             modelBuilder.Entity<UserCompany>()
                .HasNoKey();

            base.OnModelCreating(modelBuilder);
        }

    }
}