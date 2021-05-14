using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Closure.ECommerceShipping.Api.Application.Products.Models;
using Closure.ECommerceShipping.Api.Controllers;

namespace Closure.ECommerceShipping.Api.Application.Products
{
    public interface IProductService
    {

        public Task<IReadOnlyList<ProductDto>> GetProducts(GetProductsFilter filter);
        public Task<ProductDto> GetProduct(string id, DateTime orderDate);
        public Task<ProductDto> AddProduct(ProductAddDto productAddDto);
    }
}
