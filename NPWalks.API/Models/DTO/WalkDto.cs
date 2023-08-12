namespace NPWalks.API.Models.DTO
{
    public class WalkDto
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required double LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }

        public required RegionDto Region { get; set; }
        public required DifficultyDto Difficulty { get; set; }
    }
}