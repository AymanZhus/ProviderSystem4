using System;
using System.Collections.Generic;

namespace ProviderSystem.Models;

public partial class UserTraffic
{
    public int IdUser { get; set; }

    public int VolumeTraffic { get; set; }

    public DateTime Date { get; set; }

    public virtual User IdUserNavigation { get; set; } = null!;
}
