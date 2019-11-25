using System.Collections.Generic;

namespace BingoGen
{
  interface IBoardRepository<T> : IRepository<Board>
  {
    IEnumerable<string> GetExistingBoardSeeds();
  }
}
