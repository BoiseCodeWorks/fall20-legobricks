using System;
using System.Data;
using Dapper;
using legoland.Models;

namespace legoland.Repositories
{
  public class KitBricksRepository
  {
    private readonly IDbConnection _db;

    public KitBricksRepository(IDbConnection db)
    {
      _db = db;
    }

    internal int Create(KitBrick newKb)
    {
      string sql = @"
        INSERT INTO kitbricks
        (brickId, kitId)
        VALUES
        (@BrickId, @KitId);
        SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newKb);
    }
  }
}