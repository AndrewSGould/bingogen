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
        return config.GetSection("PredictionRepositorySettings").GetValue<string>("DbConnection");
      }
    }

    public static string InsertCommand
    {
      get
      {
        return config.GetSection("PredictionRepositorySettings").GetValue<string>("InsertCommand");
      }
    }

    public static string ReadAllCommand
    {
      get
      {
        return config.GetSection("PredictionRepositorySettings").GetValue<string>("ReadAllCommand");
      }
    }

    public static string ReadOneCommand
    {
      get
      {
        return config.GetSection("PredictionRepositorySettings").GetValue<string>("ReadOneCommand");
      }
    }
  }
}
