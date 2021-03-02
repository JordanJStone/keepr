using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using keepr.Models;
using keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class VaultsController : ControllerBase
  {

    private readonly VaultsService _service;
    private readonly KeepsService _ks;
    public VaultsController(VaultsService service, KeepsService ks)
    {
      _service = service;
      _ks = ks;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Vault>> Get()
    // Do we need a get all vaults?
    {
      try
      {
        return Ok(_service.GetAll());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // [HttpGet("{id}")]
    // // No Auth needed here? Can't have two "Get"s, one with auth and one without.
    // public ActionResult<IEnumerable<Vault>> Get(int id)
    // {
    //   try
    //   {
    //     return Ok(_service.GetById(id));
    //   }
    //   catch (Exception e)
    //   {
    //     return BadRequest(e.Message);
    //   }
    // }

    [HttpGet("{id}")]
    // No Auth needed here? Can't have two "Get"s, one with auth and one without.
    public ActionResult<IEnumerable<Vault>> Get(int id)
    {
      try
      {
        return Ok(_service.GetById(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // [HttpGet("{id}")]
    // [Authorize]
    // public ActionResult<IEnumerable<Vault>> GetAuthorized(int id)
    // {
    //   try
    //   {
    //     return Ok(_service.GetById(id));
    //   }
    //   catch (Exception e)
    //   {
    //     return BadRequest(e.Message);
    //   }
    // }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Vault>> Create([FromBody] Vault newVault)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        newVault.CreatorId = userInfo.Id;
        Vault created = _service.Create(newVault);
        created.Creator = userInfo;
        return Ok(created);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult<Vault>> Edit(int id, [FromBody] Vault updated)
    // Delete this put? Do we need it? Double check in Postman
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        updated.Id = id;
        updated.Creator = userInfo;
        return Ok(_service.Edit(updated, userInfo.Id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<string>> Delete(int id)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        return Ok(_service.Delete(id, userInfo.Id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet(("{id}/keeps"))]
    // [Authorize]
    public ActionResult<IEnumerable<Vault>> GetKeepsByVaultId(int id)
    {
      try
      {
        return Ok(_ks.GetByVaultId(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}