using NZWalksAPI.Core.Databases;
using NZWalksAPI.Core.IRepositories;
using NZWalksAPI.Core.Models;

namespace NZWalksAPI.Core.Repositories
{
    public class LocalImageRepository : IImageRepository
    {
        private readonly IWebHostEnvironment _environment;

        private readonly IHttpContextAccessor _contextAccessor;

        private readonly NZWalksDbContext _context;

        public LocalImageRepository(IWebHostEnvironment environment, IHttpContextAccessor contextAccessor, NZWalksDbContext context)
        {
            _environment = environment;

            _contextAccessor = contextAccessor;

            _context = context;
        }

        public async Task<Image> Upload(Image image)
        {
            var localFilePath = Path.Combine(_environment.ContentRootPath, "Images", $"{image.FileName}{image.FileExtesion}");

            //Upload Image to Local Path
            using var stream = new FileStream(localFilePath, FileMode.Create);

            await image.File.CopyToAsync(stream);

            var urlFilePath = $"{_contextAccessor.HttpContext.Request.Scheme}://{_contextAccessor.HttpContext.Request.Host}{_contextAccessor.HttpContext.Request.PathBase}/Images/{image.FileName}{image.FileExtesion}";

            image.FilePath = urlFilePath;

            //Add Image to Image Table

            await _context.Images.AddAsync(image);

            await _context.SaveChangesAsync();

            return image;
        }
    }
}
