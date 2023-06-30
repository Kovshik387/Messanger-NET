using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Task
{
    public int IdTask { get; set; }

    public DateTime Daterealization { get; set; }

    public DateTime Enddaterealization { get; set; }

    public DateTime? Factdaterealization { get; set; }

    public bool Isdone { get; set; }

    public int? IdMessage { get; set; }

    public virtual Message? IdMessageNavigation { get; set; }
}
