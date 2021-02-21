using System.Data;

namespace allspice.Repositories
{
  public class IngredientsRepository
  {
    public readonly IDbConnection _db;

    public IngredientsRepository(IDbConnection db)
    {
      _db = db;
    }
  }
}