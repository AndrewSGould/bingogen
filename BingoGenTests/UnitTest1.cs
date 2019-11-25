using NUnit.Framework;
using BingoGen;
using BingoGen.Controllers;

namespace BingoGenTests
{
  public class BingoGenTests
  {
    private ShortenerService Shortener = new ShortenerService();
    private PredictionController PredictionController = new PredictionController(null);

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestShortener()
    {
      Shortener.GenerateUniqueShortPhrase();
      Assert.Pass();
    }

    [Test]
    public void TestController()
    {
      PredictionController.Get();
      Assert.Pass();
    }
  }
}