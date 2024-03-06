using System;
using System.Collections.Generic;

namespace EfCoreTest.Models;

public partial class Order
{
    public string OId { get; set; } = null!;

    public string CId { get; set; } = null!;

    public DateTime ODate { get; set; }

    public double OSum { get; set; }

    public string EId { get; set; } = null!;

    public string OSendMode { get; set; } = null!;

    public string PId { get; set; } = null!;

    public bool OStatus { get; set; }

    public virtual Customer CIdNavigation { get; set; } = null!;

    public virtual Employee EIdNavigation { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual Payment PIdNavigation { get; set; } = null!;
}
