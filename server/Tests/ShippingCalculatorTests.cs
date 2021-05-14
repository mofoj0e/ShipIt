using System;
using Closure.ECommerceShipping.Api.Application.Services;
using Closure.ECommerceShipping.Api.Domain;
using FluentAssertions;
using NUnit.Framework;

namespace Tests
{
    public class ShippingCalculatorTests
    {
        private IShippingCalculator _defaultShippingCalculator;
        private IShippingCalculator _noWeekendShippingCalculator;

        private readonly DateTime _orderDate = new DateTime(2021, 5, 12);

        [SetUp]
        public void Setup()
        {
            _defaultShippingCalculator = new ShippingCalculator();
            _noWeekendShippingCalculator = new NoWeekendShippingCalculator();
        }

        [Test]
        public void ShippingCalculatorFactory_ShouldReturnCorrectDeliveryDate_GivenNoWeekendShippingProduct()
        {
            var deliveryDate = _noWeekendShippingCalculator.Calculate(_orderDate, 
                    ProductBuilder.Default().WithMaxBusinessDaysToShip(10).WithShipOnWeekends(false).Build());

            deliveryDate.Should().Be(new DateTime(2021, 5, 25));
        }

        [Test]
        public void ShippingCalculatorFactory_ShouldReturnCorrectDeliveryDate_GivenWeekendShippingProduct()
        {
            var deliveryDate = _defaultShippingCalculator.Calculate(_orderDate, 
                    ProductBuilder.Default().WithMaxBusinessDaysToShip(10).WithShipOnWeekends(true).Build());

            deliveryDate.Should().Be(new DateTime(2021, 5, 21));
        }
    }
}