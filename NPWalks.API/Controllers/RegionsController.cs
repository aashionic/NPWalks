using Microsoft.AspNetCore.Mvc;
using NPWalks.API.Data;
using NPWalks.API.Models.Domain;
using NPWalks.API.Models.DTO;
using NPWalks.API.Repositories;

namespace NPWalks.API.Controllers;

//https://localhost:1234/api/regions
[Route("api/[controller]")]
[ApiController]
public class RegionsController : ControllerBase
{
    private readonly NPWalksDbContext dbContext;
    private readonly IRegionRepository regionRepository;

    public RegionsController(NPWalksDbContext dbContext, IRegionRepository regionRepository)
    {
        this.dbContext = dbContext;
        this.regionRepository = regionRepository;
    }

    //GET ALL REGIONS
    //GET://https://localhost:portno/api/regions
    [HttpGet] //200 response
    public async Task<IActionResult> GetAll()
    {
        //Get Data from Database - Domain Model
        var regionsDomain = await regionRepository.GetAllAsync();

        //Map Domain Models to DTOs
        var regionsDto = new List<RegionDto>();
        foreach (var regionDomain in regionsDomain)
        {
            regionsDto.Add(
                new RegionDto()
                {
                    Id = regionDomain.Id,
                    Code = regionDomain.Code,
                    Name = regionDomain.Name,
                    RegionImageUrl = regionDomain.RegionImageUrl
                }
            );
        }

        //Return DTOs
        return Ok(regionsDto);
    }

    //GET REGION BY ID
    //GET://https://localhost:portno/api/regions/{id}
    [HttpGet]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        // var region = dbContext.Regions.Find(id);
        //Get Region Domain Model From Database
        var regionDomain = await regionRepository.GetByIdAsync(id);
        if (regionDomain == null)
        {
            return NotFound();
        }
        //Map Region Domain Model to Region DTO
        var regionDto = new RegionDto
        {
            Id = regionDomain.Id,
            Code = regionDomain.Code,
            Name = regionDomain.Name,
            RegionImageUrl = regionDomain.RegionImageUrl
        };

        //Return DTO back to client
        return Ok(regionDto);
    }

    //POST To Create New Region
    //POST: https://localhost:port/api/regions
    [HttpPost] //201 response
    public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
    {
        //Map Dto to Domain Model
        var regionDomainModel = new Region
        {
            Code = addRegionRequestDto.Code,
            Name = addRegionRequestDto.Name,
            RegionImageUrl = addRegionRequestDto.RegionImageUrl
        };

        //Use Domain Model to create Region
        regionDomainModel = await regionRepository.CreateAsync(regionDomainModel);
        await dbContext.SaveChangesAsync();

        //Map Domain Model back to DTO
        var regionDto = new RegionDto
        {
            Id = regionDomainModel.Id,
            Code = regionDomainModel.Code,
            Name = regionDomainModel.Name,
            RegionImageUrl = regionDomainModel.RegionImageUrl
        };

        return CreatedAtAction(
            //action that will be used to get the newly created item
            nameof(GetById),
            //provides the route values
            new { id = regionDomainModel.Id },
            //send to the client body
            regionDomainModel
        );
    }

    //Update region
    //PUT: https://localhost:port/api/regions/{id}
    [HttpPut]
    [Route("{id:Guid}")]
    public async Task<IActionResult> Update(
        [FromRoute] Guid id,
        [FromBody] UpdateRegionRequestDTO updateRegionRequestDTO
    )
    {
        //Map DTO to Domain Model
        var regionDomainModel = new Region
        {
            Code = updateRegionRequestDTO.Code,
            Name = updateRegionRequestDTO.Name,
            RegionImageUrl = updateRegionRequestDTO.RegionImageUrl
        };

        //check is region exists
        regionDomainModel = await regionRepository.UpdateAsync(id, regionDomainModel);
        if (regionDomainModel == null)
        {
            return NotFound();
        }
        //Map Domain model to Dto
        var regionDto = new RegionDto
        {
            Id = regionDomainModel.Id,
            Code = regionDomainModel.Code,
            Name = regionDomainModel.Name,
            RegionImageUrl = regionDomainModel.RegionImageUrl
        };
        return Ok(regionDto);
    }

    //Delete Region
    //DELETE: https://localhost:port/api/regions/{id}
    [HttpDelete]
    [Route("{id:Guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var regionDomainModel = await regionRepository.DeleteAsync(id);
        if (regionDomainModel == null)
        {
            return NotFound();
        }

        //optional: return deleted region back
        var regionDto = new RegionDto
        {
            Id = regionDomainModel.Id,
            Code = regionDomainModel.Code,
            Name = regionDomainModel.Name,
            RegionImageUrl = regionDomainModel.RegionImageUrl
        };

        return Ok(regionDto);
    }
}
