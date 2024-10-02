using Microsoft.EntityFrameworkCore;
using MyPublicAPI.Models;

namespace MyPublicAPI.Data
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options): base(options) {}

        public DbSet<Product> Products { get; set; }
    }
}