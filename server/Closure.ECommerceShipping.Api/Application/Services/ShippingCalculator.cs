using System;
using Closure.ECommerceShipping.Api.Domain;

namespace Closure.ECommerceShipping.Api.Application.Services
{
    public class ShippingCalculator: IShippingCalculator
    {
        public DateTime Calculate(DateTime shipDate, Product product)
        {
            return shipDate.AddDays(product.MaxBusinessDaysToShip-1);
        }
    }
}