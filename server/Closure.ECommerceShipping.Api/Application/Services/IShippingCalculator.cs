using System;
using Closure.ECommerceShipping.Api.Domain;

namespace Closure.ECommerceShipping.Api.Application.Services
{
    public interface IShippingCalculator
    {
        public DateTime Calculate(DateTime orderDate, Product product);
    }
}