using System;
using System.Collections.Generic;

namespace EfCoreTest.Models;

public partial class Payment
{
    public string PId { get; set; } = null!;

    public string PMode { get; set; } = null!;

    public string? PRemark { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
