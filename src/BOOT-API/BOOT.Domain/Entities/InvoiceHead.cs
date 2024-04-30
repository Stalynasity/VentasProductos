using System;
using System.Collections.Generic;

namespace BOOT.Domain.Entities;

public partial class InvoiceHead
{
    public int InvoiceHeadId { get; set; }

    public double? Total { get; set; }

    public DateTime? DateTime { get; set; }

    public int UserId { get; set; }

    public virtual InvoiceDetaild? InvoiceDetaild { get; set; }

    public virtual User User { get; set; } = null!;
}
