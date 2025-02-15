using ApplicationStatusAPI.Models;
using ApplicationStatusAPI.Models.Dto;

namespace ApplicationStatusAPI.Repository.IRepository
{
    public interface IJobApplicationRepository
    {
        Task<List<JobApplicationListDto>> GetJobApplicationListAsync();
        
    }
}
