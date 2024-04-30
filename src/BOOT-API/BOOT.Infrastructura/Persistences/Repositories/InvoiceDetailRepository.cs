using BOOT.Domain.Entities;
using BOOT.Infrastructura.Commons.Invoice;
using BOOT.Infrastructura.Persistences.Contexts;

namespace BOOT.Infrastructura.Persistences.Repositories
{
    public class InvoiceDetailRepository
    {
        public void CreateInvoiceDetail(DbproductContext context, List<CreateInvoiceModal> ListDetail, int InvoiceHeadId)
        {
            List<InvoiceDetail> listId = new List<InvoiceDetail>();

            foreach (CreateInvoiceModal item in ListDetail)
            {
                InvoiceDetail invoiceDetail = new InvoiceDetail();
                invoiceDetail.InvoiceHeadId = InvoiceHeadId;
                invoiceDetail.Price = item.Price;
                invoiceDetail.Count = item.Count;
                invoiceDetail.ProductId = item.ProductId;

                listId.Add(invoiceDetail);
            }

            context.InvoiceDetails.AddRange(listId);

            context.SaveChanges();
        }

        public List<InvoiceDetail> GetInvoiceDetailByHeadId(DbproductContext Context, int HeadId)
        {
            return Context.InvoiceDetails.Where(x => x.InvoiceHeadId == HeadId).ToList();
        }

    }
}

