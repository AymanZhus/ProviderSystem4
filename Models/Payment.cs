using System;
using System.Collections.Generic;

namespace ProviderSystem.Models;

public partial class Payment
{
    public int IdPayment { get; set; }

    public int IdUser { get; set; }

    public int Total { get; set; }

    public DateTime DateOfPayment { get; set; }
}
