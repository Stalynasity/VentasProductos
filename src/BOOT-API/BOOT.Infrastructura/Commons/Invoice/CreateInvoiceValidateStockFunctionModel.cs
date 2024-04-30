using BOOT.Domain.Entities;
using BOOT.Infrastructura.Commons.Invoice.Request;

namespace BOOT.Infrastructura.Commons.Invoice
{
    public class CreateInvoiceValidateStockFunctionModel
    {
        //Listado de productos que llega en la peticion

        public List<CreateInvoiceRequest> ListReq { get; set; }

        public List<Product> ListProd { get; set; }

        public List<CreateInvoiceModal> ListProdSend { get; set; }

        public double TotalInvoice { get; set; }

        public List<CreateInvoiceModal> ListProdudUpdate { get; set; }

    }
}
