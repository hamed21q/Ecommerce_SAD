using ES.Application.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ES.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategoryApplication productCategoryApplication;

        public ProductCategoryController(
            IProductCategoryApplication productCategoryApplication
        )
        {
            this.productCategoryApplication = productCategoryApplication;
        }

        // GET: api/<ProductCategory>
        [HttpGet]
        public IEnumerable<ProductCategoryViewModel> Get()
        {
            return productCategoryApplication.GetAll();
        }

        // GET api/<ProductCategoryController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductCategoryController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateProductCategoryCommand command)
        {
            productCategoryApplication.Add(command);
            return Ok();
        }

        // PUT api/<ProductCategoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductCategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
