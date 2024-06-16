using System;
using System.Collections.Generic;

namespace ProviderSystem.Models;

public partial class Event
{
    public int IdEvent { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<Journal> Journals { get; set; } = new List<Journal>();
}
