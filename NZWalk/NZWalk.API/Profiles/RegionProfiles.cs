using AutoMapper;
using NZWalk.API.Models.Domain;
using NZWalk.API.Models.DTO;

namespace NZWalk.API.Profiles
{
    public class RegionProfiles:Profile
    {
        public RegionProfiles()
        {
            CreateMap<Region, RegionDTO>();
            CreateMap<RegionDTO, Region>();
        }
    }
}
