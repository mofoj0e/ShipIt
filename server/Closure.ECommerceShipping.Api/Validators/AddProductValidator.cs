using Closure.ECommerceShipping.Api.Application.Common;
using Closure.ECommerceShipping.Api.Application.Products.Models;
using FluentValidation;

namespace Closure.ECommerceShipping.Api.Validators
{
    public class AddProductValidator : AbstractValidator<ProductAddDto>
    {
        public AddProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage(Constants.ValidationMessages.ProductNameRequired);

            RuleFor(p => p.InventoryQuantity)
                .GreaterThan(0)
                .NotEmpty()
                .WithMessage(Constants.ValidationMessages.ProductQuantityRequired);
            
            RuleFor(p => p.MaxBusinessDaysToShip)
                .GreaterThan(0)
                .NotEmpty()
                .WithMessage(Constants.ValidationMessages.ProductMaxBusinessDaysToShipRequired);
        }
    }
}