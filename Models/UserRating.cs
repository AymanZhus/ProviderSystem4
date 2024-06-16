using System;
using System.Collections.Generic;

namespace ProviderSystem.Models;

public partial class UserRating
{
    public int IdUserRating { get; set; }

    public int IdTariffPlan { get; set; }

    public int IdUser { get; set; }

    public int Mark { get; set; }

    public virtual TariffPlan IdTariffPlanNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}
