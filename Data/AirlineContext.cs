using AirlineAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AirlineAPI.Data
{
    public class AirlineContext : DbContext
    {
        public AirlineContext(DbContextOptions<AirlineContext> options) : base(options)
        {
        }

        // DbSet properties for the models
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Passenger> Passengers { get; set; }

        // Configure relationships and any custom settings
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the relationship between Ticket and Flight using only FlightId
            modelBuilder.Entity<Ticket>()
                .HasOne<Flight>() // Remove navigational property reference
                .WithMany() // No back-reference from Flight to Ticket
                .HasForeignKey(t => t.FlightId) // Foreign key setup
                .OnDelete(DeleteBehavior.Cascade); // Cascading delete

            // Optional: You can define additional configurations for other entities here.
        }
    }
}
