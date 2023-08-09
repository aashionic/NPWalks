using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NPWalks.API.CustomActionFilters;
using NPWalks.API.Models.Domain;
using NPWalks.API.Models.DTO;
using NPWalks.API.Repositories;

namespace NPWalks.API.Controllers;

// /api/walks
[Route("api/[controller]")]
[ApiController]
public class WalksController : ControllerBase
{
    private readonly IMapper mapper;
    private readonly IWalkRepository walkRepository;

    public WalksController(IMapper mapper, IWalkRepository walkRepository)
    {
        this.mapper = mapper;
        this.walkRepository = walkRepository;
    }

    //Create Walk
    //POST: /api/walks
    [HttpPost]
    [ValidateModel]
    public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequestDto)
    {
        //Map DTO(AddWalkRequestDto) to Domain(Walk) Model
        var walkDomainModel = mapper.Map<Walk>(addWalkRequestDto);

        await walkRepository.CreateAsync(walkDomainModel);

        //Map Domain model to DTO(sending back to the client)
        var regionDto = mapper.Map<WalkDto>(walkDomainModel);
        return Ok(regionDto);
    }

    //GET Walk
    //GET: /api/walks?filterOn=Name&filterQuery=Track&sortBy=Name&Ascending=true

    [HttpGet]
    public async Task<IActionResult> GetAll(
        [FromQuery] string? filterOn,
        [FromQuery] string? filterQuery,
        [FromQuery] string? sortBy,
        [FromQuery] bool? isAscending
    )
    {
        var walksDomainModel = await walkRepository.GetAllAsync(
            filterOn,
            filterQuery,
            sortBy,
            isAscending ?? true
        );
        //Map Domain Model to DTO
        return Ok(mapper.Map<List<WalkDto>>(walksDomainModel));
    }

    //GET Walk By Id
    //GET: /api/Walks/{id}
    [HttpGet]
    [Route("{id:Guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var walkDomainModel = await walkRepository.GetByIdAsync(id);

        if (walkDomainModel == null)
        {
            return NotFound();
        }
        //Map Domain Model to DTO
        return Ok(mapper.Map<WalkDto>(walkDomainModel));
    }

    //Update Walk By Id
    //PUT: /api/Walks/{id}
    [HttpPut]
    [ValidateModel]
    public async Task<IActionResult> Update(
        [FromRoute] Guid id,
        UpdateWalkRequestDto updateWalkRequestDto
    )
    {
        //Map DTO to Domain Model
        var walkDomainModel = mapper.Map<Walk>(updateWalkRequestDto);
        walkDomainModel = await walkRepository.UpdateAsync(id, walkDomainModel);
        if (walkDomainModel == null)
        {
            return NotFound();
        }

        //Map Domain Model to DTO
        return Ok(mapper.Map<WalkDto>(walkDomainModel));
    }

    //Delete a Walk By Id
    //DELETE: /api/Walks/{id}
    [HttpDelete]
    [Route("{id:Guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var deleteWalkDomainModel = await walkRepository.DeleteAsync(id);
        if (deleteWalkDomainModel == null)
        {
            return NotFound();
        }
        //Map Domain Model to DTO
        return Ok(mapper.Map<WalkDto>(deleteWalkDomainModel));
    }
}
