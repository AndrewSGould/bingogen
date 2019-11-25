using System.Collections.Generic;

namespace BingoGen
{
  interface IRepository<T> where T : class
  {
    bool Add(T _object);
    T AddWithObjectReturn(T _object);
  }
}
