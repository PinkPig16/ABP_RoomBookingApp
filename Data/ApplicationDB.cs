using ABP_ConferenceBookingApp.Model;
using Microsoft.EntityFrameworkCore;

namespace ABP_ConferenceBookingApp.Data
{
    public class ApplicationDB : DbContext
    {
        public DbSet<HallConference> HallConferences { get; set; } = null!;
        public DbSet<PriceModifiers> PriceModifiers { get; set; } = null!;
        public DbSet<ServiceConference> serviceConferences { get; set; } = null!;
        public DbSet<BookingHall> BookingHalls { get; set; } = null!;
        public ApplicationDB(DbContextOptions<ApplicationDB> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PriceModifiers>()
                .ToTable(x => x.HasCheckConstraint("ValidDate", "[dateStart] < [dateEnd]"));
            modelBuilder.Entity<BookingHall>()
                .ToTable(x => x.HasCheckConstraint("ValidDate", "[startTime] < [endTime]"));
            modelBuilder.Entity<HallConference>()
                .Property(x => x.Price).HasColumnType("decimal(12,2)");
            modelBuilder.Entity<ServiceConference>()
                .Property(x => x.Price).HasColumnType("decimal(12,2)");
            modelBuilder.Entity<BookingHall>()
                .Property(x => x.TotalPrice).HasColumnType("decimal(12,2)");
        }
    }
}
