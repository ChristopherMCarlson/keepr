using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace keepr.Models
{
  public class VaultKeep
  {
    public int VaultId { get; set; }

    public int KeepId { get; set; }

    public string UserId { get; set; }

    public int Id { get; set; }

  }
}