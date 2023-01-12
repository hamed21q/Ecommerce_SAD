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
        public IActionResult Post([FromBody] CreateProductCommand command)
        {
            productApplication.Add(command);
            return Ok();
        }

        [HttpPut("Edit")]
        public IActionResult Put([FromBody] EditProductCommand command)
        {
            productApplication.Edit(command);
            return Ok();
        }
        
        [HttpGet("ProductsByCategory")]
        public List<ProductViewModel> GetByCategoryId(long id)
        {
            try
            {
                return productApplication.GetByCategory(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            try
            {
                productApplication.Delete(id);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }
       
        [HttpGet("id")]
        public DetailedProductViewModel GetBy(long id)
        {
            try
            {
                return productApplication.GetBy(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
