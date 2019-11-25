using NUnit.Framework;
using BingoGen;
using System;
using System.IO;

namespace BingoGenTests
{
  public class ShortenerServiceTests
  {
    private ShortenerService Shortener = new ShortenerService();
    private const string WordDictionary = @"C:\Git\bingogen\BingoGen\Resources\google-10000-english-no-swears.txt";
    private string[] rawData = null;

    [SetUp]
    public void Setup()
    {
      rawData = File.ReadAllText(WordDictionary).Split("\n");
    }

    [Test]
    public void Shortener_Throws_At_Max_Retries()
    {
      Assert.Throws<Exception>(delegate { Shortener.FindUniqueShortPhrase(new Random(), rawData, 6); });
    }

    [Test]
    public void Shortener_Generates_String()
    {
      var result = Shortener.FindUniqueShortPhrase(new Random(), rawData, 2);
      Assert.That(typeof(string) == result.GetType());
    }
  }
}