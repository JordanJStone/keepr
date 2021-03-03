using System;
using System.Collections.Generic;
using System.Linq;
using keepr.Models;
using keepr.Repositories;

namespace keepr.Services
{
  public class VaultsService
  {

    private readonly VaultsRepository _repo;
    private readonly ProfilesRepository _pr;

    public VaultsService(VaultsRepository repo, ProfilesRepository pr)
    {
      _repo = repo;
      _pr = pr;
    }

    public IEnumerable<Vault> GetAll()
    // Do we ever need to get ALL Vaults? Should only need a specific profile's vaults
    {
      IEnumerable<Vault> vaults = _repo.GetAll();
      return vaults;
    }

    internal Vault GetById(int id)
    {
      var data = _repo.GetById(id);
      // NOTE The data.IsPrivate broke the editing for some reason, used to be if (data == null)
      if (data.IsPrivate)
      {
        throw new Exception("Invalid Id");
      }
      return data;
    }

    // internal Vault GetByIdForEditingOnly(int id)
    // {
    //   var data = _repo.GetById(id);
    //   if (data == null)
    //   {
    //     throw new Exception("Invalid Id");
    //   }
    //   return data;
    // }


    public Vault Create(Vault newVault)
    {
      newVault.Id = _repo.Create(newVault);
      return newVault;
    }

    internal Vault Edit(Vault updated, string userId)
    {
      Vault original = GetById(updated.Id);
      if (original.CreatorId != userId) { throw new Exception("Access Denied: Cannot Edit a Vault You did not Create"); }
      //   TODO change this to Vaults, not Party info
      updated.Name = updated.Name != null ? updated.Name : original.Name;
      updated.Description = updated.Description != null ? updated.Description : original.Description;
      updated.IsPrivate = updated.IsPrivate != original.IsPrivate ? updated.IsPrivate : original.IsPrivate;


      return _repo.Edit(updated);
    }

    internal string Delete(int id, string userId)
    {
      Vault original = _repo.GetById(id);
      if (original == null) { throw new Exception("Bad ID"); }
      if (original.CreatorId != userId) { throw new Exception("Access Denied: Cannot Edit a Vault you did not Create"); }
      _repo.Remove(id);
      return "successfully deleted";
    }

    internal IEnumerable<Vault> GetVaultsByProfileId(string id)
    {
      return _repo.GetVaultsByProfileId(id).ToList().FindAll(r => !r.IsPrivate);
    }

    // This comes from the Account Controller
    // GetVaultsByAccountId
    // internal IEnumerable<Vault> GetVaultsByAccountId(string id)
    // {
    //   return _repo.GetByCreatorId(id);

    // }


  }
}