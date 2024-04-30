namespace BOOT.Application.Dtos.Product.Response
{
    public class ProductResponseDto
    {
        public int ProductId { get; set; }

        public string Name { get; set; } = null!;

        public double Price { get; set; }

        public int Count { get; set; }

        public int CategoryId { get; set; }

        public string? typoCategory { get; set; }
    }
}
