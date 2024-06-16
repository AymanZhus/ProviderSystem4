using System;
using System.Collections.Generic;

namespace ProviderSystem.Models;

public partial class StatusMessage
{
    public int IdStatusMessage { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Message> Messages { get; set; } = new List<Message>();
}
