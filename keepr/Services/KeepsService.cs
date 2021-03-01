using System;
using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;

namespace keepr.Services
{
  public class KeepsService
  {
    private readonly KeepsRepository _repo;

    public KeepsService(KeepsRepository repo)
    {
      _repo = repo;
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
      updated.Name = updated.Name != null ? updated.Name : original.Name;

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

    internal IEnumerable<KeepsByVaultViewModel> GetByProfileId(string id)
    {
      IEnumerable<KeepsByVaultViewModel> data = _repo.GetKeepsByVaultId(id);
      return data;
    }

  }
}