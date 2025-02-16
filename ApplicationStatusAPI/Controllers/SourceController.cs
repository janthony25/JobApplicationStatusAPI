using ApplicationStatusAPI.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace ApplicationStatusAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SourceController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<SourceController> _logger;

        public SourceController(IUnitOfWork unitOfWork, ILogger<SourceController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        [HttpGet("sourceList")]
        public async Task<IActionResult> GetSourcesList()
        {
            try
            {
                var sources = await _unitOfWork.Source.GetSourcesAsync();
                return Ok(sources);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching sources");
                return StatusCode(500, new { message = "An error occurred while fetching sources" });
            }
        }
    }
}
