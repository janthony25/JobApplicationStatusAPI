using ApplicationStatusAPI.Models;

namespace ApplicationStatusAPI.Repository.IRepository
{
    public interface ISourceRepository
    {
        Task<List<Source>> GetSourcesAsync();
    }
}
