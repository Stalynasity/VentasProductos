using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOOT.Application.Dtos.Product.Response
{
    public class ProductResponseDto
    {
        public int ProductId { get; set; }

        public int CategoryId { get; set; }

        public string? Name { get; set; }

        public double? Price { get; set; }

        public int? Stock { get; set; }

        public string? ImagUrl { get; set; }

        public int? State { get; set; }
    }
}
