using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Closure.ECommerceShipping.Api.Application.Common;
using Closure.ECommerceShipping.Api.Application.Products.Models;
using Closure.ECommerceShipping.Api.Controllers;
using Closure.ECommerceShipping.Api.Domain;
using Closure.ECommerceShipping.Api.Infrastructure;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Closure.ECommerceShipping.Api.Application.Products
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IDbContext _dbContext;

        public ProductService(IMapper mapper, IDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<ProductDto>> GetProducts(GetProductsFilter filter)
        {
            var productsQuery = _dbContext.Products.AsQueryable();

            if (filter.Ids != null)
                productsQuery = productsQuery.Where(product => filter.Ids.Contains(product.Id));

            var products = await productsQuery.ToListAsync();

            return _mapper.Map<IReadOnlyList<ProductDto>>(products,
                opts => 
                    opts.Items.Add(Constants.OrderDate, filter.OrderDate == DateTime.MinValue ? DateTime.UtcNow : filter.OrderDate));
        }

        public async Task<ProductDto> GetProduct(string id, DateTime orderDate)
        {
            var product = await _dbContext.Products.AsQueryable().Where((p => p.Id == id)).FirstAsync();
            return _mapper.Map<ProductDto>(product, opts => opts.Items.Add(Constants.OrderDate, orderDate));
        }

        public async Task<ProductDto> AddProduct(ProductAddDto productAddDto)
        {
            var product = _mapper.Map<Product>(productAddDto);
            await _dbContext.Products.InsertOneAsync(product);
            return await GetProduct(product.Id, DateTime.UtcNow);
        }
    }
}
    
