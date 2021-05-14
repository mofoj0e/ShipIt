using System;
using AutoMapper;
using Closure.ECommerceShipping.Api.Application;
using Closure.ECommerceShipping.Api.Application.Common;
using Closure.ECommerceShipping.Api.Application.Products;
using Closure.ECommerceShipping.Api.Application.Products.Models;
using Closure.ECommerceShipping.Api.Application.Services;
using Closure.ECommerceShipping.Api.Domain;

namespace Closure.ECommerceShipping.Api
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ProductAddDto, Product>();

            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.DeliveryDate, option => option.MapFrom<DeliveryDateResolver>());
        }
    }

    public class DeliveryDateResolver : IValueResolver<Product, ProductDto, DateTime>
    {
        private readonly IShippingCalculatorFactory _shippingCalculatorfactory;

        public DeliveryDateResolver(IShippingCalculatorFactory shippingCalculatorfactory)
        {
            _shippingCalculatorfactory = shippingCalculatorfactory;
        }

        public DateTime Resolve(Product source, ProductDto destination, DateTime member, ResolutionContext context)
        {
            DateTime orderDate = (DateTime)context.Items[Constants.OrderDate];
            
            return _shippingCalculatorfactory.GetShippingCalculator(source).Calculate(orderDate, source);
        }
    }
}
