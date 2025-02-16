using ApplicationStatusAPI.Data;
using ApplicationStatusAPI.Models;
using ApplicationStatusAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace ApplicationStatusAPI.Repository
{
    public class ApplicationStatusRepository : IApplicationStatusRepository
    {
        private readonly DataContext _data;
        private readonly ILogger<ApplicationStatusRepository> _logger;  

        public ApplicationStatusRepository(DataContext data, ILoggerFactory loggerFactory)
        {
            _data = data;
            _logger = loggerFactory.CreateLogger<ApplicationStatusRepository>();
        }
        
        public async Task<List<ApplicationStatus>> GetApplicationStatusesAsync()
        {
            try
            {
                var applicationStatuses = await _data.ApplicationStatuses.ToListAsync();

                return applicationStatuses; 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching application statuses");
                throw;
            }
        }
    }
}
