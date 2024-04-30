using System;
using System.Collections.Generic;

namespace BOOT.Domain.Entities;

public partial class TUser
{
    public int UseId { get; set; }

    public string UseName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Status { get; set; } = null!;

    public virtual ICollection<InvoiceHead> InvoiceHeads { get; set; } = new List<InvoiceHead>();
}
