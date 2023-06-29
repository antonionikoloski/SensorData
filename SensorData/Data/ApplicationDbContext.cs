using Microsoft.EntityFrameworkCore;
using SensorData.Models;
using SensorData.Models;


namespace SensorData.Data
{
    public class SensorDataContext : DbContext
    {
        public SensorDataContext(DbContextOptions<SensorDataContext> options) : base(options)
        {
        }

        public DbSet<Sensor> Sensors { get; set; }
        public DbSet<Measurement> Measurements { get; set; }
        public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sensor>()
                .HasIndex(s => s.SensorId)
                .IsUnique();

            modelBuilder.Entity<Location>()
                .HasIndex(l => l.LocationId)
                .IsUnique();

            modelBuilder.Entity<Measurement>()
                .HasIndex(m => m.MeasurementId)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}
