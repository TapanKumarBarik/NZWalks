using NZWalk.API.Models.Domain;

namespace NZWalk.API.Repository
{
    public interface IWalkRepository
    {
        Task<IEnumerable<Walk>> GetAllWalkAsync();
        Task<Walk> GetWalkByIDAsync(Guid Id);
        Task<Walk> AddWalkAsync(Walk Walk);
        Task<string> DeleteWalkByIDAsync(Guid guid);
        Task<Walk> UpdateWalkAsync(Guid guid, Walk Walk);
    }
}
