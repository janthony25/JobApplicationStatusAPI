using ApplicationStatusAPI.Data;
using ApplicationStatusAPI.Models.Dto;
using ApplicationStatusAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace ApplicationStatusAPI.Repository
{
    public class JobApplicationStatusRepository : IJobApplicationRepository
    {
        private readonly DataContext _data;
        private readonly ILogger<JobApplicationStatusRepository> _logger;

        public JobApplicationStatusRepository(DataContext data, ILogger<JobApplicationStatusRepository> logger)
        {
            _data = data;
            _logger = logger;
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
