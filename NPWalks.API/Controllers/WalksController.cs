using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NPWalks.API.Models.Domain;
using NPWalks.API.Models.DTO;
using NPWalks.API.Repositories;

namespace NPWalks.API.Controllers
{
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
        //GET: /api/walks

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var walksDomainModel = await walkRepository.GetAllAsync();
            //Map Domain Model to DTO
            return Ok(mapper.Map<List<WalkDto>>(walksDomainModel));
        }
    }
}
