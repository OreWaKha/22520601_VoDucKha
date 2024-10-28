using System;
using System.Collections.Generic;

namespace ThucHanh.Models;

public partial class Account
{
    public int Id { get; set; }

    public string? Username { get; set; }

    public string? Pass { get; set; }
}
