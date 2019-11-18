using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace BingoGen.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class PredictionController : ControllerBase
  {
    [HttpPost("/imageupload")]
    public string Upload([FromForm]IFormFile body)
    {
      var image = body;

      DotNetEnv.Env.Load("./../.env");

      var account = new Account(
                System.Environment.GetEnvironmentVariable("CLOUD_NAME"),
                System.Environment.GetEnvironmentVariable("API_KEY"),
                System.Environment.GetEnvironmentVariable("SECRET_KEY")
            );

      var cloudinary = new Cloudinary(account);

      var uploadParams = new ImageUploadParams();

      using (var ms = new MemoryStream())
      {
        image.CopyTo(ms);
        var fileBytes = ms.ToArray();

        var stream = new MemoryStream(fileBytes);
        uploadParams = new ImageUploadParams()
        {
          File = new FileDescription(image.FileName, stream),
          PublicId = image.FileName
        };
      }

      var uploadResult = cloudinary.Upload(uploadParams);
      return uploadResult.SecureUri.AbsoluteUri;
    }
  }
}
