using AutoMapper;
using NZWalk.API.Models.Domain;
using NZWalk.API.Models.DTO;

namespace NZWalk.API.Profiles
{
    public class WalkDifficultyProfiles:Profile
    {
        public WalkDifficultyProfiles()
        {
            CreateMap<WalkDifficulty, WalkDifficultyDTO>();
        }
    }
}
