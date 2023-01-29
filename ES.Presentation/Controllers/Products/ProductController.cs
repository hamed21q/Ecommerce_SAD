using ES.Application.Contracts.Products.Product;
using ES.Application.Contracts.Products.Product.DTOs;
using ES.Application.Contracts.Products.Product.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace ES.Presentation.Controllers.Products
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductApplication productApplication;

        public ProductController(IProductApplication productApplication)
        {
            this.productApplication = productApplication;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Post([FromBody] CreateProductCommand command)
        {
            await productApplication.Add(command);
            return Ok();
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> Put([FromBody] EditProductCommand command)
        {
            await productApplication.Edit(command);
            return Ok();
        }
        
        [HttpGet("ProductsByCategory")]
        public async Task<List<ProductViewModel>> GetByCategoryId(long id)
        {
            try
            {
                return await productApplication.GetByCategory(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                await productApplication.Delete(id);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }
       
        [HttpGet("id")]
        public async Task<DetailedProductViewModel>  GetBy(long id)
        {
            try
            {
                return await productApplication.GetBy(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
