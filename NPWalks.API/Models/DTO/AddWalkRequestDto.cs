﻿#region

using System.ComponentModel.DataAnnotations;

#endregion

namespace NPWalks.API.Models.DTO
{
    public class AddWalkRequestDto
    {
        [Required] [MaxLength(100)] public required string Name { get; set; }

        [MaxLength(1000, ErrorMessage = "Code has to be a maximum 3 characters")]
        [Required]
        public required string Description { get; set; }

        [Required] [Range(0, 50)] public double LengthInKm { get; set; }
        public  string? WalkImageUrl { get; set; }

        [Required] public Guid DifficultyId { get; set; }

        [Required] public Guid RegionId { get; set; }
    }
}