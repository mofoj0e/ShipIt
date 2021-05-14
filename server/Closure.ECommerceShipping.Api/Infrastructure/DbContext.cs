using Closure.ECommerceShipping.Api.Configurations;
using Closure.ECommerceShipping.Api.Domain;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Closure.ECommerceShipping.Api.Infrastructure
{
    public class DbContext : IDbContext
    {
        private readonly IMongoDatabase _database;

        public DbContext(IOptions<DbConfig> dbConfig)
        {
            var client = new MongoClient(dbConfig.Value.ConnectionString);
            _database = client.GetDatabase(dbConfig.Value.Database);
        }

        public IMongoCollection<Product> Products => _database.GetCollection<Product>(nameof(Product));
    }
}
