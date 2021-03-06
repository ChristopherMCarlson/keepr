using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
  [Route("api/[controller]")]
  public class VaultController : Controller
  {
    private readonly VaultRepository _repo;
    [HttpPost("CreateVault")]
    public Vault Create([FromBody]Vault vault)
    {
      vault.UserId = HttpContext.User.Identity.Name;
      if (!ModelState.IsValid) { throw new Exception("Invalid Input"); }
      Vault newVault = _repo.Create(vault);
      if (vault == null) { throw new Exception("Invalid Input"); }
      return newVault;
    }
    [HttpPost("DeleteVault")]
    public bool Delete([FromBody]Vault vault)
    {
      if (HttpContext.User.Identity.Name != vault.UserId) { throw new Exception("Cannot delete other's vaults!"); }
      bool deleted = _repo.Delete(vault);
      return deleted;
    }

    [HttpPut("EditVault")]
    public Vault Edit([FromBody]Vault vault)
    {
      return _repo.Edit(vault);
    }

    [HttpGet("GetMyVaults")]
    public IEnumerable<Vault> Get()
    {
      string userId = HttpContext.User.Identity.Name;
      return _repo.GetMyVaults(userId);
    }

    public VaultController(VaultRepository repo)
    {
      _repo = repo;
    }
  }
}