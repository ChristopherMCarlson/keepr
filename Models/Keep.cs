using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace keepr.Models
{
  public class Keep
  {
    public string Name { get; set; }

    public string Description { get; set; }

    public string UserId { get; set; }

    public string Img { get; set; }

    public bool isPrivate { get; set; } = true;

    public int Views { get; set; }

    public int Shares { get; set; }

    public int Keeps { get; set; }

    public int Id { get; set; }

  }
}