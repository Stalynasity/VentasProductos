namespace BOOT.Infrastructura.Commons.Invoice.Response
{
    public class InvoiceResponseDto
    {
        public int InvoiceHeadId { get; set; }

        public string? Name { get; set; }

        public string? LastName { get; set; }

        public double? Total { get; set; }

        public DateTime? DateTime { get; set; }

        public int UserId { get; set; }

        public string? IdentityCard { get; set; }

        public string? Email { get; set; }

        public string? ProductTypo { get; set; }

        public int? Count { get; set; }

        public double? Price { get; set; }
    }
}
