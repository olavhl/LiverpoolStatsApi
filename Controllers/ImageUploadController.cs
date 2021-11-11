using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace LiverpoolStatsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImageUploadController: ControllerBase
    {
        private readonly IWebHostEnvironment _hosting;

        public ImageUploadController(IWebHostEnvironment hosting)
        {
            _hosting = hosting;
        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult SaveImage( IFormFile file )
        {
            string webRootPath = _hosting.WebRootPath;
            string absolutePath = Path.Combine( $"{webRootPath}/images/{file.FileName}" );

            try
            {
                using(var fileStream = new FileStream(absolutePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                return StatusCode(201);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpDelete]
        [Route("[action]")]
        public ActionResult DeleteImage( string imageName )
        {
            string webRootPath = _hosting.WebRootPath;
            string absolutePath = Path.Combine( $"{webRootPath}/images/${imageName}" );

            try
            {
                System.IO.File.Delete(absolutePath);
                return StatusCode(202);
            }
            catch
            {
                return StatusCode(500);
            }
        }

    }
}