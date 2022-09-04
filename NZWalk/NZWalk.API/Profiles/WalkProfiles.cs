using AutoMapper;
using NZWalk.API.Models.Domain;
using NZWalk.API.Models.DTO;

namespace NZWalk.API.Profiles
{
    public class WalkProfiles:Profile
    {
        public WalkProfiles()
        {
            CreateMap<Walk , WalkDTO>();
        }
    }
}
