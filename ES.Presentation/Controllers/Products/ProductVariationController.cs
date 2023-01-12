﻿using ES.Application.Contracts.Products.ProductVariation;
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
        public ProductVariationViewModel Get(long id)
        {
            return productVariationApplication.GetBy(id);
        }

        // POST api/<ProductVariationController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateProductVariationCommand command)
        {
            productVariationApplication.Add(command);
            return Ok();
        }

        // PUT api/<ProductVariationController>/5
        [HttpPut]
        public IActionResult Put([FromBody] EditProductVariationCommand command)
        {
            productVariationApplication.Edit(command);
            return Ok();
        }

        // DELETE api/<ProductVariationController>/5
        [HttpDelete]
        public IActionResult Delete(long id)
        {
            productVariationApplication.Remove(id);
            return Ok();
        }
        [HttpGet("ByCategory")]
        public List<DetailedProductVariationViewModel> GetByCategory(long categoryId)
        {
            return productVariationApplication.GetByCategory(categoryId);
        }
    }
}
