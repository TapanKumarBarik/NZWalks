using NZWalk.API.Models.Domain;

namespace NZWalk.API.Repository
{
    public interface IWalkDifficulty
    {
        Task<IEnumerable<WalkDifficulty>> GetAllWalkDifficultiesAsync();
        Task<WalkDifficulty> GetWalkDifficultyByIDAsync(Guid guid);
        Task<WalkDifficulty> AddWalkDifficultyAsync(WalkDifficulty walkDifficulty);
        Task<string> RemoveWalkDifficultyAsync(Guid guid);
        Task<WalkDifficulty> UpdateWalkDifficultyAsync(Guid guid, WalkDifficulty walkDifficulty);
    }
}
