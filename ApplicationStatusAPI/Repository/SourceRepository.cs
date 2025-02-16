using ApplicationStatusAPI.Data;
using ApplicationStatusAPI.Models;
using ApplicationStatusAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace ApplicationStatusAPI.Repository
{
    public class SourceRepository : ISourceRepository
    {
        private readonly DataContext _data;
        private readonly ILogger<SourceRepository> _logger;  
        public SourceRepository(DataContext data, ILoggerFactory loggerFactory)
        {
            _data = data;
            _logger = loggerFactory.CreateLogger<SourceRepository>();   
        }
        public async Task<List<Source>> GetSourcesAsync()
        {
            try
            {
                var sources = await _data.Sources.ToListAsync();
                return sources; 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching sources");
                throw;
            }
        }
    }
}
