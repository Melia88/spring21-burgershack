using System.Collections.Generic;
using System.Data;
using burgershack.Interfaces;
using burgershack.Models;
using Dapper;

namespace burgershack.Repositories
{
  public class SidesRepository : IRepo<Side>
  {
    private readonly IDbConnection _db;

    public SidesRepository(IDbConnection db)
    {
      _db = db;
    }

    public Side Create(Side newSide)
    {
      string sql = @"
        INSERT INTO sides
        (name, cost, quantity, modifications)
        VALUES
        (@Name, @Cost, @Quantity, @Modifications)
        SELECT LAST_INSERT_ID";
      newSide.Id = _db.ExecuteScalar<int>(sql, newSide);
      return newSide;

    }

    public IEnumerable<Side> GetAll()
    {
      string sql = @"
    SELECT
    *
    FROM sides";
      return _db.Query<Side>(sql);
    }

    public Side GetById(int id)
    {
      string sql = @"
        SELECT 
        *
        FROM sides
        WHERE id = @id";
      return _db.QueryFirstOrDefault<Side>(sql, new { id });
    }

    public bool Update(Side data)
    {
      string sql = @"
        name = @Name,
        cost = @Cost,
        quantity = @Quantity,
        modifications =@Modifications
        WHERE id = @id
        ";
      int affectedRows = _db.Execute(sql, data);
      return affectedRows == 1;
    }

    internal bool Delete(int id)
    {
      string sql = "DELETE FROM sides WHERE id = @id LIMT 1";
      int affectedRows = _db.Execute(sql, new { id });
      return affectedRows == 1;
    }
  }

}