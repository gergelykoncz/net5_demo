using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace EFDemo1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
