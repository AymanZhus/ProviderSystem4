using System;
using System.Collections.Generic;

namespace ProviderSystem.Models;

public partial class User
{
    public int IdUser { get; set; }

    public string Fio { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int? IdTariffPlan { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int Balance { get; set; }

    public int IdPosition { get; set; }

    public int IdCity { get; set; }

    public string Address { get; set; } = null!;

    public string? BlockStatus { get; set; }

    public virtual ICollection<Bill> Bills { get; set; } = new List<Bill>();

    public virtual ICollection<FieldWork> FieldWorkIdUserNavigations { get; set; } = new List<FieldWork>();

    public virtual ICollection<FieldWork> FieldWorkIdWorkerNavigations { get; set; } = new List<FieldWork>();

    public virtual City IdCityNavigation { get; set; } = null!;

    public virtual Position IdPositionNavigation { get; set; } = null!;

    public virtual TariffPlan? IdTariffPlanNavigation { get; set; }

    public virtual ICollection<Journal> Journals { get; set; } = new List<Journal>();

    public virtual ICollection<Message> MessageIdUserNavigations { get; set; } = new List<Message>();

    public virtual ICollection<Message> MessageIdWorkerNavigations { get; set; } = new List<Message>();

    public virtual ICollection<UserRating> UserRatings { get; set; } = new List<UserRating>();
}
