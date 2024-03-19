using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalksAPI.Core.DTOs;
using NZWalksAPI.Core.IRepositories;
using NZWalksAPI.Core.Models;
using NZWalksAPI.Utils;



namespace NZWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly IWalkRepository _walkRepository;

        public WalksController(IMapper mapper, IWalkRepository walkRepository)
        {
            _mapper = mapper;
            _walkRepository = walkRepository;
        }

        [HttpPost]
        [ValidationModelAttibute]
        public async Task<IActionResult> Create([FromBody] CreateWalkRequestDto createWalkRequestDto)
        {
            //Map DTO to Domain Model
            var walkDomainModel = _mapper.Map<Walk>(createWalkRequestDto);

            await _walkRepository.CreateAsync(walkDomainModel);

            //Map Domain model to Dto
            var walkDto = _mapper.Map<WalkDto>(walkDomainModel);

            return Ok(walkDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var walkDomainModel = await _walkRepository.GetAllAsync();

            //Map Domain Model to Dto
            
            var walkDto = _mapper.Map<List<WalkDto>>(walkDomainModel);

            return Ok(walkDto);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute]Guid id) 
        { 
            var walkDomainModel = await _walkRepository.GetByIdAsync(id);

            if (walkDomainModel == null)
            {
                return NotFound();
            }

            var walkDto = _mapper.Map<WalkDto>(walkDomainModel);

            return Ok(walkDto);
        }

        [HttpPut]
        [Route("{id:guid}")]
        [ValidationModelAttibute]

        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateWalkRequestDto updateWalkRequestDto)
        {
            //Map DYo to Domain Model
            var walkDomainModel = _mapper.Map<Walk>(updateWalkRequestDto);

            walkDomainModel = await _walkRepository.UpdateAsync(id, walkDomainModel);

            if(walkDomainModel == null)
            {
                return NotFound();
            }

            //Map Domain Model to Dto
            var walkDto = _mapper.Map<WalkDto>(walkDomainModel);

            return Ok(walkDto);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleteWalkModel = await _walkRepository.DeleteAsync(id);

            if(deleteWalkModel == null)
            {
                return NotFound();
            }

            //Map Domain Model to Dto
            var walkDto = _mapper.Map<WalkDto>(deleteWalkModel);

            return Ok(walkDto);
        }
    }
}
