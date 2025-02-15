using ApplicationStatusAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ApplicationStatusAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<JobApplication> JobApplications { get; set; }
        public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<JobApplication>()
                .HasOne(ja => ja.Location)
                .WithMany()
                .HasForeignKey(ja => ja.LocationId);

            modelBuilder.Entity<Location>().HasData(
                    new Location { LocationId = 1, LocationName = "Auckland" },
                    new Location { LocationId = 2, LocationName = "Wellington" },
                    new Location { LocationId = 3, LocationName = "Christchurch" },
                    new Location { LocationId = 4, LocationName = "Hamilton" },
                    new Location { LocationId = 5, LocationName = "Tauranga" },
                    new Location { LocationId = 6, LocationName = "Dunedin" }
                );

            modelBuilder.Entity<JobApplication>().HasData(
                    new JobApplication { JobApplicationId = 1,
                    JobLink = "https://www.seek.co.nz/junior-.net-developer-jobs/in-All-Auckland?jobId=80539744&type=promoted",
                    CompanyName = "BidFood Limited",
                    JobTitle = "Software Developer",
                    LocationId = 1,
                    DateSubmitted = new DateTime(2024, 12, 30)
                    }
                );
        }
    }
}
