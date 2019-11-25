using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BingoGen
{
  public class PredictionsRepository : IRepository<Prediction>
  {
    private IDbConnection conn = null;

    public PredictionsRepository()
    {
      conn = new SqlConnection(ConfigReader.ConnectionString);
    }

    public bool Add(Prediction prediction)
    {
      var result = false;
      try
      {
        string sql =
        @"INSERT INTO [dbo].[Predictions] (Prediction, Difficulty, ImageUri, CreatedBy, fk_BoardId, fk_CardId) " +
          "VALUES (@predictionText, @difficulty, @imageUri, @createdBy, @boardId, @cardId)";

        var count = conn.Execute(sql, prediction);
        result = count > 0;
      }
      catch (Exception ex)
      {
        throw ex;
      }

      return result;
    }

    public Prediction AddWithObjectReturn(Prediction prediction)
    {
      throw new NotImplementedException();
    }
  }
}
