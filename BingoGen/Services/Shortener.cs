using System;
using System.IO;
using System.Linq;

namespace BingoGen
{
  public class ShortenerService
  {
    private const int MAXIMUM_TIMES_TO_RETRY_SMALL_SEED = 3;
    private const int TOTAL_TIMES_TO_RETRY_SEED = 5;
    private const string WordDictionary = @"C:\Git\bingogen\BingoGen\Resources\google-10000-english-no-swears.txt";
    IBoardRepository<Board> boardsRepository = null;

    public ShortenerService()
    {
      boardsRepository = new BoardsRepository();
    }

    public string GenerateUniqueShortPhrase()
    {
      var rawData = File.ReadAllText(WordDictionary).Split("\n");
      var seedsTried = 0;

      return FindUniqueShortPhrase(new Random(), rawData, seedsTried);
    }

    public string FindUniqueShortPhrase(Random random, string[] rawData, int seedsTried)
    {
      if (seedsTried >= TOTAL_TIMES_TO_RETRY_SEED)
        throw new Exception();

      var firstRandomWord = rawData[random.Next(0, rawData.Length)];
      var secondRandomWord = rawData[random.Next(0, rawData.Length)];
      var possibleSeed = UppercaseFirst(firstRandomWord) + UppercaseFirst(secondRandomWord);

      if (seedsTried > MAXIMUM_TIMES_TO_RETRY_SMALL_SEED)
      {
        var thirdRandomWord = rawData[random.Next(0, rawData.Length)];
        possibleSeed += thirdRandomWord;
      }

      var existingSeeds = boardsRepository.GetExistingBoardSeeds();

      if (existingSeeds.Contains(possibleSeed))
        FindUniqueShortPhrase(random, rawData, ++seedsTried);

      return possibleSeed;
    }

    static string UppercaseFirst(string s)
    {
      if (string.IsNullOrEmpty(s))
      {
        return string.Empty;
      }
      char[] a = s.ToCharArray();
      a[0] = char.ToUpper(a[0]);
      return new string(a);
    }
  }
}
