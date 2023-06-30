using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Role
{
    public int IdRole { get; set; }

    public string Type { get; set; } = null!;

    public virtual Authorize? Authorize { get; set; }
}
