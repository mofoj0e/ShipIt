using System;
using System.Linq;
using Closure.ECommerceShipping.Api.Domain;

namespace Tests
{
    public class ProductBuilder
    {
        private readonly Product _product = new();

        public Product Build() => _product;

        public static ProductBuilder Default()
        {
            return new ProductBuilder()
                .WithName(GetRandom.String())
                .WithQuantity(10)
                .WithMaxBusinessDaysToShip(10)
                .WithShipOnWeekends(true);

        }

        public ProductBuilder WithName(string value)
        {
            _product.Name = value;
            return this;
        }

        public ProductBuilder WithQuantity(int value)
        {
            _product.InventoryQuantity = value;
            return this;
        }
        
        public ProductBuilder WithMaxBusinessDaysToShip(int value)
        {
            _product.MaxBusinessDaysToShip = value;
            return this;
        }
       
        public ProductBuilder WithShipOnWeekends(bool value)
        {
            _product.ShipOnWeekends = value;
            return this;
        }
        public ProductBuilder WithImageUrl(string value)
        {
            _product.ImageUrl = value;
            return this;
        }
    }


    public static class GetRandom
    {
        private static readonly Random Random = new();

        public static string String(int length = 10)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[Random.Next(s.Length)]).ToArray());
        }
    }
}