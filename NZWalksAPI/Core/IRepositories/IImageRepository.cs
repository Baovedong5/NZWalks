using NZWalksAPI.Core.Models;

namespace NZWalksAPI.Core.IRepositories
{
    public interface IImageRepository
    {
        Task<Image> Upload(Image image);
    }
}
