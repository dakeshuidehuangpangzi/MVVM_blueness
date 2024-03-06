using System;
using System.Collections.Generic;

namespace EfCoreTest.Models;

public partial class User
{
    public string UId { get; set; } = null!;

    public string UName { get; set; } = null!;

    public string UType { get; set; } = null!;

    public string? UPassword { get; set; }
}
