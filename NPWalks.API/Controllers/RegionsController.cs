using Microsoft.AspNetCore.Mvc;
using NPWalks.API.Data;
using NPWalks.API.Models.Domain;
using NPWalks.API.Models.DTO;

namespace NPWalks.API.Controllers;

//https://localhost:1234/api/regions
[Route("api/[controller]")]
[ApiController]
public class RegionsController : ControllerBase
{
    private readonly NPWalksDbContext dbContext;

    public RegionsController(NPWalksDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    //GET ALL REGIONS
    //GET://https://localhost:portno/api/regions
    [HttpGet] //200 response
    public IActionResult GetAll()
    {
        //Get Data from Database - Domain Model
        var regionsDomain = dbContext.Regions.ToList();

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
    public IActionResult GetById([FromRoute] Guid id)
    {
        // var region = dbContext.Regions.Find(id);
        //Get Region Domain Model From Database
        var regionDomain = dbContext.Regions.FirstOrDefault(x => x.Id == id);
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
    public IActionResult Create([FromBody] AddRegionRequestDto addRegionRequestDto)
    {
        //Map Dto to Domain Model
        var regionDomainModel = new Region
        {
            Code = addRegionRequestDto.Code,
            Name = addRegionRequestDto.Name,
            RegionImageUrl = addRegionRequestDto.RegionImageUrl
        };

        //Use Domain Model to create Region
        dbContext.Regions.Add(regionDomainModel);
        dbContext.SaveChanges();

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
    public IActionResult Update(
        [FromRoute] Guid id,
        [FromBody] UpdateRegionRequestDTO updateRegionRequestDTO
    )
    {
        var regionDomainModel = dbContext.Regions.FirstOrDefault(x => x.Id == id);
        if (regionDomainModel == null)
        {
            return NotFound();
        }
        regionDomainModel.Code = updateRegionRequestDTO.Code;
        regionDomainModel.Name = updateRegionRequestDTO.Name;
        regionDomainModel.RegionImageUrl = updateRegionRequestDTO.RegionImageUrl;
        dbContext.SaveChanges();

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
    public IActionResult Delete([FromRoute] Guid id)
    {
        var regionDomainModel = dbContext.Regions.FirstOrDefault(x => x.Id == id);
        if (regionDomainModel == null)
        {
            return NotFound();
        }
        //Delete region
        dbContext.Regions.Remove(regionDomainModel);
        dbContext.SaveChanges();
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
