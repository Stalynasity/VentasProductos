using BOOT.Domain.Entities;
using BOOT.Infrastructura.Persistences.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOOT.Infrastructura.Persistences.Repositories
{
    public class InvoiceHeadRepository
    {
        public int CreateHeadInvoice(DbproductContext context, double total, int userID) 
        {
            InvoiceHead InvoiceH = new InvoiceHead();
            InvoiceH.Total = total;
            InvoiceH.DateTime = DateTime.Now;
            InvoiceH.UseId = userID;

            context.InvoiceHeads.Add(InvoiceH);
            context.SaveChanges();
            return InvoiceH.InvoiceHeadId;
        }

        public List<InvoiceHead> GetAllInvoiceByUserId(DbproductContext Context, int userId)
        {
            return Context.InvoiceHeads.Where(x => x.UseId == userId).ToList();
        }

        public InvoiceHead? GetInvoiceByUserIdAndHeadId(DbproductContext Context, int HeadId, int userId)
        {
            return Context.InvoiceHeads.SingleOrDefault(x => x.UseId == userId && x.InvoiceHeadId == HeadId);
        }
    }
}
