using Microsoft.EntityFrameworkCore;
using TestApp.Domain.Entities;
using TestApp.Infrastructure.Configurations;

namespace TestApp.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet <CSV> CSV { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            base.OnModelCreating(mb);

            mb.ApplyConfiguration(new CSVConfoguration());
        }
    }
}
