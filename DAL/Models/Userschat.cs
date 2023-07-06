using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Userschat
{
    public int IdUchat { get; set; }

    public int IdUser { get; set; }

    public int IdChat { get; set; }

    public virtual Chat IdChatNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}
