using System;
using System.Collections.Generic;

namespace ProviderSystem.Models;

public partial class FieldWork
{
    public int IdFieldWork { get; set; }

    public int IdUser { get; set; }

    public int IdWorker { get; set; }

    public int IdService { get; set; }

    public int Price { get; set; }

    public string StatusOfWork { get; set; } = null!;

    public virtual Service IdServiceNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;

    public virtual User IdWorkerNavigation { get; set; } = null!;
}
