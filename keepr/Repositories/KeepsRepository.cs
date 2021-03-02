using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
  public class KeepsRepository
  {
    private readonly IDbConnection _db;

    public KeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<Keep> GetAll()
    {
      string sql = @"
       SELECT 
       keep.*,
       profile.* 
       FROM keeps keep 
       JOIN profiles profile ON keep.creatorId = profile.id;";
      return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) => { keep.Creator = profile; return keep; }, splitOn: "id");
    }

    internal Keep GetById(int id)
    {
      string sql = @" 
      SELECT 
      keep.*,
      profile.*
      FROM keeps keep
      JOIN profiles profile ON keep.creatorId = profile.id
      WHERE keep.id = @id";
      return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) =>
      {
        keep.Creator = profile;
        return keep;
      }, new { id }, splitOn: "id").FirstOrDefault();

    }

    internal int Create(Keep newKeep)
    {
      string sql = @"
      INSERT INTO keeps 
      (creatorId, name, description, img, views, shares, keeps) 
      VALUES 
      (@CreatorId, @Name, @Description, @Img, @Views, @Shares, @Keeps);
      SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newKeep);
    }

    internal Keep Edit(Keep updated)
    {
      string sql = @"
        UPDATE keeps
        SET
         name = @Name,
         description = @Description,
         img = @Img,
         views = @Views,
         shares = @Shares,
         keeps = @Keeps
        WHERE id = @Id;";
      _db.Execute(sql, updated);
      return updated;
    }

    // // REVIEW[epic=many-to-many] This sql will add the relationship id to a Party, as the PartyPartyMemberViewModel
    // internal IEnumerable<Keep> GetByVaultId(string id)
    // {
    //   string sql = @"
    //   SELECT
    //   keep.*,
    //   vk.id as VaultKeepId
    //   FROM vaultkeeps vk
    //   JOIN keeps keep ON vk.keepId == keep.id
    //   WHERE memberId = @id
    //   ";
    //   return _db.Query<KeepsByVaultViewModel>(sql, new { id });
    // }

    // internal IEnumerable<Keep> GetByVaultId(int id)
    // {
    //   string sql = @"
    //    SELECT 
    //    keep.*,
    //    profile.* 
    //    FROM keeps keep 
    //    JOIN profiles profile ON keep.creatorId = profile.id
    //    WHERE keep.creatorId = @id;";
    //   return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) => { keep.Creator = profile; return keep; }, new { id }, splitOn: "id");
    // }

    internal IEnumerable<Keep> GetByVaultId(int vaultId)
    {
      string sql = @"
      SELECT keep.*,
      v.id as VaultKeepId
      FROM vaultkeeps v
      JOIN keeps keep ON keep.id = v.keepId
      WHERE vaultId = @vaultId";

      return _db.Query<KeepsByVaultViewModel>(sql, new { vaultId });
    }

    internal void Remove(int id)
    {
      string sql = "DELETE FROM keeps WHERE id = @Id LIMIT 1";
      _db.Execute(sql, new { id });
    }

    // GetKeepsByProfileId
    internal IEnumerable<Keep> GetKeepsByProfileId(string id)
    {
      string sql = @"
       SELECT 
       keep.*,
       profile.* 
       FROM keeps keep
       JOIN profiles profile ON keep.creatorId = profile.id
       WHERE keep.creatorId = @id;";
      return _db.Query<Keep, Profile, Keep>(sql, (keep, profile) => { keep.Creator = profile; return keep; }, new { id }, splitOn: "id");

    }
  }
}