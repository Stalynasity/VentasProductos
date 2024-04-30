using System;
using System.Collections.Generic;

namespace BOOT.Domain.Entities;

public partial class User
{
    public int UserId { get; set; }

    public string? Name { get; set; }

    public string? LastName { get; set; }

    public string? IdentityCard { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? Direccion { get; set; }

    public string? Phone { get; set; }

    public int? State { get; set; }

    public virtual ICollection<InvoiceHead> InvoiceHeads { get; set; } = new List<InvoiceHead>();
}
