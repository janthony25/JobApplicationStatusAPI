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
        public DbSet<SubmissionStatus> SubmissionStatuses { get; set; }
        public DbSet<ApplicationStatus> ApplicationStatuses { get; set; }
        public DbSet<Source> Sources { get; set; }  

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Location>().HasData(
                    new Location { LocationId = 1, LocationName = "Auckland" },
                    new Location { LocationId = 2, LocationName = "Wellington" },
                    new Location { LocationId = 3, LocationName = "Christchurch" },
                    new Location { LocationId = 4, LocationName = "Hamilton" },
                    new Location { LocationId = 5, LocationName = "Tauranga" },
                    new Location { LocationId = 6, LocationName = "Dunedin" }
                );

            modelBuilder.Entity<JobApplication>().HasData(
                    new JobApplication
                    {
                        JobApplicationId = 1,
                        JobLink = "https://www.seek.co.nz/junior-.net-developer-jobs/in-All-Auckland?jobId=80539744&type=promoted",
                        CompanyName = "BidFood Limited",
                        JobTitle = "Software Developer",
                        LocationId = 1,
                        DateSubmitted = new DateTime(2024, 12, 30),
                        SubmissionStatusId = 2,
                        ApplicationStatusId = 3,
                        SourceId = 1
                    }
                );

            modelBuilder.Entity<SubmissionStatus>().HasData(
                    new SubmissionStatus { SubmissionStatusId = 1, SubmissionStatusName = "Pending" },
                    new SubmissionStatus { SubmissionStatusId = 2, SubmissionStatusName = "Sent" }
                );

            modelBuilder.Entity<ApplicationStatus>().HasData(
                    new ApplicationStatus { ApplicationStatusId = 1, ApplicationStatusName = "Waiting for reply" },
                    new ApplicationStatus { ApplicationStatusId = 2, ApplicationStatusName = "Being considered" },
                    new ApplicationStatus { ApplicationStatusId = 3, ApplicationStatusName = "Closed" }
                );

            modelBuilder.Entity<Source>().HasData(
                    new Source { SourceId = 1, SourceName = "Seek" }
                );

            modelBuilder.Entity<JobApplication>()
                .HasOne(ja => ja.Location)
                .WithMany()
                .HasForeignKey(ja => ja.LocationId);

            modelBuilder.Entity<JobApplication>()
                .HasOne(ja => ja.SubmissionStatus)
                .WithMany()
                .HasForeignKey(ja => ja.SubmissionStatusId);

            modelBuilder.Entity<JobApplication>()
                .HasOne(ja => ja.applicationStatus)
                .WithMany()
                .HasForeignKey(ja => ja.ApplicationStatusId);

            modelBuilder.Entity<JobApplication>()
                .HasOne(ja => ja.Source)
                .WithMany()
                .HasForeignKey(ja => ja.SourceId);

            
        }
    }
}
