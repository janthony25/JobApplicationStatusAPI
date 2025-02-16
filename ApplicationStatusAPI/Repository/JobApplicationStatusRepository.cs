using ApplicationStatusAPI.Data;
using ApplicationStatusAPI.Models;
using ApplicationStatusAPI.Models.Dto;
using ApplicationStatusAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace ApplicationStatusAPI.Repository
{
    public class JobApplicationStatusRepository : IJobApplicationRepository
    {
        private readonly DataContext _data;
        private readonly ILogger<JobApplicationStatusRepository> _logger;

        public JobApplicationStatusRepository(DataContext data, ILoggerFactory loggerFactory)
        {
            _data = data;
            _logger = loggerFactory.CreateLogger<JobApplicationStatusRepository>();
        }

        public async Task AddJobApplicationAsync(AddJobApplicationDto dto)
        {
            try
            {
                var newJobApplication = new JobApplication
                {
                    JobLink = dto.JobLink,
                    CompanyName = dto.CompanyName,
                    JobTitle = dto.JobTitle,
                    LocationId = dto.LocationId,
                    SubmissionStatusId = dto.SubmissionStatusId,
                    ApplicationStatusId = dto.ApplicationStatusId,
                    SourceId = dto.SourceId
                };

                _data.JobApplications.Add(newJobApplication);
                await _data.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding new job application");
                throw;
            }
        }

        public async Task<List<JobApplicationListDto>> GetJobApplicationListAsync()
        {
            try
            {
                var applicationList = await _data.JobApplications
                            .Include(ja => ja.Location)
                            .Select(ja => new JobApplicationListDto
                            {
                                JobApplicationId = ja.JobApplicationId,
                                JobLink = ja.JobLink,
                                CompanyName = ja.CompanyName,
                                JobTitle = ja.JobTitle,
                                DateSubmitted = ja.DateSubmitted,
                                LocationName = ja.Location.LocationName,
                                SubmissionStatusName = ja.SubmissionStatus.SubmissionStatusName,
                                ApplicationStatusName = ja.ApplicationStatus.ApplicationStatusName,
                                SourceName = ja.Source.SourceName,
                                DateEdited = ja.DateEdited
                            }).ToListAsync();

                _logger.LogInformation("Job application list fetched successfully.");
                return applicationList;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching job application list.");
                throw;
            }
        }
    }
}
