using System;
using System.Collections.Generic;

namespace ProviderSystem.Models;

public partial class Bill
{
    public int IdBill { get; set; }

    public int IdUser { get; set; }

    public int Total { get; set; }

    public string Status { get; set; } = null!;

    public DateTime DateOfBill { get; set; }

    public virtual User IdUserNavigation { get; set; } = null!;
}
