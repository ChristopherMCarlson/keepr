using System;
using System.Data;
using System.Linq;
using BCrypt.Net;
using keepr.Models;
using Dapper;
using System.Collections.Generic;

namespace keepr.Repositories
{
  public class VaultRepository
  {

    IDbConnection _db;

    //REGISTER

    public Vault Create(Vault vault)
    {
      int id = _db.ExecuteScalar<int>(@"
        INSERT INTO vaults (name, description, userId)
        VALUES (@name, @description, @userId);
        SELECT LAST_INSERT_ID();", vault
      );
      vault.Id = id;
      return vault;
    }

    public bool Delete(Vault vault)
    {
      int success = _db.Execute(@"
        DELETE FROM vaults WHERE id = @id;
      ", new
      {
        id = vault.Id
      });
      if (success != 1) { return false; }
      return true;
    }

    public Vault Edit(Vault vault)
    {
      int success = _db.Execute(@"
        UPDATE vaults SET name = @name, description = @description
        WHERE id = @Id;
      ", vault);
      if (success != 1) { return null; }
      return vault;
    }

    public IEnumerable<Vault> GetMyVaults(string userId)
    {
      return _db.Query<Vault>("SELECT * FROM vaults WHERE userId = @userId;", new
      {
        userId
      });
    }
    public VaultRepository(IDbConnection db)
    {
      _db = db;
    }
  }
}