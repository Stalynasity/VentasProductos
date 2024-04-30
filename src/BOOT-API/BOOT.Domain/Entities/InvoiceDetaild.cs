using System;
using System.Collections.Generic;

namespace BOOT.Domain.Entities;

public partial class InvoiceDetaild
{
    public int InvoiceDetailId { get; set; }

    public int? ProductId { get; set; }

    public int? Count { get; set; }

    public double? Price { get; set; }

    public int InvoiceHeadId { get; set; }

    public virtual InvoiceHead InvoiceDetail { get; set; } = null!;

    public virtual Product? Product { get; set; }
}
