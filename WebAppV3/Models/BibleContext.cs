using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace WebAppV3.Models
{
    public class BibleContext : DbContext
    {
        public BibleContext(DbContextOptions<BibleContext> options)
            : base(options)
        {
        }

        public DbSet<BibleItem> BibleItems { get; set; } = null!;
    }
}