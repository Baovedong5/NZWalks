using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalksAPI.Core.DTOs;
using NZWalksAPI.Core.IRepositories;
using NZWalksAPI.Core.Models;

namespace NZWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepository _imageRepository;

        public ImagesController(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> Upload([FromForm] ImageUploadRequestDto imageUpload)
        {
            ValidateFileUpload(imageUpload);

            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            //Convert Dto to Domain Model
            var imageDomainModel = new Image
            {
                File = imageUpload.File,
                FileExtesion = Path.GetExtension(imageUpload.File.FileName),
                FileSizeInBytes = imageUpload.File.Length,
                FileName = imageUpload.File.FileName,
            };

            //User repository to upload image

            await _imageRepository.Upload(imageDomainModel);

            return Ok(imageDomainModel);
        }

        private void ValidateFileUpload(ImageUploadRequestDto imageUpload)
        {
            var allowedExtensions = new string[] { ".jpg", ".jpeg", ".png" };

            if (allowedExtensions.Contains(Path.GetExtension(imageUpload.File.FileName)) == false)
            {
                ModelState.AddModelError("file", "Unsupported file extension");
            }

            if(imageUpload.File.Length > 10485760)
            {
                ModelState.AddModelError("file", "File size mor than 10MB, please upload a smaller size file");
            }
        }
    }
}
