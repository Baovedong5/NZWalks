using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalksAPI.Core.Databases;
using NZWalksAPI.Core.DTOs;
using NZWalksAPI.Core.Models;
using System.Drawing;

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
    }
}
