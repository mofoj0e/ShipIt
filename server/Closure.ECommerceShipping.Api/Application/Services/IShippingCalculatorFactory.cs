using Closure.ECommerceShipping.Api.Domain;

namespace Closure.ECommerceShipping.Api.Application.Services
{
    public interface IShippingCalculatorFactory
    {
        public IShippingCalculator GetShippingCalculator(Product product);
    }
}