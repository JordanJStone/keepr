using System;
using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;

namespace keepr.Services
{
  public class VaultKeepsService
  {

    private readonly VaultKeepsRepository _repo;

    public VaultKeepsService(VaultKeepsRepository repo)
    {
      _repo = repo;
    }

    public IEnumerable<VaultKeep> GetAll()
    {
      IEnumerable<VaultKeep> vaultkeeps = _repo.GetAll();
      return vaultkeeps;
    }

    // internal void Create(VaultKeep vk)
    // {
    //   _repo.Create(vk);
    // }
    public VaultKeep Create(VaultKeep newVaultKeep)
    {
      newVaultKeep.Id = _repo.Create(newVaultKeep);
      return newVaultKeep;
    }

    internal string Delete(int id, string userId)
    {
      VaultKeep original = _repo.GetById(id);
      if (original == null) { throw new Exception("Bad ID"); }
      if (original.CreatorId != userId) { throw new Exception("Access Denied: Cannot Edit a VaultKeep You did not Create"); }
      _repo.Delete(id);
      return "successfully deleted";
    }

  }
}