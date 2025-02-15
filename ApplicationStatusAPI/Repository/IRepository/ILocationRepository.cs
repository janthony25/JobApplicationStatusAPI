using ApplicationStatusAPI.Models;

namespace ApplicationStatusAPI.Repository.IRepository
{
    public interface ILocationRepository
    {
        Task<List<Location>> GetLocationsAsync();
    }
}
