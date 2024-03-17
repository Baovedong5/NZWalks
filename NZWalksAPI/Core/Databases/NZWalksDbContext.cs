using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Core.Models;

namespace NZWalksAPI.Core.Databases
{
    public class NZWalksDbContext : DbContext
    {
        public NZWalksDbContext(DbContextOptions<NZWalksDbContext> options) : base(options) { }

        public DbSet<Walk> Walks { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Difficulty> Difficulties { get; set; }
    }
}
