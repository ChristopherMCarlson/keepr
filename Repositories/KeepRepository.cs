using System;
using System.Data;
using System.Linq;
using BCrypt.Net;
using keepr.Models;
using Dapper;
using System.Collections.Generic;

namespace keepr.Repositories
{
  public class KeepRepository
  {

    IDbConnection _db;

    //REGISTER

    public Keep Create(Keep keep)
    {
      int id = _db.ExecuteScalar<int>(@"
        INSERT INTO keeps (name, description, isPrivate, img, userId)
        VALUES (@name, @description, @isPrivate, @img, @userId);
        SELECT LAST_INSERT_ID();", keep
      );
      keep.Id = id;
      return keep;
    }

    public bool Delete(Keep keep)
    {
      int success = _db.Execute(@"
        DELETE FROM keeps WHERE id = @id AND isPrivate = true;
      ", new
      {
        id = keep.Id
      });
      if (success != 1) { return false; }
      return true;
    }

    public Keep Edit(Keep keep)
    {
      int success = _db.Execute(@"
        UPDATE keeps SET name = @name, description = @description, isPrivate = @isPrivate, img = @img, views = @views, keeps = @keeps, shares = @shares
        WHERE id = @Id;
      ", keep);
      if (success != 1) { return null; }
      return keep;
    }

    public IEnumerable<Keep> GetAll()
    {
      return _db.Query<Keep>("SELECT * FROM keeps WHERE isPrivate = false;");
    }

    public IEnumerable<Keep> GetMyKeeps(string userId)
    {
      return _db.Query<Keep>("SELECT * FROM keeps WHERE userId = @userId;", new
      {
        userId
      });
    }
    public KeepRepository(IDbConnection db)
    {
      _db = db;
    }
  }
}