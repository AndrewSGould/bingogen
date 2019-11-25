using System;
using System.IO;

namespace BingoGen
{
  public class ShortenerService
  {
    private const string WordDictionary = @"C:\Git\bingogen\BingoGen\Resources\google-10000-english-no-swears.txt";

    public string GenerateUniqueShortPhrase()
    {
      var random = new Random();


      var rawData = File.ReadAllText(WordDictionary).Split("\n");
      var firstRandomWord = rawData[random.Next(0, rawData.Length)];
      var secondRandomWord = rawData[random.Next(0, rawData.Length)];

      // uppercase the first letter in each word
      var seed = UppercaseFirst(firstRandomWord) + UppercaseFirst(secondRandomWord);

      // check to see if what is selected is already a 'Seed'

      // if it is, regenerate up to 3 times

      // if it's still failing, add a third word to the 'Seed'

      // once successful, return the unique seed
      return "";
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
