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
        readonly IWebHostEnvironment webHostEnvironment;

        public ImageController(
            IImageService imageService, 
            IWebHostEnvironment webHostEnvironment)
        {
            this.imageService = imageService;
            this.webHostEnvironment = webHostEnvironment;
        }

        [HttpGet(Name = "GetImage")]
        public async Task<Image> Get(string id)
        {
            return await imageService.GetImage(id);
        }

        [HttpPost(Name = "SaveImage")]
        public async Task<ImageGroup> SaveImage(IFormFile file)
        {
            //I didn't want to use IFormFile in the Application Project but 1 - Same server for storing and managing and 2 - Better than using an extra stream (performance)
            return await imageService.SaveImage(file, webHostEnvironment.WebRootPath);
        }
    }
}