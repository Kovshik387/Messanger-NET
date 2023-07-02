using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Chat
{
    public int IdChat { get; set; }

    public int IdOwner { get; set; }

    public string? Name { get; set; }

    public virtual User IdOwnerNavigation { get; set; } = null!;

    public virtual ICollection<Message> Messages { get; set; } = new List<Message>();
}
