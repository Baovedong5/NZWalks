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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed data for Difficulties
            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id = Guid.Parse("bd502112-a322-4092-a458-5d332db054ec"),
                    Name = "Easy"
                },
                 new Difficulty()
                {
                    Id = Guid.Parse("a9648a0a-9d67-4f3e-a7c8-0d9d601a3396"),
                    Name = "Medium"
                },
                 new Difficulty()
                {
                    Id = Guid.Parse("7f9058ca-1123-4f7a-95fb-42be587e2722"),
                    Name = "Hard"
                },
            };

            //Seed difficulties to the database
            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            //Seed data for Regions
            var regions = new List<Region>
            {
                new Region
                {
                    Id = Guid.Parse("0447bc9c-ce4b-4019-882e-355d8f6686f4"),
                    Name = "Auckland",
                    Code = "AKL",
                    RegionImageUrl = "https://bit.ly/3VpbtMS"
                },
                new Region
                {
                    Id = Guid.Parse("a3c2db25-b582-4cd4-8d10-2c1ab984e2c9"),
                    Name = "Bay Of Plenty",
                    Code = "BOP",
                    RegionImageUrl = null
                },
                new Region
                {
                    Id = Guid.Parse("4c218e45-068d-4bc2-b346-74eec5466661"),
                    Name = "Wellington",
                    Code = "WGN",
                    RegionImageUrl = "https://bit.ly/4aeiB2Q"
                },
                new Region
                {
                    Id = Guid.Parse("829de7fe-8a55-4f70-9f5d-adab12215f51"),
                    Name = "Nelson",
                    Code = "NSN",
                    RegionImageUrl = "https://bit.ly/49VT2E6"
                },
                new Region
                {
                    Id = Guid.Parse("ac601f69-b2f9-473e-a168-cf11a722a655"),
                    Name = "Southland",
                    Code = "STL",
                    RegionImageUrl = "null"
                },
            };

            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}
