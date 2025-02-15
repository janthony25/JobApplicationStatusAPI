using ApplicationStatusAPI.Data;
using ApplicationStatusAPI.Models;
using ApplicationStatusAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace ApplicationStatusAPI.Repository
{
    public class LocationRepository : ILocationRepository
    {
        private readonly DataContext _data;
        private readonly ILogger<ILocationRepository> _logger;

        public LocationRepository(DataContext data, ILogger<ILocationRepository> logger)
        {
            _data = data;
            _logger = logger;
        }

        public async Task<List<Location>> GetLocationsAsync()
        {
            try
            {
                var locations = await _data.Locations.ToListAsync();

                _logger.LogInformation("Locations fetched successfully.");
                return locations;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching locations.");
                throw;
            }
        }
    }
}
