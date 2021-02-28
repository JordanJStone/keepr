using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
  public class VaultsRepository
  {

    private readonly IDbConnection _db;

    public VaultsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<Vault> GetAll()
    {
      // Do we need to get all Vaults???
      string sql = @"
       SELECT 
       vault.*,
       profile.* 
       FROM vaults vault 
       JOIN profiles profile ON vault.creatorId = profile.id;";
      return _db.Query<Vault, Profile, Vault>(sql, (vault, profile) => { vault.Creator = profile; return vault; }, splitOn: "id");
    }

    internal Vault GetById(int id)
    {
      string sql = @" 
      SELECT 
      vault.*,
      profile.*
      FROM vaults vault
      JOIN profiles profile ON vault.creatorId = profile.id
      WHERE vault.id = @id";
      return _db.Query<Vault, Profile, Vault>(sql, (vault, profile) =>
      {
        vault.Creator = profile;
        return vault;
      }, new { id }, splitOn: "id").FirstOrDefault();

    }

    internal int Create(Vault newVault)
    {
      string sql = @"
      INSERT INTO vaults 
      (creatorId, name, description, isPrivate) 
      VALUES 
      (@CreatorId, @Name, @Description, @IsPrivate);
      SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newVault);
    }

    internal Vault Edit(Vault updated)
    {
      string sql = @"
        UPDATE vaults
        SET
         name = @Name,
         description = @Description,
         isPrivate = @IsPrivate
        WHERE id = @Id;";
      _db.Execute(sql, updated);
      return updated;
    }

    // // REVIEW[epic=many-to-many] This sql will add the relationship id to a Party, as the PartyPartyMemberViewModel
    // internal IEnumerable<PartyPartyMemberViewModel> GetPartiesByProfileId(string id)
    // {
    //   string sql = @"
    //   SELECT
    //   p.*,
    //   pm.id as PartyMemberId
    //   FROM partymembers pm
    //   JOIN parties p ON pm.partyId == p.id
    //   WHERE memberId = @id
    //   ";
    //   return _db.Query<PartyPartyMemberViewModel>(sql, new { id });
    // }

    internal void Remove(int id)
    {
      string sql = "DELETE FROM vaults WHERE id = @Id LIMIT 1";
      _db.Execute(sql, new { id });
    }

  }
}