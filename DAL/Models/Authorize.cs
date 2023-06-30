using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Authorize
{
    public int IdAuthorize { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int IdRole { get; set; }

    public virtual Role IdRoleNavigation { get; set; } = null!;

    public virtual User? User { get; set; }
}
