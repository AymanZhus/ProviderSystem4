using System;
using System.Collections.Generic;

namespace ProviderSystem.Models;

public partial class Position
{
    public int IdPosition { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
