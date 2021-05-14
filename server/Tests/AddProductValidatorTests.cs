using Closure.ECommerceShipping.Api.Application;
using Closure.ECommerceShipping.Api.Application.Common;
using Closure.ECommerceShipping.Api.Application.Products.Models;
using Closure.ECommerceShipping.Api.Validators;
using FluentValidation.TestHelper;
using NUnit.Framework;

namespace Tests
{
    public class AddProductValidatorTests
    {
        private AddProductValidator _validator;

        [SetUp]
        public void Setup()
        {
            _validator = new AddProductValidator();
        }

        [Test]
        public void AddProductValidator_ShouldReturnValidationError_GivenEmptyName()
        {

            _validator.TestValidate(new ProductAddDto())
                .ShouldHaveValidationErrorFor(product => product.Name)
                .WithErrorMessage(Constants.ValidationMessages.ProductNameRequired);
        }

        [Test]
        public void AddProductValidator_ShouldReturnValidationError_GivenEmptyQuantity()
        {
            _validator.TestValidate(new ProductAddDto())
                .ShouldHaveValidationErrorFor(product => product.Name)
                .WithErrorMessage(Constants.ValidationMessages.ProductNameRequired);
        }

        [Test]
        public void AddProductValidator_ShouldReturnValidationError_GivenLessThanZeroMaxShipDate()
        {
            _validator.TestValidate(new ProductAddDto(){MaxBusinessDaysToShip = -1})
                .ShouldHaveValidationErrorFor(product => product.Name)
                .WithErrorMessage(Constants.ValidationMessages.ProductNameRequired);
        }

        [Test]
        public void AddProductValidator_ShouldNotHaveAnyErrors()
        {
            var result = _validator.TestValidate(new ProductAddDto() { Name = GetRandom.String(), MaxBusinessDaysToShip = 5, ShipOnWeekends = true, InventoryQuantity = 5});

            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}