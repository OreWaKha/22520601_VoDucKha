using System;
using System.Collections.Generic;

namespace TH.Models;

public partial class Product
{
    public int Id { get; set; }

    public int? CatalogId { get; set; }

    public string ProductCode { get; set; } = null!;

    public string ProductName { get; set; } = null!;

    public string? Picture { get; set; }

    public decimal UnitPrice { get; set; }

    public virtual Catalog? Catalog { get; set; }
}
