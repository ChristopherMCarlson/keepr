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
  public class KeepController : Controller
  {
    private readonly KeepRepository _repo;
    [HttpPost("CreateKeep")]
    public Keep Create([FromBody]Keep keep)
    {
      keep.UserId = HttpContext.User.Identity.Name;
      if (!ModelState.IsValid) { throw new Exception("Invalid Input"); }
      Keep newKeep = _repo.Create(keep);
      if (keep == null) { throw new Exception("Invalid Input"); }
      return newKeep;
    }
    [HttpPost("DeleteKeep")]
    public bool Delete([FromBody]Keep keep)
    {
      if (HttpContext.User.Identity.Name != keep.UserId) { throw new Exception("Cannot delete other's keeps!"); }
      bool deleted = _repo.Delete(keep);
      return deleted;
    }

    [HttpPut("EditKeep")]
    public Keep Edit([FromBody]Keep keep)
    {
      if (HttpContext.User.Identity.Name != keep.UserId) { throw new Exception("Cannot edit other's keeps!"); }
      return _repo.Edit(keep);
    }

    [HttpGet("GetKeeps")]
    public IEnumerable<Keep> Get()
    {
      return _repo.GetAll();
    }

    [HttpGet("GetMyKeeps")]
    public IEnumerable<Keep> GetMyKeeps()
    {
      string userId = HttpContext.User.Identity.Name;
      return _repo.GetMyKeeps(userId);
    }
    public KeepController(KeepRepository repo)
    {
      _repo = repo;
    }
  }
}