using Persistance;
using Domain.Models;
using System.Threading.Tasks;
using Application.Services.Interfaces;
using Application.Exceptions;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Collections.Generic;

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

        public async Task<ImageGroup> SaveImage(IFormFile file, string serverFolder)
        {
            var images = SaveImageWithMultipleResolutions(file, serverFolder);

            var imageGroup = new ImageGroup();            
            imageGroup.Images.AddRange(images);

            db.ImageGroups.Add(imageGroup);
            await db.SaveChangesAsync();

            return imageGroup;
        }

        Image SaveImageFile(IFormFile file, string serverFolder, ImageResolution resolution)
        {
            var image = new Image();
            var imageVirtualPath = Path.Combine("images", image.Id + Path.GetExtension(file.FileName));
            var path = Path.Combine(serverFolder, imageVirtualPath);
            using (var fs = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(fs);
            }

            var serverUrl = "https://localhost:49163/";
            image.Url = serverUrl + imageVirtualPath;
            image.Resolution = resolution;

            return image;
        }

        IEnumerable<Image> SaveImageWithMultipleResolutions(IFormFile file, string serverFolder)
        {
            yield return SaveImageFile(file, serverFolder, ImageResolution.OriginalSize);
            yield return SaveImageFile(file, serverFolder, ImageResolution.Avatar);
            yield return SaveImageFile(file, serverFolder, ImageResolution.FullHd);
            yield return SaveImageFile(file, serverFolder, ImageResolution.Hd);
        }
    }
}
