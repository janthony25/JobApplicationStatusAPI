using ApplicationStatusAPI.Models;

namespace ApplicationStatusAPI.Repository.IRepository
{
    public interface IApplicationStatusRepository
    {
        Task<List<ApplicationStatus>> GetApplicationStatusesAsync();
    }
}
