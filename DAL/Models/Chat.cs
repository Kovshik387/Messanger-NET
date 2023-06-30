using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Chat
{
    public int IdChat { get; set; }

    public string? Name { get; set; }

    public int IdUserone { get; set; }

    public int IdUsertwo { get; set; }

    public virtual User IdUseroneNavigation { get; set; } = null!;

    public virtual User IdUsertwoNavigation { get; set; } = null!;

    public virtual ICollection<Message> Messages { get; set; } = new List<Message>();
}
