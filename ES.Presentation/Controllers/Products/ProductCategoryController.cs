﻿using ES.Application.Contracts.Products.ProductCategory;
using ES.Application.Contracts.Products.ProductCategory.DTOs;
using ES.Application.Contracts.Products.ProductCategory.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace ES.Presentation.Controllers.Products
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategoryApplication productCategoryApplication;

        public ProductCategoryController(IProductCategoryApplication productCategoryApplication)
        {
            this.productCategoryApplication = productCategoryApplication;
        }

        [HttpGet]
        public IEnumerable<ProductCategoryViewModel> Get()
        {
            var list = productCategoryApplication.GetAll();
            return list;
        }

        [HttpGet("{id}")]
        public ProductCategoryViewModel Get(long id)
        {
            return productCategoryApplication.GetBy(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateProductCategoryCommand command)
        {
            productCategoryApplication.Add(command);
            return Ok();
        }

        [HttpPut]
        public IActionResult Put([FromBody] EditProductCategoryCommand command)
        {
            productCategoryApplication.Edit(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            productCategoryApplication.Remove(id);
            return Ok();
        }
        [HttpPost("Activate")]
        public IActionResult Activate(long id)
        {
            productCategoryApplication.Activate(id);
            return Ok();
        }
    }
}