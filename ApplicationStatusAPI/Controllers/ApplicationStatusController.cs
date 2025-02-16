using ApplicationStatusAPI.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationStatusAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationStatusController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ApplicationStatusController> _logger;

        public ApplicationStatusController(IUnitOfWork unitOfWork, ILogger<ApplicationStatusController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        [HttpGet("applicationStatusList")]
        public async Task<IActionResult> GetApplicationStatuses()
        {
            try
            {
                var applicationStatuses = await _unitOfWork.ApplicationStatus.GetApplicationStatusesAsync();
                return Ok(applicationStatuses); 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured while fetching application statuses");   
                return StatusCode(500, new {message= "An error occured while fetching application statuses" }); 
            }
        }
    }
}
