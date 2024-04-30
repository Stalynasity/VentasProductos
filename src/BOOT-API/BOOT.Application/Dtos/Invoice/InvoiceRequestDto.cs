namespace BOOT.Application.Dtos.Invoice
{
    public class InvoiceRequestDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int State { get; set; }
    }
}
