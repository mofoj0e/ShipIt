using Closure.ECommerceShipping.Api.Domain;

namespace Closure.ECommerceShipping.Api.Application.Services
{
    public class ShippingCalculatorFactory : IShippingCalculatorFactory
    {
        public IShippingCalculator GetShippingCalculator(Product product)
        {
            return product.ShipOnWeekends ? new ShippingCalculator() : new NoWeekendShippingCalculator();
        }
    }
}