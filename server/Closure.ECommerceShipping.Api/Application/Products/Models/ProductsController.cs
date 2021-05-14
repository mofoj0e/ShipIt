using System;
using System.Threading.Tasks;
using Closure.ECommerceShipping.Api.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Closure.ECommerceShipping.Api.Application.Products.Models
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] GetProductsFilter filter)
        {
            return Ok(await _productService.GetProducts(filter));
        }

        [HttpGet("{id}", Name = "GetProduct")]
        public async Task<IActionResult> GetProduct(string id, [FromQuery] DateTime orderDate)
        {
            return Ok(await _productService.GetProduct(id, orderDate));
        }


        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductAddDto productAddDto)
        {
            return Ok(await _productService.AddProduct(productAddDto));
        }

    }
}