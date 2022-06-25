using Persistance;
using Domain.Models;
using System.Threading.Tasks;
using Application.Services.Interfaces;
using Application.Exceptions;

namespace Application.Services.Implementations
{
    public class ImageService : IImageService
    {
        readonly DbContext db;

        public ImageService(DbContext db)
        {
            this.db = db;
        }

        public async Task<Image> GetImage(string id)
        {
            return await db.Images.FindAsync(id) ?? throw new ImageNotFoundException();
        }

        public Task<ImageGroup> SaveImage(Image image)
        {
            //Build images with their resolutions
            var imageGroup = new ImageGroup();
            imageGroup.Images.Add(image);
            return imageGroup;
        }
    }
}
