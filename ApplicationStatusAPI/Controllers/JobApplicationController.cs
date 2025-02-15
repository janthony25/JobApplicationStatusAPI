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
        private readonly IJobApplicationRepository _jobApplicationRepository;
        private readonly ILogger<JobApplicationController> _logger;

        public JobApplicationController(IJobApplicationRepository jobApplicationRepository, ILogger<JobApplicationController> logger)
        {
            _jobApplicationRepository = jobApplicationRepository;
            _logger = logger;
        }

        [HttpGet("jobApplicationList")]
        public async Task<IActionResult> GetJobApplicationList()
        {
            try
            {
                _logger.LogInformation("Request to fetch job application list.");

                var applicationList = await _jobApplicationRepository.GetJobApplicationListAsync();
                return Ok(applicationList);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching job application list."); 
                return StatusCode(500, new {message = "An error occurred while fetching job application list." });
            }
        }
    }
}
