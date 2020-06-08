using GatewaysManager.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace GatewaysManager.DatabaseContext
{
    public class GatewaysManagerContext : DbContext
    {
        public GatewaysManagerContext(DbContextOptions<GatewaysManagerContext> context) : base(context)
        {

        }

        public DbSet<Gateway> Gateways { get; set; }

        public DbSet<Peripheral> Peripherals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Gateway>()
                .HasMany(c => c.Peripherals)
                .WithOne(e => e.Gateway)
                .HasForeignKey(e => e.GatewayId);
        }
    }
}
