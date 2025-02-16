using ApplicationStatusAPI.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationStatusAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmissionStatusController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<SubmissionStatusController> _logger;

        public SubmissionStatusController(IUnitOfWork unitOfWork, ILogger<SubmissionStatusController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        [HttpGet("submissionStatusList")]
        public async Task<IActionResult> GetSubmissionStatuses()
        {
            try
            {
                _logger.LogInformation("Request to fetch submission statuses");

                var submissionStatuses = await _unitOfWork.SubmissionStatus.GetSubmissionStatusesAsync();

                return Ok(submissionStatuses);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving submission statuses"); 
                return StatusCode(500, new { message = "An error occurred while retrieving submission statuses" });
            }
        }
    }
}
