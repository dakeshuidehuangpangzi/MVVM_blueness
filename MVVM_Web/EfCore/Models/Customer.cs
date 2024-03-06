using System;
using System.Collections.Generic;

namespace EfCoreTest.Models;

public partial class Customer
{
    public string CId { get; set; } = null!;

    public string CName { get; set; } = null!;

    public string CTrueName { get; set; } = null!;

    public string CGender { get; set; } = null!;

    public DateTime CBirth { get; set; }

    public string CCardId { get; set; } = null!;

    public string? CAddress { get; set; }

    public string? CPostcode { get; set; }

    public string? CMobile { get; set; }

    public string? CPhone { get; set; }

    public string? CEMail { get; set; }

    public string CPassword { get; set; } = null!;

    public string CSafeCode { get; set; } = null!;

    public string CQuestion { get; set; } = null!;

    public string CAnswer { get; set; } = null!;

    public string CType { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
