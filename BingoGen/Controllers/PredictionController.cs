using System.IO;
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
    IRepository<Board> boardsRepository = null;
    ShortenerService shortenerService = null;

    public PredictionController(ILogger<PredictionController> logger)
    {
      _logger = logger;
      predictionsRepository = new PredictionsRepository();
      boardsRepository = new BoardsRepository();
      shortenerService = new ShortenerService();
    }

    [HttpGet("/get")]
    public Board Get()
    {
      var test = boardsRepository.AddWithObjectReturn(new Board
      {
        Seed = "CatDog",
        CreatedBy = "TestUser"
      });

      return test;
    }

    [HttpPost("/imageupload")]
    public IActionResult Upload([FromForm]IFormFile image, [FromForm]string predictionText, [FromForm]int difficulty)
    {
      // TODO: Santitize input from client

      // TODO: check if board does not exist, do not hardcode new board
      var board = boardsRepository.AddWithObjectReturn(new Board
      {
        Seed = shortenerService.GenerateUniqueShortPhrase(),
        CreatedBy = "Test User" // TODO: Implement this
      });

      var prediction = new Prediction
      {
        PredictionText = predictionText,
        Difficulty = difficulty,
        ImageUri = Upload(image),
        CreatedBy = "Test User", // TODO: implement this
        BoardId = board.Id,
        CardId = null // explicit, not assigned to a card until a card is generated with it
      };

      if (predictionsRepository.Add(prediction))
        return Ok(prediction);

      // on this create page (without a board id) first, create the board
      // then, add the prediction to the board

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
