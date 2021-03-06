using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
  public class VaultKeepsRepository
  {
    private readonly IDbConnection _db;

    public VaultKeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<VaultKeep> GetAll()
    {
      string sql = @"
       SELECT 
       vk.*,
       profile.* 
       FROM vaultkeeps vk 
       JOIN profiles profile ON vk.creatorId = profile.id;";
      return _db.Query<VaultKeep, Profile, VaultKeep>(sql, (vk, profile) => { vk.CreatorId = profile.Id; return vk; }, splitOn: "id");
      // string sql = "SELECT * FROM vaultkeeps;";
      // return _db.Query<VaultKeep>(sql);
    }

    internal VaultKeep GetById(int id)
    {
      string sql = "SELECT * FROM vaultkeeps WHERE id = @id;";
      return _db.QueryFirstOrDefault<VaultKeep>(sql, new { id });
    }

    internal int Create(VaultKeep vk)
    {
      string sql = @"
      INSERT INTO vaultkeeps
      (creatorId, vaultId, keepId)
      VALUES
      (@CreatorId, @VaultId, @KeepId);
      UPDATE keeps
      SET
        keeps = keeps + 1
      WHERE id = @KeepId;
      SELECT LAST_INSERT_ID()";
      return _db.ExecuteScalar<int>(sql, vk);
    }


    internal void Delete(int id)
    {
      string sql = "DELETE FROM vaultkeeps WHERE id = @id LIMIT 1;";
      _db.Execute(sql, new { id });
    }

  }
}