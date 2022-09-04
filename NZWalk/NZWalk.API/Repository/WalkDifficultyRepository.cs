using Microsoft.EntityFrameworkCore;
using NZWalk.API.Data;
using NZWalk.API.Models.Domain;

namespace NZWalk.API.Repository
{
    public class WalkDifficultyRepository : IWalkDifficulty
    {
        private readonly NZWalksDbContext _dbContext;
        public WalkDifficultyRepository(NZWalksDbContext nZWalksDbContext)
        {
            this._dbContext = nZWalksDbContext;

        }
        public async Task<IEnumerable<WalkDifficulty>> GetAllWalkDifficultiesAsync()
        {
           return await _dbContext.WalkDifficulty.ToListAsync();
        }
        public  async Task<WalkDifficulty> GetWalkDifficultyByIDAsync(Guid guid)
        {
            var walkDifficulty=await _dbContext.WalkDifficulty.FirstOrDefaultAsync(x=>x.Id==guid);
            return walkDifficulty;
        }
        public async Task<WalkDifficulty> AddWalkDifficultyAsync(WalkDifficulty walkDifficulty)
        {
            await _dbContext.WalkDifficulty.AddAsync(walkDifficulty);
            await _dbContext.SaveChangesAsync();
            return walkDifficulty;
        }

        public async Task<string> RemoveWalkDifficultyAsync(Guid guid)
        {
            var walkDifficulty = await _dbContext.WalkDifficulty.FirstOrDefaultAsync(x => x.Id == guid);
            if (walkDifficulty==null)
            {
                return "Walk Difficulty with ID " + guid + " is not found";
            }
            _dbContext.WalkDifficulty.Remove(walkDifficulty);
            await _dbContext.SaveChangesAsync();

            return "Walk Difficulty with ID " + guid + " has been deleted successfully";
        }

        public async Task<WalkDifficulty> UpdateWalkDifficultyAsync(Guid guid, WalkDifficulty walkDifficulty)
        {
            var walkDifficulty1 = await _dbContext.WalkDifficulty.FirstOrDefaultAsync(x => x.Id == guid);
            if (walkDifficulty1 == null)
            {
                return null;
            }
            walkDifficulty1.Code = walkDifficulty.Code;
            await _dbContext.SaveChangesAsync();
            return walkDifficulty1;
        }
    }
}
