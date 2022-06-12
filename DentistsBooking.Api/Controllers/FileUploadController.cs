using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace DentistsBooking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;
        public FileUploadController(IWebHostEnvironment env)
        {
            _env= env;
        }
        [HttpPost]
        public async Task<IActionResult> Upload([FromForm] IFormFile file)
        {
            if (file == null)
            {
                return new BadRequestResult();
            }
            if (file.Length == 0) return new BadRequestResult();
            string path = @$"{_env.WebRootPath}\uploads\{file.FileName}";
            using MemoryStream ms = new();
            await file.CopyToAsync(ms);
            await System.IO.File.WriteAllBytesAsync(path, ms.ToArray());
            return new OkResult();
        }
     
    }
}
