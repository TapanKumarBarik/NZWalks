using Microsoft.AspNetCore.Mvc;
using NZWalk.API.Models.Domain;
using NZWalk.API.Models.DTO;

namespace NZWalk.API.Repository
{
    public interface IRegionRepository
    {
        Task<IEnumerable<Region>> GetAllRegionAsync();
        Task<Region> GetRegionByIDAsync( Guid Id);
        Task<Region>AddRegionAsync(Region Region);
        Task<string> DeleteRegionByIDAsync(Guid guid);
        Task<Region> UpdateRegionAsync(Guid guid,Region Region);

    }
}
