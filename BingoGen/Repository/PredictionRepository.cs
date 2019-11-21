using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace BingoGen
{
  public class PredictionsRepository : IRepository<Prediction>
  {
    private IDbConnection dbConnection = null;

    public PredictionsRepository()
    {
      dbConnection = new SqlConnection(ConfigReader.ConnectionString);
    }

    public List<Prediction> GetAll()
    {
      string sql = ConfigReader.ReadAllCommand;
      var queryResult = dbConnection.Query<Prediction>(sql);

      return queryResult.ToList();
    }

    public bool Add(Prediction prediction)
    {
      var result = false;
      try
      {
        string sql = ConfigReader.InsertCommand;

        var count = dbConnection.Execute(sql, prediction);
        result = count > 0;
      }
      catch { }

      return result;
    }

    public Prediction GetById(int id)
    {
      Prediction prediction = null;
      string sql = ConfigReader.ReadOneCommand;
      var queryResult = dbConnection.Query<Prediction>(sql, new { Id = id });

      if (queryResult != null)
      {
        prediction = queryResult.FirstOrDefault();
      }
      return prediction;
    }

    public bool Update(Prediction prediction)
    {
      throw new NotImplementedException();
    }

    public bool Delete(int id)
    {
      throw new NotImplementedException();
    }
  }
}
