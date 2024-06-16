using System;
using System.Collections.Generic;

namespace ProviderSystem.Models;

public partial class Message
{
    public int IdMessage { get; set; }

    public int IdUser { get; set; }

    public int IdWorker { get; set; }

    public string Text { get; set; } = null!;

    public int IdStatusMessage { get; set; }

    public virtual StatusMessage IdStatusMessageNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;

    public virtual User IdWorkerNavigation { get; set; } = null!;
}
