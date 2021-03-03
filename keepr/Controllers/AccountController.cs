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
  [Authorize]
  public class AccountController : ControllerBase
  {

    private readonly ProfilesService _ps;
    private readonly VaultsService _vs;

    public AccountController(ProfilesService ps, VaultsService vs)
    {
      _ps = ps;
      _vs = vs;
    }

    [HttpGet]
    public async Task<ActionResult<Profile>> Get()
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        return Ok(_ps.GetOrCreateProfile(userInfo));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    // [HttpGet("vaults")]
    // public async Task<ActionResult<IEnumerable<Vault>>> GetVaultsByProfileIdAsync()
    // {
    //   try
    //   {
    //     Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
    //     IEnumerable<Vault> vaults = _vs.GetVaultsByAccountId(userInfo.Id);
    //     return Ok(vaults);
    //   }
    //   catch (Exception e)
    //   {
    //     return BadRequest(e.Message);
    //   }
    // }

  }
}