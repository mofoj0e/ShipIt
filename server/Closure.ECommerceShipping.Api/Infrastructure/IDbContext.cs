using Closure.ECommerceShipping.Api.Domain;
using MongoDB.Driver;

namespace Closure.ECommerceShipping.Api.Infrastructure
{
    public interface IDbContext
    {
        public IMongoCollection<Product> Products { get; }
    }
}
