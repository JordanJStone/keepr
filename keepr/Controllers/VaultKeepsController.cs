using System;
using keepr.Models;
using keepr.Services;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
  public class VaultKeepsController : ControllerBase
  {

    private readonly VaultKeepsService _service;

    public VaultKeepsController(VaultKeepsService service)
    {
      _service = service;
    }

    [HttpPost]
    public ActionResult<string> Create([FromBody] VaultKeep vk)
    {
      try
      {
        _service.Create(vk);
        return Ok("success");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        _service.Delete(id);
        return Ok("success");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}