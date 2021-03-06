using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using legoland.Models;

namespace legoland.Repositories
{
  public class BricksRepository
  {
    private readonly IDbConnection _db;
    public BricksRepository(IDbConnection db)
    {
      _db = db;
    }


    internal Brick Get(int id)
    {
      string sql = "SELECT * FROM bricks WHERE id = @id";
      return _db.QueryFirstOrDefault<Brick>(sql, new { id });
    }

    internal IEnumerable<Brick> Get()
    {
      string sql = "SELECT * FROM bricks";
      return _db.Query<Brick>(sql);
    }


    internal void Delete(int id)
    {
      string sql = "DELETE FROM bricks WHERE id = @id";
      _db.Execute(sql, new { id });
    }

    internal int Create(Brick newBrick)
    {
      string sql = @"
                INSERT INTO bricks
                (name, color)
                VALUES
                (@Name, @Color);
                SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newBrick);
    }

    internal IEnumerable<Brick> getBricksByKitId(int kitId)
    {
      string sql = @"
      SELECT b.*,
      kb.id as KitBrickId
      FROM kitbricks kb
      JOIN bricks b on b.id = kb.brickId
      WHERE kitId = @kitId
      ";

    return _db.Query<KitBrickViewModel>(sql, new {kitId});
    }
  }
}