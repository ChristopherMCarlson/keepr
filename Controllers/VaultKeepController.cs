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
  public class VaultKeepController : Controller
  {
    private readonly VaultKeepRepository _repo;
    [HttpPost("CreateVaultKeep")]
    public VaultKeep Create([FromBody]VaultKeep vaultkeep)
    {
      vaultkeep.UserId = HttpContext.User.Identity.Name;
      if (!ModelState.IsValid) { throw new Exception("Invalid Input"); }
      VaultKeep newVaultKeep = _repo.Create(vaultkeep);
      if (vaultkeep == null) { throw new Exception("Invalid Input"); }
      return newVaultKeep;
    }
    [HttpPost("DeleteVaultKeep")]
    public bool Delete([FromBody]VaultKeep vaultkeep)
    {
      if (HttpContext.User.Identity.Name != vaultkeep.UserId) { throw new Exception("Cannot delete other's vaultkeeps!"); }
      bool deleted = _repo.Delete(vaultkeep);
      return deleted;
    }

    [HttpGet("{vaultId}")]
    public IEnumerable<Keep> GetVaultKeep(int vaultId)
    {
      return _repo.GetVaultKeep(vaultId);
    }

    public VaultKeepController(VaultKeepRepository repo)
    {
      _repo = repo;
    }
  }
}