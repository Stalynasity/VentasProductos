using System;
using System.Collections.Generic;

namespace BOOT.Domain.Entities;

public partial class InvoiceHead
{
    public int InvoiceHeadId { get; set; }

    public double Total { get; set; }

    public DateTime DateTime { get; set; }

    public int UseId { get; set; }

    public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; } = new List<InvoiceDetail>();

    public virtual TUser? Use { get; set; }
}
