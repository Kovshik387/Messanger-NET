using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Message
{
    public int IdMess { get; set; }

    public DateTime Datesend { get; set; }

    public string Body { get; set; } = null!;

    public bool Isread { get; set; }

    public int Userfrom { get; set; }

    public int Userto { get; set; }

    public int IdChat { get; set; }

    public virtual Chat IdChatNavigation { get; set; } = null!;

    public virtual Task? Task { get; set; }

    public virtual User UserfromNavigation { get; set; } = null!;

    public virtual User UsertoNavigation { get; set; } = null!;
}
