using Closure.ECommerceShipping.Api.Application.Services;
using Closure.ECommerceShipping.Api.Domain;
using FluentAssertions;
using NUnit.Framework;

namespace Tests
{
    public class ShippingCalculatorFactoryTests
    {
        private IShippingCalculatorFactory _shippingCalculatorfactory;
        private readonly Product _productWithNoWeekendShipping = ProductBuilder.Default().WithShipOnWeekends(false).Build();
        private readonly Product _productWithWeekendShipping = ProductBuilder.Default().WithShipOnWeekends(true).Build();
            
        [SetUp]
        public void Setup() => _shippingCalculatorfactory = new ShippingCalculatorFactory();

 
        [Test]
        public void ShippingCalculatorFactory_ShouldReturnCorrectCalculator_GivenWeekendShippingProduct()
        {
            var weekendShippingCalculator = _shippingCalculatorfactory.GetShippingCalculator(_productWithWeekendShipping);

            weekendShippingCalculator.GetType().Should().Be(typeof(ShippingCalculator));
        }
       
        [Test]
        public void ShippingCalculatorFactory_ShouldReturnCorrectCalculator_GivenNoWeekendShippingProduct()
        {
            var noWeekendShippingCalculator = _shippingCalculatorfactory.GetShippingCalculator(_productWithNoWeekendShipping);

            noWeekendShippingCalculator.GetType().Should().Be(typeof(NoWeekendShippingCalculator));
        }
    }
}