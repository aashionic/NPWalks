using System.ComponentModel.DataAnnotations;

namespace NPWalks.API.Models.DTO;

public class AddRegionRequestDto
{
    [Required]
    [MinLength(3, ErrorMessage = "Code has to be a minimum 3 characters")]
    [MaxLength(3, ErrorMessage = "Code has to be a maximum 3 characters")]
    public string Code { get; set; }

    [Required]
    [MaxLength(100, ErrorMessage = "Code has to be a maximum of 100 characters")]
    public string Name { get; set; }
    public string? RegionImageUrl { get; set; }
}
