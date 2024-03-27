using Microsoft.EntityFrameworkCore;
using PortsCalculator.Core.Entities;

namespace PortsCalculator.Infra.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<Device> Devices { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DeviceConfiguration());
        }
    }
}
