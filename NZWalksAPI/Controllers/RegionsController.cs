using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalksAPI.Core.Databases;
using NZWalksAPI.Core.DTOs;
using NZWalksAPI.Core.Models;


namespace NZWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext _context;

        public RegionsController(NZWalksDbContext context)
        {
            _context = context;   
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            // Get data from database - Domain Models
            var regions = _context.Regions.ToList();

            //Mapp Domain Models to DTO
            var regionDtos = new List<RegionDto>();
            foreach (var region in regions)
            {
                regionDtos.Add(new RegionDto()
                {
                    Id = region.Id,
                    Name = region.Name,
                    Code = region.Code,
                    RegionImageUrl = region.RegionImageUrl,
                });
            }

            //Return DTO
            return Ok(regionDtos);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            //var region = _context.Regions.Find(id);
            // Get Region Domain Model From Database
            var regionDomain = _context.Regions.FirstOrDefault(x => x.Id == id);

            if(regionDomain == null)
            {
                return NotFound();
            }

            //Map Region Domain Model to Region DTO
            var regionDto = new RegionDto
            {
                Id = regionDomain.Id,
                Name = regionDomain.Name,
                Code = regionDomain.Code,
                RegionImageUrl = regionDomain.RegionImageUrl,
            };

            // Return DTO back to Client
            return Ok(regionDto);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateRegionRequestDto createRegionRequestDto)
        {
            //Map DTO to Doamin Model
            var regionDomainModel = new Region
            {
                Code = createRegionRequestDto.Code,
                Name = createRegionRequestDto.Name,
                RegionImageUrl = createRegionRequestDto.RegionImageUrl,
            };

            //Use Domain Model to create Region
            _context.Regions.Add(regionDomainModel);
            _context.SaveChanges();

            //Map Domain model back to DTO

            var regionDto = new RegionDto
            {
                Id = regionDomainModel.Id,
                Name = regionDomainModel.Name,
                Code = regionDomainModel.Code,
                RegionImageUrl = regionDomainModel.RegionImageUrl,
            };

            return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public IActionResult Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            //Check if region exist
            var regionModel = _context.Regions.FirstOrDefault(x => x.Id == id);

            if (regionModel == null)
            {
                return NotFound();
            }

            //MapDTO to Domain Model
            regionModel.Code = updateRegionRequestDto.Code;
            regionModel.Name = updateRegionRequestDto.Name;
            regionModel.RegionImageUrl = updateRegionRequestDto.RegionImageUrl;

            _context.SaveChanges();

            //Convert Domain Model to DTO
            var regionDto = new RegionDto
            {
                Id = regionModel.Id,
                Name = regionModel.Name,
                Code = regionModel.Code,
                RegionImageUrl = regionModel.RegionImageUrl,
            };

            return Ok(regionDto);
        }

        [HttpDelete]
        [Route("{id: Guid}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            var regionDomainModel = _context.Regions.FirstOrDefault(x => x.Id == id);

            if(regionDomainModel == null)
            {
                return NotFound();
            }

            _context.Regions.Remove(regionDomainModel);
            _context.SaveChanges();

            var regionDto = new RegionDto
            {
                Id = regionDomainModel.Id,
                Name = regionDomainModel.Name,
                Code = regionDomainModel.Code,
                RegionImageUrl = regionDomainModel.RegionImageUrl,
            };

            return Ok(regionDto);
        }
    }
}
