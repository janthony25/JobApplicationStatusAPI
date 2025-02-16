using ApplicationStatusAPI.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationStatusAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<LocationsController> _logger;

        public LocationsController(IUnitOfWork unitOfWork, ILogger<LocationsController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        [HttpGet("locations")]
        public async Task<IActionResult> GetLocationsList()
        {
            try
            {
                _logger.LogInformation("Request to fetch locations list");

                var locations = await _unitOfWork.Location.GetLocationsAsync();
                return Ok(locations);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching locations.");
                return StatusCode(500, new {message = "An error occurred while fetching locations." }); 
            }
        }
    }
}
