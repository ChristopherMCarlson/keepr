using System;
using System.Data;
using System.Linq;
using BCrypt.Net;
using keepr.Models;
using Dapper;
using System.Collections.Generic;

namespace keepr.Repositories
{
  public class VaultKeepRepository
  {

    IDbConnection _db;

    //REGISTER
    public VaultKeep Create(VaultKeep vaultkeep)
    {
      int id = _db.ExecuteScalar<int>(@"
        INSERT INTO vaultkeeps (VaultId, KeepId, UserId)
        VALUES (@VaultId, @KeepId, @UserId);
        SELECT LAST_INSERT_ID();", vaultkeep
      );
      vaultkeep.Id = id;
      return vaultkeep;
    }

    public bool Delete(VaultKeep vaultkeep)
    {
      int success = _db.Execute(@"
        DELETE FROM vaultkeeps WHERE id = @id;
      ", new
      {
        id = vaultkeep.Id
      });
      if (success != 1) { return false; }
      return true;
    }

    public VaultKeepRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Keep> GetVaultKeep(int vaultId)
    {
      return _db.Query<Keep>(@"
      SELECT * FROM vaultkeeps vk
      INNER JOIN keeps k ON k.id = vk.keepId
      WHERE (vaultId = @vaultId)
      ", new
      {
        vaultId
      });
    }
  }
}