using System;
using System.Collections.Generic;

namespace BOOT.Domain.Entities;

public partial class Product
{
    public int ProductId { get; set; }

    public int CategoryId { get; set; }

    public string? Name { get; set; }

    public double? Price { get; set; }

    public int? Stock { get; set; }

    public string? ImagUrl { get; set; }

    public int? State { get; set; }

    public virtual Category Categorys { get; set; } = null!;

    public virtual ICollection<InvoiceDetaild> InvoiceDetailds { get; set; } = new List<InvoiceDetaild>();
}
