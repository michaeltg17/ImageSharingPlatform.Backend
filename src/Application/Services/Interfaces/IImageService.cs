using Domain.Models;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IImageService
    {
        Task<Image> GetImage(string id);
        Task<ImageGroup> SaveImage(IFormFile file, string serverFolder);
    }
}
