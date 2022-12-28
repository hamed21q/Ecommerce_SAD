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
        private readonly IProductItemApplication productItemApplication;

        public ProductItemController(IProductItemApplication productItemApplication)
        {
            this.productItemApplication = productItemApplication;
        }


        // GET api/<ProductItemController>/5
        [HttpGet("{id}")]
        public ProductItemViewModel Get(long id)
        {
            return productItemApplication.GetBy(id);
        }

        // POST api/<ProductItemController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateProductItemCommand command)
        {
            productItemApplication.Add(command);
            return Ok();
        }

        // PUT api/<ProductItemController>/5
        [HttpPut]
        public IActionResult Put([FromBody] EditProductItemCommand command)
        {
            productItemApplication.Edit(command);
            return Ok();
        }

        // DELETE api/<ProductItemController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            productItemApplication.Delete(id);
            return Ok();
        }
        [HttpGet]
        public List<ProductItemViewModel> GetAll()
        {
            return productItemApplication.GetAll();
        }
    }
}
