using System;
using System.Collections.Generic;

namespace EfCoreTest.Models;

public partial class OrderDetail
{
    public int DId { get; set; }

    public string OId { get; set; } = null!;

    public string GId { get; set; } = null!;

    public double DPrice { get; set; }

    public short DNumber { get; set; }

    public virtual Good GIdNavigation { get; set; } = null!;

    public virtual Order OIdNavigation { get; set; } = null!;
}
