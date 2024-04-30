using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOOT.Infrastructura.Commons.Invoice.Request
{
    public class CreateInvoiceRequest
    {
        public int ProductId { get; set; }
        public int Count { get; set; }
    }
}
