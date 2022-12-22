using ES.Application.Contracts.ProductVariation;
using ES.Application.Contracts.ProductVariationOption;
using ES.Application.Contracts.ProductVariationOption.DTOs;
using ES.Application.Contracts.ProductVariationOption.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ES.Presentation.Controllers
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
        public ProductVariationOptionViewModel Get(long id)
        {
            return productVariationOptionApplication.GetBy(id);
        }

        // POST api/<ProductVariationOptionController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateProductVariationOptionCommand command)
        {
            productVariationOptionApplication.Add(command);
            return Ok();
        }

        // PUT api/<ProductVariationOptionController>/5
        [HttpPut]
        public IActionResult Put([FromBody] EditProductVariationOptionCommand command)
        {
            productVariationOptionApplication.Edit(command);
            return Ok();
        }

        // DELETE api/<ProductVariationOptionController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            productVariationOptionApplication.Delete(id);
        }
    }
}
