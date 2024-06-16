using System;
using System.Collections.Generic;

namespace ProviderSystem.Models;

public partial class Service
{
    public int IdService { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int Price { get; set; }

    public virtual ICollection<FieldWork> FieldWorks { get; set; } = new List<FieldWork>();
}
