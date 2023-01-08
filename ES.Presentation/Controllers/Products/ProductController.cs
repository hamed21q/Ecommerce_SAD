using ES.Application.Contracts.Products.Product;
using ES.Application.Contracts.Products.Product.DTOs;
using ES.Application.Contracts.Products.Product.ViewModels;
using ES.Application.Contracts.Products.ProductItem.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        public ProductViewModel GetBy(long id)
        {
            return productApplication.GetBy(id);
        }
        
        [HttpGet]
        public List<ProductViewModel> GetAll()
        {
            return productApplication.GetAll();
        }

        [HttpGet("variants")]
        public List<ProductItemViewModel> GetAllVariants(long id)
        {
            return productApplication.GetAllVariant(id);
        }
    }
}
