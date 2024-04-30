using BOOT.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BOOT.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public readonly IProductApplication _productApplication;

        public ProductController(IProductApplication productApplication)
        {
            _productApplication = productApplication;
        }



        // GET: api/<ProductController>
        [HttpGet]
        public async Task<IActionResult> ListProduct()
        {
            var response = await _productApplication.ListProduct();
            return Ok(response);
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> ProductByID(int id)
        {
            var response = await _productApplication.ProductById(id);
            return Ok(response);
        }
    }
}
