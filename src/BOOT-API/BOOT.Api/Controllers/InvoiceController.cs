using BOOT.Api.Filters;
using BOOT.Application.Commons.General;
using BOOT.Application.Helpers;
using BOOT.Application.Services;
using BOOT.Domain.Entities;
using BOOT.Infrastructura.Commons.Invoice.Request;
using BOOT.Infrastructura.Commons.Invoice.Response;
using BOOT.Infrastructura.Persistences.Contexts;
using Microsoft.AspNetCore.Mvc;


namespace BOOT.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(SessionUsuarioFilter))]
    public class InvoiceController : ControllerBase
    {
        private readonly DbproductContext _db;
        private InvoiceApplication _application;
        public InvoiceController(DbproductContext db)
        {
            _db = db;
            _application = new InvoiceApplication(db);
        }

        // GET: api/<InvoiceController>
        [HttpGet("openCard")]
        public GenericResponse<List<InvoiceHead>> Get()
        {
            var ModelSesion = (new MethodsHelper()).GetModelSesionByToken(HttpContext.Request.Headers["Authorization"].ToString());
            return _application.GetAllInvoiceByUserId(ModelSesion.Userid);

        }

        // GET api/<InvoiceController>/5
        [HttpGet("{id}")]
        public GenericResponse<List<InvoiceDetailResponse>> Get(int id)
        {
            var ModelSesion = (new MethodsHelper()).GetModelSesionByToken(HttpContext.Request.Headers["Authorization"].ToString());
            return _application.GetInvoiceDetailByHeadId(id, ModelSesion.Userid);
        }

        //POST api/<InvoiceController>
        [HttpPost("list")]
        public GenericResponse<CreateInvoceResponse> Post([FromBody] List<CreateInvoiceRequest> ReqModel)
        {
            var modelSesion = (new MethodsHelper()).GetModelSesionByToken(HttpContext.Request.Headers["Authorization"].ToString());
            CreateInvoceResponse Resp = _application.CreateInvoiceModel(_db, ReqModel, modelSesion.Userid);
            if (Resp.InvoiceId != null)
            {
                return new GenericResponse<CreateInvoceResponse>
                {
                    statusCode = 200,
                    data = Resp,
                    message = "",
                };
            }
            else
            {
                return new GenericResponse<CreateInvoceResponse>
                {
                    statusCode = 200,
                    data = Resp,
                    message = Resp.Message,
                };
            }
        }
    }
}
