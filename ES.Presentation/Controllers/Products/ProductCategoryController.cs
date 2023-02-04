using ES.Application.Contracts.Products.ProductCategory;
using ES.Application.Contracts.Products.ProductCategory.DTOs;
using ES.Application.Contracts.Products.ProductCategory.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace ES.Presentation.Controllers.Products
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategoryApplication productCategoryApplication;

        public ProductCategoryController(IProductCategoryApplication productCategoryApplication)
        {
            this.productCategoryApplication = productCategoryApplication;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductCategoryViewModel>> Get()
        {
            var list = await productCategoryApplication.GetAll();
            return list;
        }

        [HttpGet("Loadbalancertest")]
        public string nginx()
        {
            return "Hostname: " + System.Environment.MachineName + "\n" + "Container ID: " + System.Diagnostics.Process.GetCurrentProcess().Id;
        }

        [HttpGet("{id}")]
        public async Task<ProductCategoryViewModel> Get(long id)
        {
            return await productCategoryApplication.GetBy(id);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProductCategoryCommand command)
        {
            await productCategoryApplication.Add(command);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] EditProductCategoryCommand command)
        {
            await productCategoryApplication.Edit(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await productCategoryApplication.Remove(id);
            return Ok();
        }
        [HttpPost("Activate")]
        public async Task<IActionResult> Activate(long id)
        {
            await productCategoryApplication.Activate(id);
            return Ok();
        }
    }
}
