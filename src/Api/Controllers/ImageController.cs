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

        [HttpGet(Name = "SaveImage")]
        public async Task SaveImage(IFormFile image)
        {
            await imageService.SaveImage();
        }
    }
}