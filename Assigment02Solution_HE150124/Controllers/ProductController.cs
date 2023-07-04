using BusinessObject;
using DataAccess.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eStoreAP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _productService.GetPagingList();
                return new JsonResult(new ResponeBase<ProductDto>
                {
                    Status = ResponeStatus.Success,
                    Result = result
                });
            }
            catch (Exception ex)
            {
                return new JsonResult(new ResponeBase<ProductDto>
                {
                    Status = ResponeStatus.InternalServer,
                    Message = ex.Message
                });
            }
        }

        // GET api/<ValuesController>/5
        [HttpGet("detailProduct/{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost("addProduct")]
        public async Task<IActionResult> Post(ProductAddDto value)
        {
            try
            {
                var result = await _productService.AddProduct(value);
                return new JsonResult(result);
            }catch(Exception ex)
            {
                return new JsonResult(new ResponeBase<ProductAddDto>
                {
                    Status = ResponeStatus.InternalServer,
                    Message = ex.Message
                });
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("delete/{id}")]
        public void Delete(int id)
        {
        }
    }
}
