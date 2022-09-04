using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using NZWalk.API.Data;
using NZWalk.API.Models.Domain;

namespace NZWalk.API.Repository
{
    public class WalkRepository : IWalkRepository
    {
        private readonly NZWalksDbContext nZWalksDbContext;
        public WalkRepository(NZWalksDbContext nZWalksDbContext)
        {
            this.nZWalksDbContext = nZWalksDbContext;
        }
 
        public async Task<IEnumerable<Walk>> GetAllWalkAsync()
        {
            return await 
                 nZWalksDbContext
                .Walks
                .Include(x => x.Region)
                .Include(x=>x.WalkDifficulty)
                .ToListAsync();
            
        }

        public async Task<Walk> GetWalkByIDAsync(Guid Id)
        {
            return await nZWalksDbContext.Walks
                .Include(x => x.Region)
                .Include(x => x.WalkDifficulty)
               . FirstOrDefaultAsync(x=>x.Id==Id);
           

        }

        public async Task<Walk> AddWalkAsync(Walk Walk)
        {
            await nZWalksDbContext.AddAsync(Walk);
            await nZWalksDbContext.SaveChangesAsync();
            return Walk;
        }
        public async Task<Walk> UpdateWalkAsync(Guid guid, Walk walk1)
        {
            var walk2=await 
                nZWalksDbContext
                .Walks
                .Include(x => x.Region)
                .Include(x => x.WalkDifficulty)
                .FirstOrDefaultAsync(x => x.Id == guid);
            if (walk2 == null)
            {
                return null;
            }
            walk2.WalkDifficultyID = walk1.WalkDifficultyID;
            walk2.Name = walk1.Name;
            walk2.Length = walk1.Length;
            walk2.RegionID = walk1.RegionID;
             
            await nZWalksDbContext.SaveChangesAsync();
            return walk2;
        }
        public async Task<string> DeleteWalkByIDAsync(Guid guid)
        {
            var walk = await nZWalksDbContext.Walks.FirstOrDefaultAsync(x => x.Id == guid);

            if (walk == null)
            {
                return "walk not found with ID " + guid;
            }

            nZWalksDbContext.Walks.Remove(walk);
            await nZWalksDbContext.SaveChangesAsync();

            return "walk deleted successfully with ID " + guid;
        }

       
    }
}
