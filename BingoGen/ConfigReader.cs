using Microsoft.Extensions.Configuration;
using System.IO;

namespace BingoGen
{
  public class ConfigReader
  {
    static IConfigurationRoot config = null;

    static ConfigReader()
    {
      var builder = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json");

      config = builder.Build();
    }

    public static string ConnectionString
    {
      get
      {
        return config.GetSection("RepositorySettings").GetValue<string>("DbConnection");
      }
    }
  }
}
