using ABP_RoomBookingApp.Model;
using Microsoft.EntityFrameworkCore;

namespace ABP_RoomBookingApp.Data
{
    public class ApplicationDB : DbContext
    {
        public DbSet<HallConference> HallConferences { get; set; } = null!;
        public DbSet<PriceModifiers> PriceModifiers { get; set; } = null!;
        public DbSet<ServiceConference> serviceConferences { get; set; } = null!;
        public ApplicationDB(DbContextOptions<ApplicationDB> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PriceModifiers>()
                .ToTable(x => x.HasCheckConstraint("ValidDate", "[dateStart] > '2024-09-07 00:00:00' AND [dateStart] < [dateEnd]"));

            modelBuilder.Entity<HallConference>()
                .Property(x => x.Price).HasColumnType("decimal(12,2)");
        }
    }
}
