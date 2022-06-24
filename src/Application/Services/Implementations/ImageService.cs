using Persistance;
using Domain.Models;
using System.Threading.Tasks;
using Application.Services.Interfaces;

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
            var image = new Image() { Name = "myImage" };
            db.Images.Add(image);
            await db.SaveChangesAsync();
            return image;
        }
    }
}
