using System;
using System.Collections.Generic;

namespace ProviderSystem.Models;

public partial class TariffPlan
{
    public int IdTariffPlan { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int Price { get; set; }

    public int? Rating { get; set; }

    public int Gigabytes { get; set; }

    public virtual ICollection<Journal> Journals { get; set; } = new List<Journal>();

    public virtual ICollection<UserRating> UserRatings { get; set; } = new List<UserRating>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
