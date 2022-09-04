using Microsoft.EntityFrameworkCore;
using NZWalk.API.Data;
using NZWalk.API.Models.Domain;
using NZWalk.API.Models.DTO;
using System.Xml.Linq;

namespace NZWalk.API.Repository
{
    public class RegionRepository : IRegionRepository
    {
        private readonly NZWalksDbContext nZWalksDbContext;
        public RegionRepository(NZWalksDbContext nZWalksDbContext)
        {
            this.nZWalksDbContext = nZWalksDbContext;
        }

        public async Task<IEnumerable<Region>> GetAllRegionAsync()
        {
            return await nZWalksDbContext.Regions.ToListAsync();
        }

        public async Task<Region> GetRegionByIDAsync(Guid Id)
        {
            return await nZWalksDbContext.Regions.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<Region> AddRegionAsync(Region region)
        {
            await nZWalksDbContext.AddAsync(region);
            await nZWalksDbContext.SaveChangesAsync();
            return region;

        }

        public async Task<string> DeleteRegionByIDAsync(Guid guid)
        {
            var region = await nZWalksDbContext.Regions.FirstOrDefaultAsync(x => x.Id == guid);

            if (region == null)
            {
                return "Region not found with ID " + guid;
            }

            nZWalksDbContext.Regions.Remove(region);
            await nZWalksDbContext.SaveChangesAsync();

            return "Region deleted successfully with ID " + guid;
        }

        public async Task<Region> UpdateRegionAsync(Guid guid, Region Region)
        {
            var region1 = await nZWalksDbContext.Regions.FirstOrDefaultAsync(x => x.Id == guid);

            if (region1 == null)
            {
                return null;
            }
            region1.Code = Region.Code;
            region1.Name = Region.Name;
            region1.Area = Region.Area;
            region1.Lattitude = Region.Lattitude;
            region1.Longitude = Region.Longitude;
            region1.Population = Region.Population;
            
            await nZWalksDbContext.SaveChangesAsync();
            region1.Id = guid;
            return Region;

        }
    }
}
