using ES.Application.Contracts.Products.ProductItem;
using ES.Application.Contracts.Products.ProductItem.DTOs;
using ES.Application.Contracts.Products.ProductItem.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ES.Presentation.Controllers.Products
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductItemController : ControllerBase
    {
        private readonly IProductItemApplication ItemApplication;

        public ProductItemController(IProductItemApplication productItemApplication)
        {
            this.ItemApplication = productItemApplication;
        }
        [HttpGet("{id}")]
        public async Task<ProductItemViewModel> Get(long id)
        {
            return await ItemApplication.GetBy(id);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProductItemCommand command)
        {
            await ItemApplication.Add(command);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] EditProductItemCommand command)
        {
            await ItemApplication.Edit(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await ItemApplication.Delete(id);
            return Ok();
        }

        [HttpGet("siblings")]
        public async Task<List<ProductItemViewModel>> GetSibllings(long productId)
        {
            return await ItemApplication.GetAllSibllings(productId);
        }
    }
}
