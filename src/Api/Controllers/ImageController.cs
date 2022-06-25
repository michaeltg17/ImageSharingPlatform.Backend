using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Application.Services.Interfaces;

namespace ImageSharingPlatform.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImageController : ControllerBase
    {
        readonly IImageService imageService;

        public ImageController(IImageService imageService)
        {
            this.imageService = imageService;
        }

        [HttpGet(Name = "GetImage")]
        public async Task<Image> Get(string id)
        {
            return await imageService.GetImage(id);
        }

        [HttpPost(Name = "SaveImage")]
        public async Task<ImageGroup> SaveImage(IFormFile file)
        {
            var image = new Image();
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                image.Value = ms.ToArray();
            }

            await imageService.SaveImage(image);
        }
    }
}