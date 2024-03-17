using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Core.Databases;
using NZWalksAPI.Core.IRepositories;
using NZWalksAPI.Core.Models;

namespace NZWalksAPI.Core.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly NZWalksDbContext _context;

        public RegionRepository(NZWalksDbContext context)
        {
            _context = context;
        }

        public async Task<Region> CreateAsync(Region region)
        {
           await _context.Regions.AddAsync(region);

           await _context.SaveChangesAsync();

           return region;
        }

        public async Task<Region?> DeleteAsync(Guid id)
        {
            var exsistingRegion = await _context.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if(exsistingRegion == null)
            {
                return null;
            }

            _context.Regions.Remove(exsistingRegion);

            await _context.SaveChangesAsync();

            return exsistingRegion;
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return await _context.Regions.ToListAsync();
        }

        public async Task<Region?> GetByIdAsync(Guid id)
        {
            return await _context.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Region?> UpdateAsync(Guid id, Region region)
        {
            var existingRegion = await _context.Regions.FirstOrDefaultAsync(y => y.Id == id);

            if(existingRegion == null)
            {
                return null;
            }

            existingRegion.Code = region.Code;
            existingRegion.Name = region.Name;
            existingRegion.RegionImageUrl = region.RegionImageUrl;

            await _context.SaveChangesAsync();

            return existingRegion;
        }
    }
}
