using System.Collections.Generic;

namespace BingoGen
{
  interface IRepository<T> where T : class
  {
    List<T> GetAll();
    bool Add(T Prediction);
    T GetById(int id);
    bool Update(T prediction);
    bool Delete(int id);
  }
}
