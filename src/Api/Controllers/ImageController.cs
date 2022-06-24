using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Application.Services.Implementations;

namespace ImageSharingPlatform.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImageController : ControllerBase
    {
        readonly ImageService imageService;

        public ImageController(ImageService imageService)
        {
            this.imageService = imageService;
        }

        [HttpGet(Name = "GetImage")]
        public async Task<Image> Get(string id)
        {
            return await imageService.GetImage(id);
        }
    }
}