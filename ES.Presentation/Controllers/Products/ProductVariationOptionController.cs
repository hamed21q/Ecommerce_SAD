using ES.Application.Contracts.Products.ProductVariationOption;
using ES.Application.Contracts.Products.ProductVariationOption.DTOs;
using ES.Application.Contracts.Products.ProductVariationOption.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace ES.Presentation.Controllers.Products
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductVariationOptionController : ControllerBase
    {
        private readonly IProductVariationOptionApplication productVariationOptionApplication;

        public ProductVariationOptionController(IProductVariationOptionApplication productVariationOptionApplication)
        {
            this.productVariationOptionApplication = productVariationOptionApplication;
        }
        [HttpGet]
        public async Task<ProductVariationOptionViewModel> Get(long id)
        {
            return await productVariationOptionApplication.GetBy(id);
        }

        // POST api/<ProductVariationOptionController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProductVariationOptionCommand command)
        {
            await productVariationOptionApplication.Add(command);
            return Ok();
        }

        // PUT api/<ProductVariationOptionController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] EditProductVariationOptionCommand command)
        {
            await productVariationOptionApplication.Edit(command);
            return Ok();
        }

        // DELETE api/<ProductVariationOptionController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await productVariationOptionApplication.Delete(id);
            return Ok();
        }
    }
}
