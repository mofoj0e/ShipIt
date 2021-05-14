using System;
using Closure.ECommerceShipping.Api.Domain;

namespace Closure.ECommerceShipping.Api.Application.Services
{
    public class NoWeekendShippingCalculator : IShippingCalculator
    {
        public DateTime Calculate(DateTime shipDate, Product product)
        {
            for (var i = 1; i < product.MaxBusinessDaysToShip; i++)
            {
                do
                {
                    shipDate = shipDate.AddDays(1);
                } 
                while (shipDate.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday);
            }

            return shipDate;
        }
    }
}