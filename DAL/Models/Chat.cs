using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Chat
{
    public int IdChat { get; set; }

    public virtual ICollection<Message> Messages { get; set; } = new List<Message>();

    public virtual ICollection<Userschat> Userschats { get; set; } = new List<Userschat>();
}
