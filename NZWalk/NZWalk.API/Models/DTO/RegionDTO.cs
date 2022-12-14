namespace NZWalk.API.Models.DTO
{
    public class RegionDTO
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double Area { get; set; }
        public double Lattitude { get; set; }
        public double Longitude { get; set; }
        public long Population { get; set; }
    }
}
