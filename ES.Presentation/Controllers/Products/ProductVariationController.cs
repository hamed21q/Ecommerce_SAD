using ES.Application.Contracts.Products.ProductVariation;
using ES.Application.Contracts.Products.ProductVariation.DTOs;
using ES.Application.Contracts.Products.ProductVariation.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ES.Presentation.Controllers.Products
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductVariationController : ControllerBase
    {
        private readonly IProductVariationApplication productVariationApplication;
        public ProductVariationController(IProductVariationApplication productVariationApplication)
        {
            this.productVariationApplication = productVariationApplication;
        }

        // GET api/<ProductVariationController>/5
        [HttpGet("{id}")]
        public async Task<ProductVariationViewModel> Get(long id)
        {
            return await productVariationApplication.GetBy(id);
        }

        // POST api/<ProductVariationController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProductVariationCommand command)
        {
            await productVariationApplication.Add(command);
            return Ok();
        }

        // PUT api/<ProductVariationController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] EditProductVariationCommand command)
        {
            await productVariationApplication.Edit(command);
            return Ok();
        }

        // DELETE api/<ProductVariationController>/5
        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            await productVariationApplication.Remove(id);
            return Ok();
        }
        [HttpGet("ByCategory")]
        public async Task<List<DetailedProductVariationViewModel>> GetByCategory(long categoryId)
        {
            return await productVariationApplication.GetByCategory(categoryId);
        }
    }
}
