using ApplicationStatusAPI.Models.Dto;
using ApplicationStatusAPI.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationStatusAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobApplicationController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<JobApplicationController> _logger;

        public JobApplicationController(IUnitOfWork unitOfWork, ILogger<JobApplicationController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        [HttpGet("jobApplicationList")]
        public async Task<IActionResult> GetJobApplicationList()
        {
            try
            {
                _logger.LogInformation("Request to fetch job application list.");

                var applicationList = await _unitOfWork.JobApplication.GetJobApplicationListAsync();
                return Ok(applicationList);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching job application list."); 
                return StatusCode(500, new {message = "An error occurred while fetching job application list." });
            }
        }

        [HttpPost("addJob")]
        public async Task<IActionResult> AddNewJob([FromBody] AddJobApplicationDto dto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                await _unitOfWork.JobApplication.AddJobApplicationAsync(dto);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding new job.");
                return StatusCode(500, new { message = "An error occurred while adding new job." });
            }
        }
    }
}
