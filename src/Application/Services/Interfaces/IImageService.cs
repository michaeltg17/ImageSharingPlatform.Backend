using Domain.Models;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IImageService
    {
        Task<Image> GetImage(string id);
        Task SaveImage();
    }
}
