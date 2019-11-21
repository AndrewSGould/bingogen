using System.IO;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
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
    private readonly ILogger<PredictionController> _logger;
    IRepository<Prediction> predictionsRepository = null;

    public PredictionController(ILogger<PredictionController> logger)
    {
      _logger = logger;
      predictionsRepository = new PredictionsRepository();
    }

    [HttpGet("/get")]
    public IActionResult Get()
    {
      _logger.LogInformation("Testing 1, 2, 3...");
      IList<Prediction> prediction = predictionsRepository.GetAll();

      return Ok(prediction);
    }

    [HttpPost("/imageupload")]
    public IActionResult Upload([FromForm]IFormFile image, [FromForm]string predictionText, [FromForm]int difficulty)
    {
      // TODO: Santitize input from client

      var prediction = new Prediction
      {
        PredictionText = predictionText,
        Difficulty = difficulty,
        ImageUri = Upload(image),
        CreatedBy = "" // TODO: implement this
      };

      if (predictionsRepository.Add(prediction))
        return Ok(prediction);

      return BadRequest();
    }

    private string Upload(IFormFile image)
    {
      DotNetEnv.Env.Load("./../.env");
      // TODO: Inject these from a service
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

      return cloudinary.Upload(uploadParams).SecureUri.AbsoluteUri;
    }
  }
}
