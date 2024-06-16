using System;
using System.Collections.Generic;

namespace ProviderSystem.Models;

public partial class Journal
{
    public int IdJournal { get; set; }

    public int IdUser { get; set; }

    public int IdEvent { get; set; }

    public int IdTariffPlan { get; set; }

    public DateTime Date { get; set; }

    public virtual Event IdEventNavigation { get; set; } = null!;

    public virtual TariffPlan IdTariffPlanNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}
