using ApplicationStatusAPI.Models;

namespace ApplicationStatusAPI.Repository.IRepository
{
    public interface ISubmissionStatusRepository
    {
        Task<List<SubmissionStatus>> GetSubmissionStatusesAsync();
    }
}
