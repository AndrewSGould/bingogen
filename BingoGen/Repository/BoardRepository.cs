using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace BingoGen
{
  public class BoardsRepository : IBoardRepository<Board>
  {
    private IDbConnection conn = null;

    public BoardsRepository()
    {
      conn = new SqlConnection(ConfigReader.ConnectionString);
    }

    public bool Add(Board board)
    {
      throw new NotImplementedException();
    }

    public Board AddWithObjectReturn(Board board)
    {
      try
      {
        string sql = @"INSERT INTO Boards (Seed, CreatedBy) OUTPUT INSERTED.* VALUES (@seed, @createdBy)";

        return conn.QuerySingle<Board>(sql, board);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public IEnumerable<string> GetExistingBoardSeeds()
    {
      string sql = @"select Seed from Boards";

      return conn.Query<Board>(sql).Select(x => x.Seed).AsEnumerable();
    }
  }
}
