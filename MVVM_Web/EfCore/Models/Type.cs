using System;
using System.Collections.Generic;

namespace EfCoreTest.Models;

public partial class Type
{
    public int TId { get; set; }

    public string TName { get; set; } = null!;

    public string? TDescription { get; set; }

    public virtual ICollection<Good> Goods { get; set; } = new List<Good>();
}
