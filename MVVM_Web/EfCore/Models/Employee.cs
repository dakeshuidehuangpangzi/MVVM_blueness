using System;
using System.Collections.Generic;

namespace EfCoreTest.Models;

public partial class Employee
{
    public string EId { get; set; } = null!;

    public string EName { get; set; } = null!;

    public string EGender { get; set; } = null!;

    public DateTime EBirth { get; set; }

    public string? EAddress { get; set; }

    public string? EPostcode { get; set; }

    public string? EMobile { get; set; }

    public string EPhone { get; set; } = null!;

    public string EEMail { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
