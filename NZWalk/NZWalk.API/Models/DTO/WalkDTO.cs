using NZWalk.API.Models.Domain;

namespace NZWalk.API.Models.DTO
{
    public class WalkDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Length { get; set; }
        public Guid RegionID { get; set; }
        public Guid WalkDifficultyID { get; set; }

        //Navigation
        public Region? Region { get; set; }

        public WalkDifficulty? WalkDifficulty { get; set; }
    }
}
