using BOOT.Application.Commons.General;
using BOOT.Domain.Entities;
using BOOT.Infrastructura.Commons.Invoice;
using BOOT.Infrastructura.Commons.Invoice.Request;
using BOOT.Infrastructura.Commons.Invoice.Response;
using BOOT.Infrastructura.Persistences.Contexts;
using BOOT.Infrastructura.Persistences.Interfaces;
using BOOT.Infrastructura.Persistences.Repositories;
using BOOT.Utilities.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOOT.Application.Services
{
    public class InvoiceApplication
    {
        DbproductContext ContextDB;

        public InvoiceApplication(DbproductContext _Context)
        {
            ContextDB = _Context;
        }

        public CreateInvoceResponse CreateInvoiceModel(DbproductContext context, List<CreateInvoiceRequest> ListReq, int UserID) 
        {
            ProductRepository ProductRep = new ProductRepository(context);

            context.Database.BeginTransaction();
            try
            {

                List<Product> ListProd = new List<Product>();

                CreateInvoceResponse? ValidateProd = ValidateIdProductDB(context, ListReq, ref ListProd);
                if (ValidateProd != null)
                {
                    return ValidateProd;
                }

                if (ListProd.Count != ListReq.Count)
                {
                    return new CreateInvoceResponse
                    {
                        InvoiceId = null,
                        Message = ReplyMessage.ErrorCreateInvoiceProductNotFound
                    };
                }

                double TotalInvoice = 0;
                List<CreateInvoiceModal> ListProdSend = new List<CreateInvoiceModal>();

                List<CreateInvoiceModal> ListProdUpdate = new List<CreateInvoiceModal>();

                List<Product> ListProdModel = ListProd;


                CreateInvoiceValidateStockFunctionModel ModelValStock = new CreateInvoiceValidateStockFunctionModel
                {
                    ListReq = ListReq,
                    ListProd = ListProdModel,
                    ListProdSend = ListProdSend,
                    TotalInvoice = TotalInvoice,
                    ListProdudUpdate = ListProdUpdate,
                };

                //nueva lista donde va a validar el ingreso los valores y la actualizacion de mi precio  
                CreateInvoceResponse? ProcForeachProduct = ValidateInvoiceStockProduct(context, ref ModelValStock);
                if (ProcForeachProduct != null)
                {
                    return ProcForeachProduct;
                }

                ListProdUpdate = ModelValStock.ListProdudUpdate;
                ListProdSend = ModelValStock.ListProdSend;
                TotalInvoice = ModelValStock.TotalInvoice;




                InvoiceHeadRepository InvoiceHR = new InvoiceHeadRepository();
                int InvoiceHeadId = InvoiceHR.CreateHeadInvoice(context, TotalInvoice, UserID);

                InvoiceDetailRepository invoiceDR = new InvoiceDetailRepository();
                invoiceDR.CreateInvoiceDetail(context, ListProdSend, InvoiceHeadId);

                ProductRep.UpdateProductsCount(context, ListProd, ListProdUpdate);

                context.Database.CommitTransaction();


                return new CreateInvoceResponse
                {
                    InvoiceId = InvoiceHeadId,
                    Message = "",
                };

            }
            catch (Exception)
            {
                return new CreateInvoceResponse
                {
                    InvoiceId = null,
                    Message = ReplyMessage.ErrorCreateInvoice,
                };
                throw;
            }
        }

        public GenericResponse<List<InvoiceHead>> GetAllInvoiceByUserId(int UserId)
        {
            try
            {
                InvoiceHeadRepository invoiceHReq = new InvoiceHeadRepository();
                List<InvoiceHead> ListInvoice = invoiceHReq.GetAllInvoiceByUserId(ContextDB, UserId);

                return new GenericResponse<List<InvoiceHead>>
                {
                    statusCode = 200,
                    data = ListInvoice,
                    message = ""

                };

            }
            catch (Exception ex)
            {
                return new GenericResponse<List<InvoiceHead>>
                {
                    statusCode = 500,
                    data = null,
                    message = ReplyMessage.GetInvoiceErrorHead
                };
                throw;
            }
        }

        public GenericResponse<List<InvoiceDetailResponse>> GetInvoiceDetailByHeadId(int InvoiceHeadId, int UserId)
        {
            try
            {
                InvoiceHeadRepository InvoiceHReq = new InvoiceHeadRepository();
                InvoiceHead InvoiceFind = InvoiceHReq.GetInvoiceByUserIdAndHeadId(ContextDB, InvoiceHeadId, UserId);

                if (InvoiceFind == null)
                {
                    return new GenericResponse<List<InvoiceDetailResponse>>
                    {
                        statusCode = 500,
                        data = null,
                        message = ReplyMessage.GetInvoiceErrorDetailNotUser,
                    };
                }

                InvoiceDetailRepository InvoiceDrep = new InvoiceDetailRepository();
                List<InvoiceDetail> ListDetails = InvoiceDrep.GetInvoiceDetailByHeadId(ContextDB, InvoiceHeadId);

                List<InvoiceDetailResponse> ListReturn = [];
                foreach (var item in ListDetails)
                {
                    ListReturn.Add(new InvoiceDetailResponse
                    {
                        InvoiceDetailId = item.InvoiceDetailId,
                        Price = item.Price,
                        ProductId = item.ProductId,
                    });
                }

                return new GenericResponse<List<InvoiceDetailResponse>>
                {
                    statusCode = 200,
                    data = ListReturn,
                    message = "",
                };

            }
            catch (Exception)
            {
                return new GenericResponse<List<InvoiceDetailResponse>>
                {
                    statusCode = 500,
                    data = null,
                    message = ReplyMessage.GetInvoiceErrorDetail,
                };
                throw;
            }
        }

        public CreateInvoceResponse? ValidateIdProductDB(DbproductContext context, List<CreateInvoiceRequest> ListReq, ref List<Product> ListProd)
        {
            ProductRepository ProductRep = new ProductRepository(context);

            ListProd = ProductRep.GetAllIdProducts(context, ListReq.Select(x => x.ProductId).ToList());

            if (ListProd.Count != ListReq.Count)
            {
                return new CreateInvoceResponse
                {
                    InvoiceId = null,
                    Message = ReplyMessage.ErrorCreateInvoiceProductNotFound,
                };
            }

            return null;
        }


        public CreateInvoceResponse? ValidateInvoiceStockProduct(DbproductContext context, ref CreateInvoiceValidateStockFunctionModel ModelValStock)
        {
            List<Product> ListProdModif = new List<Product>();
            List<CreateInvoiceModal> ListProdUpdate = new List<CreateInvoiceModal>();

            foreach (CreateInvoiceRequest ProductReq in ModelValStock.ListReq)
            {
                //Busca el productoId que coincida 
                Product ProductFindBD = ModelValStock.ListProd.Single(x => x.ProductId == ProductReq.ProductId);

                //recorre de mi ProductFindBD cantidad de producto sea menor al ProductReq cantidad (logica no puede ser mayor)
                if (ProductFindBD.Count < ProductReq.Count)
                {
                    return new CreateInvoceResponse
                    {
                        InvoiceId = null,
                        Message = "es menor mi cantidad de producto",
                    };
                }

                CreateInvoiceModal ModeT = new CreateInvoiceModal();
                ModeT.ProductId = ProductReq.ProductId;
                ModeT.Count = ProductReq.Count;
                ModeT.Price = ProductFindBD.Price;

                ModelValStock.TotalInvoice += ModeT.Price * ModeT.Count;

                ModelValStock.ListProdSend.Add(ModeT);

                CreateInvoiceModal ProdModel = new CreateInvoiceModal();
                ProdModel.ProductId = ProductFindBD.ProductId;
                ProdModel.Count = ProductFindBD.Count - ModeT.Count;

                //almacenamos a las lista modificado
                ListProdModif.Add(ProductFindBD);
                ListProdUpdate.Add(ProdModel);
            }

            ModelValStock.ListProd = ListProdModif;
            ModelValStock.ListProdudUpdate = ListProdUpdate;
            return null;
        }
    }
}
