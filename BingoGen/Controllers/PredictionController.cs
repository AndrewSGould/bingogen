using System.IO;
using System.Collections.Generic;
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
    IRepository<Prediction> predictionsRepository = null;

    public PredictionController()
    {
      predictionsRepository = new PredictionsRepository();
    }

    [HttpGet("/get")]
    public IActionResult Get()
    {
      IList<Prediction> prediction = predictionsRepository.GetAll();

      return Ok(prediction);
    }

    [HttpPost("/imageupload")]
    public string Upload([FromForm]IFormFile image, [FromForm]string prediction)
    {
      // TODO: Inject these from a service
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

      SavePrediction(uploadResult.SecureUri.AbsoluteUri);

      return uploadResult.SecureUri.AbsoluteUri;
    }

    public void SavePrediction(string uri)
    {
      // TODO: Save prediction details in the db
    }
  }
}
