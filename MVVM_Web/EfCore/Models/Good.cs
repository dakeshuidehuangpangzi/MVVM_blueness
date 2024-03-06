using System;
using System.Collections.Generic;

namespace EfCoreTest.Models;

public partial class Good
{
    public string GId { get; set; } = null!;

    public string GName { get; set; } = null!;

    public int? TId { get; set; }

    public double GPrice { get; set; }

    public double GDiscount { get; set; }

    public short GNumber { get; set; }

    public DateTime GProduceDate { get; set; }

    public string? GImage { get; set; }

    public string GStatus { get; set; } = null!;

    public string? GDescription { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual Type? TIdNavigation { get; set; }
}
