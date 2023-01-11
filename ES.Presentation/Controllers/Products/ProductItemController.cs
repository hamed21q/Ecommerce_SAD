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
        public ProductItemViewModel Get(long id)
        {
            return ItemApplication.GetBy(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateProductItemCommand command)
        {
            ItemApplication.Add(command);
            return Ok();
        }

        [HttpPut]
        public IActionResult Put([FromBody] EditProductItemCommand command)
        {
            ItemApplication.Edit(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            ItemApplication.Delete(id);
            return Ok();
        }

        [HttpGet("siblings")]
        public List<ProductItemViewModel> GetSibllings(long productId)
        {
            return ItemApplication.GetAllSibllings(productId);
        }
    }
}
