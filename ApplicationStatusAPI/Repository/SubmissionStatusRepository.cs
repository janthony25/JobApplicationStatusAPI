using ApplicationStatusAPI.Data;
using ApplicationStatusAPI.Models;
using ApplicationStatusAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace ApplicationStatusAPI.Repository
{
    public class SubmissionStatusRepository : ISubmissionStatusRepository
    {
        private readonly DataContext _data;
        private readonly ILogger<SubmissionStatusRepository> _logger;

        public SubmissionStatusRepository(DataContext data, ILoggerFactory loggerFactory)
        {
            _data = data;
            _logger = loggerFactory.CreateLogger<SubmissionStatusRepository>();
        }
        public async Task<List<SubmissionStatus>> GetSubmissionStatusesAsync()
        {
            try
            {
                var submissionStatuses = await _data.SubmissionStatuses.ToListAsync();
                return submissionStatuses;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching submission status list.");
                throw;
            }
        }
    }
}
