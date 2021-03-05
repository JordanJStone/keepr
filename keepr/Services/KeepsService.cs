using System;
using System.Collections.Generic;
using System.Linq;
using keepr.Models;
using keepr.Repositories;

namespace keepr.Services
{
  public class KeepsService
  {
    private readonly KeepsRepository _repo;
    private readonly VaultsRepository _vr;

    public KeepsService(KeepsRepository repo, VaultsRepository vr)
    {
      _repo = repo;
      _vr = vr;
    }

    public IEnumerable<Keep> GetAll()
    {
      IEnumerable<Keep> keeps = _repo.GetAll();
      return keeps;
    }

    internal Keep GetById(int id)
    {
      var data = _repo.GetById(id);
      if (data == null)
      {
        throw new Exception("Invalid Id");
      }
      return data;
    }

    public Keep Create(Keep newKeep)
    {
      newKeep.Id = _repo.Create(newKeep);
      return newKeep;
    }

    internal Keep Edit(Keep updated, string userId)
    {
      Keep original = GetById(updated.Id);
      if (original.CreatorId != userId) { throw new Exception("Access Denied: Cannot Edit a Keep You did not Create"); }
      //   TODO change this to Keeps, not Party info
      updated.Name = updated.Name != null ? updated.Name : original.Name;
      updated.Description = updated.Description != null ? updated.Description : original.Description;
      updated.Img = updated.Img != null ? updated.Img : original.Img;
      updated.Views = updated.Views != original.Views ? updated.Views : original.Views;
      updated.Shares = updated.Shares != original.Shares ? updated.Shares : original.Shares;
      updated.Keeps = updated.Keeps != original.Keeps ? updated.Keeps : original.Keeps;

      return _repo.Edit(updated);
    }

    internal string Delete(int id, string userId)
    {
      Keep original = _repo.GetById(id);
      if (original == null) { throw new Exception("Bad ID"); }
      if (original.CreatorId != userId) { throw new Exception("Access Denied: Cannot Edit a Keep you did not Create"); }
      _repo.Remove(id);
      return "successfully deleted";
    }

    internal IEnumerable<Keep> GetByVaultId(int id)
    {
      // return _repo.GetByVaultId(id).ToList().FindAll(r => id);
      Vault exists = _vr.GetById(id);
      if (exists == null)
      {
        throw new Exception("Invalid Id");
      }
      return _repo.GetByVaultId(id);

    }

    internal IEnumerable<Keep> GetKeepsByProfileId(string id)
    {
      return _repo.GetKeepsByProfileId(id).ToList().FindAll(r => r.CreatorId == id);
      // TODO put something in above line
    }

  }
}